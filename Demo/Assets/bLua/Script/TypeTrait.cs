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
using System.Collections.Generic;
using System.Reflection;
using static bLua.LuaLib;

namespace bLua
{
    public static partial class AutoWrap
    {
        private static void PushBool(IntPtr L, bool value)
        {
            lua_pushboolean(L, value ? -1 : 0);
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
            if (lua_isnil(L, pos))
                return null;
            return lua_tostring(L, pos);
        }

        private static void PushString(IntPtr L, string value)
        {
            if (value == null || string.IsNullOrEmpty(value))
                lua_pushnil(L);
            else
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

        private static void PushLuaFunction(IntPtr L, LuaFunction value)
        {
            if (value == null)
                lua_pushnil(L);
            else
                value.Prepare();
        }

        private static LuaFunction PullLuaFunction(IntPtr L, int pos)
        {
            if (lua_isnil(L, pos))
                return null;
            else if (lua_type(L, pos) != DataType.LUA_TFUNCTION)
                throw new Exception();

            lua_pushvalue(L, pos);
            var state = LuaState.GetState(L);
            var func = new LuaFunction(state, new LuaRef(state));
            lua_pop(L, 1);

            return func;
        }

        private static void PushLuaTable(IntPtr L, LuaTable value)
        {
            if (value == null)
            {
                lua_pushnil(L);
                return;
            }
            value.Push();
        }

        private static LuaTable PullLuaTable(IntPtr L, int pos)
        {
            if (lua_isnil(L, pos))
                return null;
            else if (lua_type(L, pos) != DataType.LUA_TTABLE)
                throw new Exception();

            lua_pushvalue(L, pos);
            var state = LuaState.GetState(L);
            var tbl = new LuaTable(state, new LuaRef(state));
            lua_pop(L, 1);

            return tbl;
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

                var objIndex = LuaState.GetState(L).objCache.Add(obj);

                var addr = lua_newuserdatauv(L, 4, 0);
                LogUtil.Assert(addr != IntPtr.Zero);
                UserDataSetObjIndex(L, -1, objIndex);

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

            if (!lua_isuserdata(L, pos))
                throw new Exception();

            var objIndex = UserDataGetObjIndex(L, pos);

            return (T)LuaState.GetState(L).objCache.GetObject(objIndex);
        }

        private static void PushArray<T>(IntPtr L, T[] value)
        {
            if (value == null || value.Length == 0)
                lua_pushnil(L);
            else
                PushObject<T[]>(L, value);
        }

        public static T[] PullArray<T>(IntPtr L, int pos)
        {
            return PullObject<T[]>(L, pos);
        }

        private static void PushList<T>(IntPtr L, List<T> value)
        {
            if (value == null || value.Count == 0)
                lua_pushnil(L);
            else
                PushObject<List<T>>(L, value);
        }

        public static List<T> PullList<T>(IntPtr L, int pos)
        {
            return PullObject<List<T>>(L, pos);
        }

        #region 多返回值

        public interface IMultRet
        {
            void Push(IntPtr L);
        }

        public struct MultRet<T1, T2> : IMultRet
        {
            public (T1, T2) value;

            public void Push(IntPtr L)
            {
                TypeTrait<T1>.push(L, value.Item1);
                TypeTrait<T2>.push(L, value.Item2);
            }

            public static implicit operator MultRet<T1, T2>(in (T1, T2) value)
            {
                return new MultRet<T1, T2>() { value = value };
            }
        }

        public struct MulRet<T1, T2, T3> : IMultRet
        {
            public (T1, T2, T3) value;

            public void Push(IntPtr L)
            {
                TypeTrait<T1>.push(L, value.Item1);
                TypeTrait<T2>.push(L, value.Item2);
                TypeTrait<T3>.push(L, value.Item3);
            }

            public static implicit operator MulRet<T1, T2, T3>(in (T1, T2, T3) value)
            {
                return new MulRet<T1, T2, T3>() { value = value };
            }
        }

        public struct MulRet<T1, T2, T3, T4> : IMultRet
        {
            public (T1, T2, T3, T4) value;

            public void Push(IntPtr L)
            {
                TypeTrait<T1>.push(L, value.Item1);
                TypeTrait<T2>.push(L, value.Item2);
                TypeTrait<T3>.push(L, value.Item3);
                TypeTrait<T4>.push(L, value.Item4);
            }

            public static implicit operator MulRet<T1, T2, T3, T4>(in (T1, T2, T3, T4) value)
            {
                return new MulRet<T1, T2, T3, T4>() { value = value };
            }
        }

        public struct MulRet<T1, T2, T3, T4, T5> : IMultRet
        {
            public (T1, T2, T3, T4, T5) value;

            public void Push(IntPtr L)
            {
                TypeTrait<T1>.push(L, value.Item1);
                TypeTrait<T2>.push(L, value.Item2);
                TypeTrait<T3>.push(L, value.Item3);
                TypeTrait<T4>.push(L, value.Item4);
                TypeTrait<T5>.push(L, value.Item5);
            }

            public static implicit operator MulRet<T1, T2, T3, T4, T5>(in (T1, T2, T3, T4, T5) value)
            {
                return new MulRet<T1, T2, T3, T4, T5>() { value = value };
            }
        }

        private static void PushMultRet<T>(IntPtr L, T value)
        {
            if (value is IMultRet ret)
                ret.Push(L);
            else
            {
                throw new Exception();
            }
        }

        private static void PushMultRetNoGC<T>(IntPtr L, T value) where T : struct, IMultRet
        {
            value.Push(L);
        }

        private static MethodInfo mPushMultRet;
        private static readonly Dictionary<Type, Delegate> multRetCache = new Dictionary<Type, Delegate>();
        private static Delegate MakePushMultRet(Type pushType, Type valueType)
        {
            Delegate dele;
            if (multRetCache.TryGetValue(valueType, out dele))
                return dele;

            if (mPushMultRet == null)
            {
                mPushMultRet = typeof(AutoWrap).GetMethod(
                    "PushMultRetNoGC",
                     BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            }

            dele = Delegate.CreateDelegate(pushType, null, mPushMultRet.MakeGenericMethod(valueType));
            multRetCache[valueType] = dele;
            return dele;
        }

        #endregion

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
                if (type.IsPrimitive)
                {
                    InitPrimitive(type);
                }
                else if (type == typeof(string))
                {
                    push = (Push<string>)PushString as Push<T>;
                    pull = (Pull<string>)PullString as Pull<T>;
                }
                else if (type == typeof(LuaFunction))
                {
                    push = (Push<LuaFunction>)PushLuaFunction as Push<T>;
                    pull = (Pull<LuaFunction>)PullLuaFunction as Pull<T>;
                }
                else if (type == typeof(LuaTable))
                {
                    push = (Push<LuaTable>)PushLuaTable as Push<T>;
                    pull = (Pull<LuaTable>)PullLuaTable as Pull<T>;
                }
                else if (typeof(IMultRet).IsAssignableFrom(type))
                {
                    InitMultRet(type);
                }
                else if (type.IsArray)
                {
                    InitArray(type);
                }
                else if (type.IsGenericType
                    && type.GetGenericTypeDefinition() is var gd
                    && gd == typeof(List<>))
                {
                    InitList(type);
                }
                else if (type.IsEnum)
                {
                    throw new NotSupportedException();
                }
                else if (type == typeof(object))
                {
                    push = (Push<object>)PushObject<object> as Push<T>;
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

            private static void InitPrimitive(Type type)
            {
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
                else
                {
                    throw new NotSupportedException();
                }
            }

            private static void InitMultRet(Type type)
            {
                if (type.IsValueType
                    && type.IsGenericType
                    && type.GetGenericTypeDefinition() is var gd)
                {
                    if (gd == typeof(MultRet<,>))
                        retCount = 2;
                    else if (gd == typeof(MulRet<,,>))
                        retCount = 3;
                    else if (gd == typeof(MulRet<,,,>))
                        retCount = 4;
                    else if (gd == typeof(MulRet<,,,,>))
                        retCount = 5;
                    else
                        throw new NotSupportedException();


                    push = (Push<T>)MakePushMultRet(typeof(Push<T>), typeof(T));

                    pull = null;
                }
                else
                {
                    push = PushMultRet<T>;
                    pull = null;
                }
            }

            private static void InitList(Type type)
            {
                var gargs = type.GetGenericArguments();
                LogUtil.Assert(gargs.Length > 0);
                var elemType = gargs[0];
                if (elemType == typeof(int))
                {
                    push = (Push<List<int>>)PushList<int> as Push<T>;
                    pull = (Pull<List<int>>)PullList<int> as Pull<T>;
                }
                else if (elemType == typeof(float))
                {
                    push = (Push<List<float>>)PushList<float> as Push<T>;
                    pull = (Pull<List<float>>)PullList<float> as Pull<T>;
                }
                else if (elemType == typeof(string))
                {
                    push = (Push<List<string>>)PushList<string> as Push<T>;
                    pull = (Pull<List<string>>)PullList<string> as Pull<T>;
                }
                else if (elemType.IsClass)
                {
                    push = (Push<List<object>>)PushList<object> as Push<T>;
                    pull = (Pull<List<object>>)PullList<object> as Pull<T>;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }

            private static void InitArray(Type type)
            {
                var elemType = type.GetElementType();
                if (elemType == typeof(int))
                {
                    push = (Push<int[]>)PushArray<int> as Push<T>;
                    pull = (Pull<int[]>)PullArray<int> as Pull<T>;
                }
                else if (elemType == typeof(float))
                {
                    push = (Push<float[]>)PushArray<float> as Push<T>;
                    pull = (Pull<float[]>)PullArray<float> as Pull<T>;
                }
                else if (elemType == typeof(string))
                {
                    push = (Push<string[]>)PushArray<string> as Push<T>;
                    pull = (Pull<string[]>)PullArray<string> as Pull<T>;
                }
                else if (elemType.IsClass)
                {
                    push = (Push<object[]>)PushArray<object> as Push<T>;
                    pull = (Pull<object[]>)PullArray<object> as Pull<T>;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
        }
    }
}


