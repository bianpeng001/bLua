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
    public class LuaFunction : LuaObject
    {
        private readonly LuaState state;
        private LuaRef luaref = LUA_NOREF;
        private int top;

        public LuaFunction(LuaState state, int luaref)
        {
            this.state = state;
            this.luaref = luaref;
        }

        protected override void OnDispose()
        {
            luaref.Destroy(state);
        }

        public void BeginCall()
        {
            if (!luaref.IsValidRef())
                throw new Exception();

            top = lua_gettop(state);
            luaref.Rawget(state);
        }

        public void EndCall(int nargs, int nrets)
        {
            var err = lua_pcall(state, nargs, nrets, 0);
            if (err != ErrorCode.LUA_OK)
            {
                var msg = lua_tostring(state, -1);
                lua_pop(state, 1);
                LogUtil.Error(msg);
                throw new Exception();
            }
        }

        public void Clean()
        {
            var topEnd = lua_gettop(state);
            if (topEnd != top)
                lua_pop(state, topEnd - top);
        }

        public void Call()
        {
            BeginCall();
            EndCall(0, 0);
        }

        public Result Call<Result>()
        {
            BeginCall();
            EndCall(0, 1);
            var value = AutoWrap.TypeTrait<Result>.pull(state, -1);
            Clean();

            return value;
        }

        public Result Call<T1, Result>(T1 t1)
        {
            BeginCall();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            EndCall(1, 1);
            var value = AutoWrap.TypeTrait<Result>.pull(state, -1);
            Clean();

            return value;
        }

        public Result Call<T1, T2, Result>(T1 t1, T2 t2)
        {
            BeginCall();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            EndCall(2, 1);
            var value = AutoWrap.TypeTrait<Result>.pull(state, -1);
            Clean();

            return value;
        }

        public Result Call<T1, T2, T3, Result>(T1 t1, T2 t2, T3 t3)
        {
            BeginCall();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            AutoWrap.TypeTrait<T3>.push(state, t3);
            EndCall(3, 1);
            var value = AutoWrap.TypeTrait<Result>.pull(state, -1);
            Clean();

            return value;
        }

        public Result Call<T1, T2, T3, T4, Result>(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            BeginCall();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            AutoWrap.TypeTrait<T3>.push(state, t3);
            AutoWrap.TypeTrait<T4>.push(state, t4);
            EndCall(4, 1);
            var value = AutoWrap.TypeTrait<Result>.pull(state, -1);
            Clean();

            return value;
        }

        public Result Call<T1, T2, T3, T4, T5, Result>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            BeginCall();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            AutoWrap.TypeTrait<T3>.push(state, t3);
            AutoWrap.TypeTrait<T4>.push(state, t4);
            AutoWrap.TypeTrait<T5>.push(state, t5);
            EndCall(5, 1);
            var value = AutoWrap.TypeTrait<Result>.pull(state, -1);
            Clean();

            return value;
        }

        public Result Call<T1, T2, T3, T4, T5, T6, Result>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            BeginCall();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            AutoWrap.TypeTrait<T3>.push(state, t3);
            AutoWrap.TypeTrait<T4>.push(state, t4);
            AutoWrap.TypeTrait<T5>.push(state, t5);
            AutoWrap.TypeTrait<T6>.push(state, t6);
            EndCall(6, 1);
            var value = AutoWrap.TypeTrait<Result>.pull(state, -1);
            Clean();

            return value;
        }

        public Result Call<T1, T2, T3, T4, T5, T6, T7, Result>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            BeginCall();
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            AutoWrap.TypeTrait<T3>.push(state, t3);
            AutoWrap.TypeTrait<T4>.push(state, t4);
            AutoWrap.TypeTrait<T5>.push(state, t5);
            AutoWrap.TypeTrait<T6>.push(state, t6);
            AutoWrap.TypeTrait<T7>.push(state, t7);
            EndCall(7, 1);
            var value = AutoWrap.TypeTrait<Result>.pull(state, -1);
            Clean();

            return value;
        }
    }
}

