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
 * 2021年5月21日, 边蓬
 */

using System;
using System.Collections.Generic;
using static bLua.LuaLib;

namespace bLua
{
    public static partial class AutoWrap
    {
        private static int Bool2Int(bool value) => value ? -1 : 0;

        private static void PushBool(IntPtr L, bool value)
        {
            lua_pushboolean(L, Bool2Int(value));
        }

        private static bool PullBool(IntPtr L, int pos)
        {
            return lua_toboolean(L, pos) != 0;
        }

        private static void PushInt(IntPtr L, int value)
        {
            lua_pushinteger(L, value);
        }

        private static int PullInt(IntPtr L, int pos)
        {
            return (int)lua_tointeger(L, pos);
        }

        private static void PushUInt(IntPtr L, uint value)
        {
            lua_pushinteger(L, value);
        }

        private static uint PullUInt(IntPtr L, int pos)
        {
            return (uint)lua_tointeger(L, pos);
        }

        private static void PushLong(IntPtr L, long value)
        {
            lua_pushinteger(L, value);
        }

        private static long PullLong(IntPtr L, int pos)
        {
            return (long)lua_tointeger(L, pos);
        }

        private static float PullFloat(IntPtr L, int pos)
        {
            return (float)lua_tonumber(L, pos);
        }

        private static void PushFloat(IntPtr L, float value)
        {
            lua_pushnumber(L, value);
        }

        private static double PullDouble(IntPtr L, int pos)
        {
            return lua_tonumber(L, pos);
        }

        private static void PushDouble(IntPtr L, double value)
        {
            lua_pushnumber(L, value);
        }

        private static string PullString(IntPtr L, int pos)
        {
            return lua_tostring(L, pos);
        }

        private static void PushString(IntPtr L, string value)
        {
            lua_pushstring(L, value);
        }

        private static void PushValueType<T>(IntPtr L, T value)
        {
            lua_pushnil(L);
        }

        private static T PullValueType<T>(IntPtr L, int pos)
        {
            return default(T);
        }

        private static void PushObject(IntPtr L, object obj, ClassDefinition cls)
        {
            if (obj == null)
            {
                lua_pushnil(L);
            }
            else
            {
                if (cls == null)
                    cls = luaRegister.GetClass(typeof(object));

                var objIndex = state.objCache.Add(obj);

                lua_createtable(L, 1, 0);
                lua_pushinteger(L, objIndex);
                lua_rawseti(L, -2, 1);

                lua_rawgeti(L, LUA_REGISTRYINDEX, cls.luaref);
                lua_setmetatable(L, -2);
            }
        }

        private static void PushObject<T>(IntPtr L, T value)
        {
            var type = typeof(T);
            var obj = (object)value;
            PushObject(L, obj, luaRegister.GetClass(type));
        }

        private static T PullObject<T>(IntPtr L, int pos)
        {
            if (lua_isnil(L, pos))
                return default(T);

            lua_rawgeti(L, pos, 1);
            var objIndex = (int)lua_tointeger(L, -1);
            lua_pop(L, 1);

            return (T)state.objCache.GetObject(objIndex);
        }

        private static void PushArray<T>(IntPtr L, T[] value)
        {
            if (value == null || value.Length == 0)
                lua_pushnil(L);
            else if (value.Length < 32)
            {
                lua_createtable(L, value.Length, 0);
                for (int i = 0; i < value.Length; ++i)
                {
                    TypeTrait<T>.push(L, value[i]);
                    lua_rawseti(L, -2, i + 1);
                }
            }
            else
                PushObject<T[]>(L, value);
        }

        public static T[] PullArray<T>(IntPtr L, int pos)
        {
            AssertTable(lua_istable(L, pos));

            int len = (int)lua_rawlen(L, pos);
            if (len == 0)
                return null;
            T[] value = new T[len];
            for(int i = 0; i < len; ++i)
            {
                lua_rawgeti(L, pos, i + 1);
                value[i] = TypeTrait<T>.pull(L, -1);
            }
            lua_pop(L, len);
            return value;
        }

        private static void PushList<T>(IntPtr L, List<T> value)
        {
            if (value == null || value.Count == 0)
                lua_pushnil(L);
            else if (value.Count < 32)
            {
                lua_createtable(L, value.Count, 0);
                for (int i = 0; i < value.Count; ++i)
                {
                    TypeTrait<T>.push(L, value[i]);
                    lua_rawseti(L, -2, i + 1);
                }
            }
            else
                PushObject<List<T>>(L, value);
        }

