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
 * 2021年5月16日, 边蓬
 */

using bLua.Extension;
using UnityEngine;
using Float = bLua.AutoWrap.TypeTrait<float>;

namespace bLua
{
    public class LuaClient
    {
        private static readonly LuaClient instance = new LuaClient();
        public static LuaClient Instance => instance;
        public static LuaState State => Instance.state;

        public readonly LuaState state;

        private LuaClient()
        {
            InitUnityTypes();

            state = new LuaState(new LuaFileLoader());
            state.Create();

            var reg = new LuaRegister();
            Binder.Bind(reg);
            AutoWrap.Init(state, reg);
            state.DoFile("Binder.lua");

            state.DoFile("StartUp.lua");
        }

        private static void InitUnityTypes()
        {
            AutoWrap.TypeTrait<Vector4>.Set(
                1,
                (L, value) =>
                {
                    LuaLib.lua_createtable(L, 4, 0);
                    Float.push(L, value.x);
                    LuaLib.lua_rawseti(L, -2, 1);
                    Float.push(L, value.y);
                    LuaLib.lua_rawseti(L, -2, 2);
                    Float.push(L, value.z);
                    LuaLib.lua_rawseti(L, -2, 3);
                    Float.push(L, value.w);
                    LuaLib.lua_rawseti(L, -2, 4);
                },
                (L, pos) =>
                {
                    if (pos < 0)
                        pos = LuaLib.lua_gettop(L) + pos + 1;

                    LuaLib.lua_rawgeti(L, pos, 1);
                    LuaLib.lua_rawgeti(L, pos, 2);
                    LuaLib.lua_rawgeti(L, pos, 3);
                    LuaLib.lua_rawgeti(L, pos, 4);

                    Vector4 v;
                    v.x = Float.pull(L, pos + 1);
                    v.y = Float.pull(L, pos + 2);
                    v.z = Float.pull(L, pos + 3);
                    v.w = Float.pull(L, pos + 4);

                    LuaLib.lua_pop(L, 4);

                    return v;
                });
            AutoWrap.TypeTrait<Vector3>.Set(
                1,
                (L, value) =>
                {
                    LuaLib.lua_createtable(L, 4, 0);
                    Float.push(L, value.x);
                    LuaLib.lua_rawseti(L, -2, 1);
                    Float.push(L, value.y);
                    LuaLib.lua_rawseti(L, -2, 2);
                    Float.push(L, value.z);
                    LuaLib.lua_rawseti(L, -2, 3);
                },
                (L, pos) =>
                {
                    var top = LuaLib.lua_gettop(L);
                    if (pos < 0)
                        pos = top + pos + 1;

                    LuaLib.lua_rawgeti(L, pos, 1);
                    LuaLib.lua_rawgeti(L, pos, 2);
                    LuaLib.lua_rawgeti(L, pos, 3);

                    Vector3 v;
                    v.x = Float.pull(L, -3);
                    v.y = Float.pull(L, -2);
                    v.z = Float.pull(L, -1);

                    LuaLib.lua_pop(L, 3);

                    return v;
                });
            AutoWrap.TypeTrait<Vector2>.Set(
                1,
                (L, value) =>
                {
                    LuaLib.lua_createtable(L, 4, 0);
                    Float.push(L, value.x);
                    LuaLib.lua_rawseti(L, -2, 1);
                    Float.push(L, value.y);
                    LuaLib.lua_rawseti(L, -2, 2);
                },
                (L, pos) =>
                {
                    var top = LuaLib.lua_gettop(L);
                    if (pos < 0)
                        pos = top + pos + 1;

                    LuaLib.lua_rawgeti(L, pos, 1);
                    LuaLib.lua_rawgeti(L, pos, 2);

                    Vector2 v;
                    v.x = Float.pull(L, -2);
                    v.y = Float.pull(L, -1);

                    LuaLib.lua_pop(L, 2);

                    return v;
                });
            AutoWrap.TypeTrait<Color>.Set(
                1,
                (L, value) =>
                {
                    LuaLib.lua_createtable(L, 4, 0);
                    Float.push(L, value.r);
                    LuaLib.lua_rawseti(L, -2, 1);
                    Float.push(L, value.g);
                    LuaLib.lua_rawseti(L, -2, 2);
                    Float.push(L, value.b);
                    LuaLib.lua_rawseti(L, -2, 3);
                    Float.push(L, value.a);
                    LuaLib.lua_rawseti(L, -2, 4);
                },
                (L, pos) =>
                {
                    var top = LuaLib.lua_gettop(L);
                    if (pos < 0)
                        pos = top + pos + 1;

                    LuaLib.lua_rawgeti(L, pos, 1);
                    LuaLib.lua_rawgeti(L, pos, 2);
                    LuaLib.lua_rawgeti(L, pos, 3);
                    LuaLib.lua_rawgeti(L, pos, 4);

                    Color color;
                    color.r = Float.pull(L, -4);
                    color.g = Float.pull(L, -3);
                    color.b = Float.pull(L, -2);
                    color.a = Float.pull(L, -1);

                    LuaLib.lua_pop(L, 4);
                    
                    return color;
                });

            AutoWrap.TypeTrait<Quaternion>.Set(
                1,
                (L, value) =>
                {
                    LuaLib.lua_createtable(L, 4, 0);
                    Float.push(L, value.x);
                    LuaLib.lua_rawseti(L, -2, 1);
                    Float.push(L, value.y);
                    LuaLib.lua_rawseti(L, -2, 2);
                    Float.push(L, value.z);
                    LuaLib.lua_rawseti(L, -2, 3);
                    Float.push(L, value.w);
                    LuaLib.lua_rawseti(L, -2, 4);
                },
                (L, pos) =>
                {
                    if (pos < 0)
                        pos = LuaLib.lua_gettop(L) + pos + 1;

                    LuaLib.lua_rawgeti(L, pos, 1);
                    LuaLib.lua_rawgeti(L, pos, 2);
                    LuaLib.lua_rawgeti(L, pos, 3);
                    LuaLib.lua_rawgeti(L, pos, 4);

                    Quaternion quat;
                    quat.x = Float.pull(L, pos + 1);
                    quat.y = Float.pull(L, pos + 2);
                    quat.z = Float.pull(L, pos + 3);
                    quat.w = Float.pull(L, pos + 4);

                    LuaLib.lua_pop(L, 4);

                    return quat;
                });
        }
    }

}


