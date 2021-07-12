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

//
// 2021年5月22日, 边蓬
//

using System;
using static bLua.LuaLib;

namespace bLua
{
    //
    // 对应的lua那边的table
    //
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
            //luaL_unref(state, LUA_REGISTRYINDEX, luaref);
            //luaref = LUA_NOREF;
            luaref.Dispose(state);
        }

        public void SetField<T>(string name, T value)
        {
            luaref.Rawget(state);
            // tbl
            AutoWrap.TypeTrait<T>.push(state, value);
            // tbl value
            lua_setfield(state, -2, name);
            // tbl
            lua_pop(state, 1);
        }

        public T GetField<T>(string name)
        {
            luaref.Rawget(state);
            // tbl
            lua_getfield(state, -1, name);
            // tbl value
            var value = AutoWrap.TypeTrait<T>.pull(state, -1);
            lua_pop(state, 2);

            return value;
        }

        // 返回一个luaref
        private LuaRef GetFldRef(string name)
        {
            luaref.Rawget(state);
            // table
            lua_getfield(state, -1, name);
            // table fld

            var fldref = new LuaRef(state);
            lua_pop(state, 1);

            return fldref;
        }

        public LuaFunction GetFunction(string name)
        {
            var valref = GetFldRef(name);
            if (!valref.IsValidRef())
                return null;
            
            return new LuaFunction(state, valref);
        }

        public LuaTable GetTable(string name)
        {
            var valref = GetFldRef(name);
            if (!valref.IsValidRef())
                return null;

            return new LuaTable(state, valref);
        }

        public T GetItem<T>(int index)
        {
            luaref.Rawget(state);
            // tbl
            lua_rawgeti(state, -1, index);
            // tbl value
            var value = AutoWrap.TypeTrait<T>.pull(state, -1);
            lua_pop(state, 2);

            return value;
        }

        public void SetItem<T>(int index, T value)
        {
            luaref.Rawget(state);
            // tbl
            AutoWrap.TypeTrait<T>.push(state, value);
            // tbl value
            lua_rawseti(state, -2, index);
            lua_pop(state, 1);
        }

        // 压栈, 给别人用
        public void Push()
        {
            luaref.Rawget(state);
        }

        public LuaTable GetMetaTable()
        {
            // TODO:
            return null;
        }

        public void SetMetaTable(LuaTable table)
        {
            // TODO:
        }

    }
}

