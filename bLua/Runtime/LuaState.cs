/*
Copyright 2021 边蓬(bianpeng001@163.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/



using AOT;
using System;
using System.Collections.Generic;
using System.Text;
using static bLua.LuaLib;

namespace bLua
{

    public sealed class LuaState : IDisposable
    {
        private static (IntPtr, LuaState)[] stateList;

        public static LuaState GetState(IntPtr L)
        {
            for (int i = 0; i < stateList.Length; ++i)
            {
                if (stateList[i].Item1 == L)
                    return stateList[i].Item2;
            }

            return null;
        }

        private readonly ILoader loader;

        #region 对象引用区

        private readonly List<LuaObject> objList = new List<LuaObject>(512);

        internal void AddLuaObject(LuaObject obj)
        {
            obj.indexInLuaState = objList.Count;
            objList.Add(obj);
        }

        internal void RemoveLuaObject(LuaObject obj)
        {
            LogUtil.Assert(objList.Count > 0
                && obj == objList[obj.indexInLuaState],
                "it's a wild object!");

            var index = obj.indexInLuaState;
            var lastIndex = objList.Count - 1;
            if (lastIndex != index)
            {
                var lastObj = objList[lastIndex];
                objList[index] = lastObj;
                lastObj.indexInLuaState = index;
            }
            obj.indexInLuaState = -1;
            objList[lastIndex] = null;
            objList.RemoveAt(lastIndex);
        }

        #endregion

        public LuaState(ILoader loader)
        {
            this.loader = loader;
        }

        ~LuaState()
        {
            Dispose();
        }

        public IntPtr L { get; private set; }

        public void Create()
        {
            L = luaL_newstate();
            stateList = new (IntPtr, LuaState)[] { (L, this), };

            luaL_openlibs(L);
            blua_openlib(L);
            lua_gc(L, GCOption.LUA_GCGEN, 20, 100);
            lua_register(L, "print", Print);

            lua_getglobal(L, "package");
            lua_getfield(L, 1, "searchers");
            lua_pushcfunction(L, Loader);
            lua_rawseti(L, 2, 1);

            lua_pop(L, 2);
        }

        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
        private static int Loader(IntPtr L)
        {
            var path = lua_tostring(L, 1);

            var state = GetState(L);
            var buffer = state.loader.Load(path);

            var nameLength = Encoding.UTF8.GetBytes(path, 0, path.Length, chunkName, 0);
            chunkName[nameLength] = 0;

            if (!state.LoadBuffer(buffer, chunkName))
            {
                lua_pushnil(L);
            }

            return 1;
        }

        private readonly StringBuilder sb = new StringBuilder();

        [MonoPInvokeCallbackAttribute(typeof(LuaLib.lua_CFunction))]
        private static int Print(IntPtr L)
        {
            var top = lua_gettop(L);

            var sb = GetState(L).sb;
            for (int idx = 1; idx <= top; ++idx)
            {
                if (sb.Length > 0)
                    sb.Append(' ');

                var type = lua_type(L, idx);
                switch (type)
                {
                    case DataType.LUA_TNIL:
                        sb.Append("nil");
                        break;

                    case DataType.LUA_TBOOLEAN:
                        {
                            var value = AutoWrap.TypeTrait<bool>.pull(L, idx);
                            sb.Append(value ? "true" : "false");
                        }
                        break;

                    case DataType.LUA_TNUMBER:
                    case DataType.LUA_TSTRING:
                        sb.Append(lua_tostring(L, idx));
                        break;

                    case DataType.LUA_TFUNCTION:
                        sb.Append("<fun>");
                        break;

                    case DataType.LUA_TTABLE:
                        sb.Append(lua_tostring(L, idx));
                        break;

                    case DataType.LUA_TLIGHTUSERDATA:
                        sb.Append("<litudata>");
                        break;

                    case DataType.LUA_TUSERDATA:
                        sb.Append("<udata:");
                        sb.Append(lua_tostring(L, idx));
                        sb.Append('>');
                        break;

                    case DataType.LUA_TNONE:
                        sb.Append("<none>");
                        break;

                    default:
                        sb.Append("<unkown>");
                        break;
                }
            }

            LogUtil.Debug(sb.ToString());
            sb.Clear();

            return 0;
        }

        private bool disposed = false;
        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;

                for (int i = objList.Count - 1; i >= 0; --i)
                    objList[i].Dispose();
                objList.Clear();

                lua_close(L);
                L = IntPtr.Zero;
            }
        }

        public LuaTable Require(string path)
        {
            var topBegin = lua_gettop(L);

            lua_getglobal(L, "require");
            lua_pushstring(L, path);
            
            if (!PCall(1, 1))
                return null;

            var luaref = new LuaRef(this);
            var table = new LuaTable(this, luaref);

            var topEnd = lua_gettop(L);
            if (topEnd != topBegin)
                lua_pop(L, topEnd - topBegin);
            return table;
        }

        public bool DoFile(string path)
        {
            var buffer = loader.Load(path);
            var length = Encoding.UTF8.GetBytes(path, 0, path.Length, chunkName, 0);
            chunkName[length] = 0;

            if (!LoadBuffer(buffer, chunkName))
            {
                return false;
            }
            return PCall(0, LUA_MULTRET);
        }

        public LuaTable DoFileRetTable(string path)
        {
            int topBegin = lua_gettop(L);
            if (!DoFile(path))
            {
                return null;
            }
            var luaref = new LuaRef(this);
            LuaTable tbl = new LuaTable(this, luaref);

            int topEnd = lua_gettop(L);
            if (topEnd != topBegin)
                lua_pop(L, topEnd - topBegin);

            return tbl;
        }

        private static byte[] chunkName = new byte[256];

        public bool DoString(string code)
        {
            var buffer = Encoding.UTF8.GetBytes(code);

            chunkName[0] = (byte)'s';
            chunkName[1] = (byte)'t';
            chunkName[2] = (byte)'r';
            chunkName[3] = (byte)0;

            if (!LoadBuffer(buffer, chunkName))
            {
                return false;
            }
            return PCall(0, LUA_MULTRET);
        }

        private bool LoadBuffer(byte[] buffer, byte[] chunkName)
        {
            return luaL_loadbufferx(L, buffer, buffer.Length, chunkName, null) == ErrorCode.LUA_OK;
        }

        private bool PCall(int args, int rets)
        {
            if (lua_pcall(L, args, rets, 0) != ErrorCode.LUA_OK)
            {
                var msg = lua_tostring(L, -1);
                LogUtil.Error(msg);
                lua_pop(L, 1);

                return false;
            }
            return true;
        }

        public readonly ObjectCache objCache = new ObjectCache();

        public static implicit operator IntPtr(LuaState state) => state.L;

        public string GetTraceback(string msg)
        {
            byte[] bytes = null;
            if (msg != null)
            {
                var count = UTF8Encoding.UTF8.GetByteCount(msg);
                bytes = new byte[count + 1];
                UTF8Encoding.UTF8.GetBytes(msg, 0, msg.Length, bytes, 0);
            }
            luaL_traceback(L, L, bytes, 1);
            var traceback = AutoWrap.TypeTrait<string>.pull(L, -1);
            lua_pop(L, 1);
            return traceback;
        }

        public void Register(string name, lua_CFunction func)
        {
            lua_register(L, name, func);
        }
    }
}

