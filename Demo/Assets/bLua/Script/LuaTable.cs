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
 * 2021年5月22日, 边蓬
 */

using System;
using static bLua.LuaLib;

namespace bLua
{
    public class LuaTable : LuaObject
    {
        private readonly LuaState state;
        private LuaRef luaref;

        public LuaTable(LuaState state, int luaref)
        {
            this.state = state;
            this.luaref = luaref;

            state.AddLuaObject(this);
        }

        protected override void OnDispose()
        {
            state.RemoveLuaObject(this);
            luaref.Destroy(state);
        }

        public void SetField<T>(string name, T value)
        {
            luaref.Rawget(state);
            AutoWrap.TypeTrait<T>.push(state, value);
            lua_setfield(state, -2, name);
            lua_pop(state, 1);
        }

        public T GetField<T>(string name)
        {
            luaref.Rawget(state);
            lua_getfield(state, -1, name);
            var value = AutoWrap.TypeTrait<T>.pull(state, -1);
            lua_pop(state, 2);

            return value;
        }

        private LuaRef GetFieldRef(string name)
        {
            var L = state.L;

            this.luaref.Rawget(state);
            lua_getfield(L, -1, name);
            var luaref = new LuaRef(state);
            lua_pop(L, 1);

            return luaref;
        }

        public LuaFunction GetFunction(string name)
        {
            var luaref = GetFieldRef(name);
            if (!luaref.IsValidRef())
                return null;
            
            return new LuaFunction(state, luaref);
        }

        public LuaTable GetTable(string name)
        {
            var luaref = GetFieldRef(name);
            if (!luaref.IsValidRef())
                return null;

            return new LuaTable(state, luaref);
        }

        public void Push()
        {
            this.luaref.Rawget(state);
        }

        public LuaTable GetMetaTable()
        {
            return null;
        }

        public void SetMetaTable(LuaTable table)
        {
        }
    }
}

