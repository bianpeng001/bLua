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

using System;

namespace bLua
{
    public struct LuaRef
    {
        public static int REGISTRYINDEX = LuaLib.LUA_REGISTRYINDEX;

        private int luaref;

        public LuaRef(LuaState state)
        {
            luaref = LuaLib.LUA_NOREF;
            Create(state);
        }

        public bool IsValidRef()
        {
            return luaref != LuaLib.LUA_NOREF
                && luaref != LuaLib.LUA_REFNIL;
        }

        public void Dispose(LuaState state)
        {
            LuaLib.luaL_unref(state, REGISTRYINDEX, luaref);
            luaref = LuaLib.LUA_NOREF;
        }

        public void Create(LuaState state)
        {
            if (luaref != LuaLib.LUA_NOREF)
            {
                throw new Exception();
            }
            luaref = LuaLib.luaL_ref(state, REGISTRYINDEX);
        }

        public void Rawget(LuaState state)
        {
            LuaLib.lua_rawgeti(state, REGISTRYINDEX, luaref);
        }

        public static implicit operator int(in LuaRef a) => a.luaref;
        public static implicit operator LuaRef(int luaref) => new LuaRef() { luaref = luaref };
    }
}
