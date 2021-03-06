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
using static bLua.LuaLib;

namespace bLua
{
    public class LuaFunction : LuaObject
    {
        private readonly LuaState state;
        private LuaRef luaref = LUA_NOREF;
        private int top;

        public LuaFunction(LuaState state, int luaref)
        {
            this.state = state;
            this.luaref = luaref;

            state.AddLuaObject(this);
        }

        protected override void OnDispose()
        {
            state.RemoveLuaObject(this);
            luaref.Dispose(state);
        }

        public void BeginExecute()
        {
            if (!luaref.IsValidRef())
                lua_pushnil(state);
            else
            {
                top = lua_gettop(state);
                luaref.Rawget(state);
            }
        }

        public void Execute(int nargs, int nresultes)
        {
            var err = lua_pcall(state, nargs, nresultes, 0);
            if (err != ErrorCode.LUA_OK)
            {
                var msg = blua_tostring(state, -1);
                lua_pop(state, 1);
                throw new Exception(msg);
            }
        }

        public void EndExecute()
        {
            var topEnd = lua_gettop(state);
            if (topEnd != top)
                lua_pop(state, topEnd - top);
        }

        public void Call()
        {
            BeginExecute();
            Execute(0, 0);
            EndExecute();
        }

        public TResult Call<TResult>()
        {
            BeginExecute();
            Execute(0, 1);
            var value = AutoWrap.TypeTrait<TResult>.pull(state, -1);
            EndExecute();

            return value;
        }

        public TResult Call<T1, TResult>(T1 t1)
        {
            BeginExecute();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            Execute(1, 1);
            var value = AutoWrap.TypeTrait<TResult>.pull(state, -1);
            EndExecute();

            return value;
        }

        public TResult Call<T1, T2, TResult>(T1 t1, T2 t2)
        {
            BeginExecute();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            Execute(2, 1);
            var value = AutoWrap.TypeTrait<TResult>.pull(state, -1);
            EndExecute();

            return value;
        }

        public TResult Call<T1, T2, T3, TResult>(T1 t1, T2 t2, T3 t3)
        {
            BeginExecute();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            AutoWrap.TypeTrait<T3>.push(state, t3);
            Execute(3, 1);
            var value = AutoWrap.TypeTrait<TResult>.pull(state, -1);
            EndExecute();

            return value;
        }

        public TResult Call<T1, T2, T3, T4, TResult>(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            BeginExecute();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            AutoWrap.TypeTrait<T3>.push(state, t3);
            AutoWrap.TypeTrait<T4>.push(state, t4);
            Execute(4, 1);
            var value = AutoWrap.TypeTrait<TResult>.pull(state, -1);
            EndExecute();

            return value;
        }

        public TResult Call<T1, T2, T3, T4, T5, TResult>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            BeginExecute();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            AutoWrap.TypeTrait<T3>.push(state, t3);
            AutoWrap.TypeTrait<T4>.push(state, t4);
            AutoWrap.TypeTrait<T5>.push(state, t5);
            Execute(5, 1);
            var value = AutoWrap.TypeTrait<TResult>.pull(state, -1);
            EndExecute();

            return value;
        }

        public TResult Call<T1, T2, T3, T4, T5, T6, TResult>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            BeginExecute();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            AutoWrap.TypeTrait<T3>.push(state, t3);
            AutoWrap.TypeTrait<T4>.push(state, t4);
            AutoWrap.TypeTrait<T5>.push(state, t5);
            AutoWrap.TypeTrait<T6>.push(state, t6);
            Execute(6, 1);
            var value = AutoWrap.TypeTrait<TResult>.pull(state, -1);
            EndExecute();

            return value;
        }

        public TResult Call<T1, T2, T3, T4, T5, T6, T7, TResult>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            BeginExecute();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            AutoWrap.TypeTrait<T3>.push(state, t3);
            AutoWrap.TypeTrait<T4>.push(state, t4);
            AutoWrap.TypeTrait<T5>.push(state, t5);
            AutoWrap.TypeTrait<T6>.push(state, t6);
            AutoWrap.TypeTrait<T7>.push(state, t7);
            Execute(7, 1);
            var value = AutoWrap.TypeTrait<TResult>.pull(state, -1);
            EndExecute();

            return value;
        }

        public Func<TResult> ToFunc<TResult>()
        {
            return () => Call<TResult>();
        }

        public Func<T1, TResult> ToFunc<T1, TResult>()
        {
            return (T1 t1) => Call<T1, TResult>(t1);
        }

        public Func<T1, T2, TResult> ToFunc<T1, T2, TResult>()
        {
            return (T1 t1, T2 t2) => Call<T1, T2, TResult>(t1, t2);
        }
    }
}

