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

/*
 * 2021年5月11日, 边蓬
 */

#if HAS_MONO_PINVOKE
using AOT;
#endif
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static bLua.LuaLib;

namespace bLua
{

    public sealed class LuaState : IDisposable
    {
        private static (IntPtr L, LuaState state)[] stateList;

        public static LuaState GetState(IntPtr L)
        {
            for (int i = 0; i < stateList.Length; ++i)
            {
                if (stateList[i].L == L)
                    return stateList[i].state;
            }

            return null;
        }

        private readonly ILoader loader;

        #region
        private readonly List<LuaObject> objList = new List<LuaObject>(512);

        internal void AddLuaObject(LuaObject obj)
        {
            obj.index = objList.Count;
            objList.Add(obj);
        }

        internal void RemoveLuaObject(LuaObject obj)
        {
            LogUtil.Assert(objList.Count > 0
                && obj == objList[obj.index],
                "obj is not belong to state");

            var lastIndex = objList.Count - 1;
            if (lastIndex != obj.index)
            {
                var last = objList[lastIndex];
                objList[obj.index] = last;
                last.index = obj.index;
            }
            obj.index = -1;
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
            lua_gc(L, GCOption.LUA_GCGEN, 20, 100);
            lua_register(L, "print", Print);

            lua_getglobal(L, "package");
            lua_getfield(L, 1, "searchers");
            lua_pushcfunction(L, Loader);
            lua_rawseti(L, 2, 1);

            lua_pop(L, 2);
        }

#if HAS_MONO_PINVOKE
        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
#endif
        private static int Loader(IntPtr L)
        {
            var state = GetState(L);

            var path = lua_tostring(L, 1);
            var buffer = state.loader.Load(path);

            var nameLength = Encoding.UTF8.GetBytes(path, 0, path.Length, chunkName, 0);
            chunkName[nameLength] = 0;

            if (!state.LoadBuffer(buffer, chunkName))
            {
                lua_pushnil(L);
            }

            return 1;
        }

        private static readonly StringBuilder sb = new StringBuilder();

#if HAS_MONO_PINVOKE
        [MonoPInvokeCallbackAttribute(typeof(LuaLib.lua_CFunction))]
#endif
        private static int Print(IntPtr L)
        {
            var top = lua_gettop(L);

            for (int i = 1; i <= top; ++i)
            {
                if (sb.Length > 0)
                    sb.Append(' ');

                var type = lua_type(L, i);
                switch (type)
                {
                    case DataType.LUA_TNIL:
                        sb.Append("nil");
                        break;
                    case DataType.LUA_TBOOLEAN:
                        {
                            var value = AutoWrap.TypeTrait<bool>.pull(L, i);
                            sb.Append(value ? "true" : "false");
                        }
                        break;
                    case DataType.LUA_TNUMBER:
                    case DataType.LUA_TSTRING:
                    case DataType.LUA_TFUNCTION:
                        sb.Append(lua_tostring(L, i));
                        break;
                    case DataType.LUA_TTABLE:
                        sb.Append(luaL_tostring(L, i));
                        break;
                    case DataType.LUA_TLIGHTUSERDATA:
                        sb.Append("<litudata>");
                        break;
                    case DataType.LUA_TUSERDATA:
                        sb.Append("<udata:");
                        sb.Append(luaL_tostring(L, i));
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

            Debug.Log(sb.ToString());
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
                {
                    objList[i].Dispose();
                }

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
    }
}