        public static List<T> PullList<T>(IntPtr L, int pos)
        {
            AssertTable(lua_istable(L, pos));

            int len = (int)lua_rawlen(L, pos);
            if (len == 0)
                return null;

            List<T> value = new List<T>();
            for (int i = 0; i < len; ++i)
            {
                lua_rawgeti(L, pos, i + 1);
                value.Add(TypeTrait<T>.pull(L, -1));
            }
            lua_pop(L, len);
            return value;
        }

        public static class TypeTrait<T>
        {
            public static int retCount = 1;
            public static Push<T> push;
            public static Pull<T> pull;
            
            public static void Set(int aretCount, Push<T> apush, Pull<T> apull)
            {
                retCount = aretCount;
                push = apush;
                pull = apull;
            }

            static TypeTrait()
            {
                var type = typeof(T);

                if (type == typeof(bool))
                {
                    push = (Push<bool>)PushBool as Push<T>;
                    pull = (Pull<bool>)PullBool as Pull<T>;
                }
                else if (type == typeof(int))
                {
                    push = (Push<int>)PushInt as Push<T>;
                    pull = (Pull<int>)PullInt as Pull<T>;
                }
                else if (type == typeof(uint))
                {
                    push = (Push<uint>)PushUInt as Push<T>;
                    pull = (Pull<uint>)PullUInt as Pull<T>;
                }
                else if (type == typeof(long))
                {
                    push = (Push<long>)PushLong as Push<T>;
                    pull = (Pull<long>)PullLong as Pull<T>;
                }
                else if (type == typeof(float))
                {
                    push = (Push<float>)PushFloat as Push<T>;
                    pull = (Pull<float>)PullFloat as Pull<T>;
                }
                else if (type == typeof(double))
                {
                    push = (Push<double>)PushDouble as Push<T>;
                    pull = (Pull<double>)PullDouble as Pull<T>;
                }
                else if (type == typeof(string))
                {
                    push = (Push<string>)PushString as Push<T>;
                    pull = (Pull<string>)PullString as Pull<T>;
                }
                else if (type.IsArray)
                {
                    var elem = type.GetElementType();
                    if (elem == typeof(int))
                    {
                        push = (Push<int[]>)PushArray<int> as Push<T>;
                        pull = (Pull<int[]>)PullArray<int> as Pull<T>;
                    }
                    else if (elem == typeof(float))
                    {
                        push = (Push<float[]>)PushArray<float> as Push<T>;
                        pull = (Pull<float[]>)PullArray<float> as Pull<T>;
                    }
                    else if (elem == typeof(string))
                    {
                        push = (Push<string[]>)PushArray<string> as Push<T>;
                        pull = (Pull<string[]>)PullArray<string> as Pull<T>;
                    }
                    else if (elem.IsClass)
                    {
                        push = (Push<object[]>)PushArray<object> as Push<T>;
                        pull = (Pull<object[]>)PullArray<object> as Pull<T>;
                    }
                }
                else if (type.IsGenericType
                    && type.GetGenericTypeDefinition() is var gtd
                    && gtd == typeof(List<>))
                {
                    var gargs = type.GetGenericArguments();
                    var gtype = gargs[0];
                    if (gtype == typeof(int))
                    {
                        push = (Push<List<int>>)PushList<int> as Push<T>;
                        pull = (Pull<List<int>>)PullList<int> as Pull<T>;
                    }
                    else if (gtype == typeof(float))
                    {
                        push = (Push<List<float>>)PushList<float> as Push<T>;
                        pull = (Pull<List<float>>)PullList<float> as Pull<T>;
                    }
                    else if (gtype == typeof(string))
                    {
                        push = (Push<List<string>>)PushList<string> as Push<T>;
                        pull = (Pull<List<string>>)PullList<string> as Pull<T>;
                    }
                    else if (gtype.IsClass)
                    {
                        push = (Push<List<object>>)PushList<object> as Push<T>;
                        pull = (Pull<List<object>>)PullList<object> as Pull<T>;
                    }
                }
                else if (type.IsEnum)
                {
                }
                else if (type.IsValueType)
                {
                    push = (Push<T>)PushValueType<T>;
                    pull = (Pull<T>)PullValueType<T>;
                }
                else if (type.IsClass)
                {
                    push = (Push<T>)PushObject<T>;
                    pull = (Pull<T>)PullObject<T>;
                }
            }
        }
    }
}


