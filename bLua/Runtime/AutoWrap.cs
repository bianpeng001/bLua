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
using System.Reflection;
using static bLua.LuaLib;

namespace bLua
{
    public static partial class AutoWrap
    {
        public delegate void Push<T>(IntPtr L, T value);
        public delegate T Pull<T>(IntPtr L, int pos);

        public interface IUnityMethod
        {
            int Call(IntPtr L);
        }

        private interface IUnityMethodFromDelegate
        {
            void SetDelegate(Delegate del);
        }

        static AutoWrap()
        {
            gparamsCache = new Type[16][];
            for (int n = 0; n < gparamsCache.Length; ++n)
                gparamsCache[n] = new Type[n];

            funcTypeMap = new (Type, Type)[]
            {
                (typeof(Func<>), typeof(System.Func<>)),
                (typeof(Func<,>), typeof(System.Func<,>)),
                (typeof(Func<,,>), typeof(System.Func<,,>)),
                (typeof(Func<,,,>), typeof(System.Func<,,,>)),
                (typeof(Func<,,,,>), typeof(System.Func<,,,,>)),
                (typeof(Func<,,,,,>), typeof(System.Func<,,,,,>)),
                (typeof(Func<,,,,,,>), typeof(System.Func<,,,,,,>)),
                (typeof(Func<,,,,,,,>), typeof(System.Func<,,,,,,,>)),
                (typeof(Func<,,,,,,,,>), typeof(System.Func<,,,,,,,,>)),
                (typeof(Func<,,,,,,,,,>), typeof(System.Func<,,,,,,,,,>)),
                (typeof(Func<,,,,,,,,,,>), typeof(System.Func<,,,,,,,,,,>)),
                (typeof(Func<,,,,,,,,,,,>), typeof(System.Func<,,,,,,,,,,,>)),
                (typeof(Func<,,,,,,,,,,,,>), typeof(System.Func<,,,,,,,,,,,,>)),
                (typeof(Func<,,,,,,,,,,,,,>), typeof(System.Func<,,,,,,,,,,,,,>)),
            };

            actionTypeMap = new (Type, Type)[]
            {
                (typeof(Action), typeof(System.Action)),
                (typeof(Action<>), typeof(System.Action<>)),
                (typeof(Action<,>), typeof(System.Action<,>)),
                (typeof(Action<,,>), typeof(System.Action<,,>)),
                (typeof(Action<,,,>), typeof(System.Action<,,,>)),
                (typeof(Action<,,,,>), typeof(System.Action<,,,,>)),
                (typeof(Action<,,,,,>), typeof(System.Action<,,,,,>)),
                (typeof(Action<,,,,,,>), typeof(System.Action<,,,,,,>)),
                (typeof(Action<,,,,,,,>), typeof(System.Action<,,,,,,,>)),
                (typeof(Action<,,,,,,,,>), typeof(System.Action<,,,,,,,,>)),
                (typeof(Action<,,,,,,,,,>), typeof(System.Action<,,,,,,,,,>)),
            };
        }

        private static void CheckArgumentCount(IntPtr L, int count)
        {
            int argc = lua_gettop(L);
            if (!(argc >= count))
            {
                throw new Exception("argument count not match");
            }
        }

        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
        private static int CallUnityMethod(IntPtr L)
        {
            var method = TypeTrait<IUnityMethod>.pull(L, 1);
            if (method != null)
            {
                try
                {
                    return method.Call(L);
                }
                catch (Exception ex)
                {
                    LogUtil.Error(ex.StackTrace);
                    var traceback = LuaState.GetState(L).GetTraceback(ex.Message);
                    LogUtil.Error(traceback);
                    LuaError(L, ex.Message);
                    return 0;
                }
            }

            return 0;
        }

        private static readonly List<MethodInfo> matchedList = new List<MethodInfo>(8);

        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
        private static int RegisterUnityMethod(IntPtr L)
        {
            CheckArgumentCount(L, 2);
            var argumentCount = lua_gettop(L);
            var classId = TypeTrait<int>.pull(L, -2);
            var methodName = blua_tostring(L, -1);

            var cls = luaRegister.GetClass(classId);
            luaRegister.FindAllMethods(cls, methodName, matchedList);

            if (matchedList.Count == 0)
            {
                LogUtil.Debug($"method not exists: {cls.name}.{methodName}@{argumentCount}");
                return 0;
            }
            else if (matchedList.Count == 1)
            {

                var method = matchedList[0];
                if (method.IsStatic)
                    TypeTrait<IUnityMethod>.push(L, CreateUnityMethod(method));
                else
                    TypeTrait<IUnityMethod>.push(L, CreateDynMethod(method));

                return 1;
            }
            else
            {
                var method = new OverloadResolver(matchedList);
                matchedList.Clear();
                TypeTrait<IUnityMethod>.push(L, method);
                
                return 1;
            }

        }

        private static IUnityMethod CreateDynMethod(MethodInfo method)
        {
            return new DynMethod() { method = method };
        }

        public static LuaRegister luaRegister;

        public static readonly BindingFlags InstanceMemberFlag = BindingFlags.Public
            | BindingFlags.Instance
            | BindingFlags.DeclaredOnly;
        public static readonly BindingFlags StaticMemberFlag = BindingFlags.Public
            | BindingFlags.Static
            | BindingFlags.DeclaredOnly;


        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
        private static int CollectUnityObject(IntPtr L)
        {
            CheckArgumentCount(L, 1);
            LogUtil.Assert(lua_isuserdata(L, 1));

            var objHandle = UserDataGetObjHandle(L, 1);
            LuaState.GetState(L).objCache.Free(objHandle);
            return 0;
        }

        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
        private static int UnityObjectEqual(IntPtr L)
        {
            CheckArgumentCount(L, 1);

            LogUtil.Assert(lua_isuserdata(L, 1));
            LogUtil.Assert(lua_isuserdata(L, 2));

            var aHandle = UserDataGetObjHandle(L, 1);
            var bHandle = UserDataGetObjHandle(L, 2);

            var objCache = LuaState.GetState(L).objCache;
            var result = aHandle == bHandle
                || objCache.GetObject(aHandle) == objCache.GetObject(bHandle);

            TypeTrait<bool>.push(L, result);
            return 1;
        }

        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
        private static int RegisterUnityClass(IntPtr L)
        {
            CheckArgumentCount(L, 2);
            
            var className = blua_tostring(L, 1);
            var cls = luaRegister.GetClass(className);

            LogUtil.Assert(lua_istable(L, 2));
            lua_pushvalue(L, 2);
            LogUtil.Assert(lua_istable(L, 3));

            if (cls.luaref != LUA_NOREF)
            {
                cls.luaref.Dispose(LuaState.GetState(L));
            }
            cls.luaref = new LuaRef(LuaState.GetState(L));
            TypeTrait<int>.push(L, cls.classId);

            return 1;
        }

        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
        private static int TypeOf(IntPtr L)
        {
            CheckArgumentCount(L, 1);
            bool isUserData = false;
            if (lua_isuserdata(L, 1))
            {
                lua_getmetatable(L, 1);
                isUserData = true;
            }

            LogUtil.Assert(lua_istable(L, -1));
            lua_rawgeti(L, -1, 1);
            var classId = TypeTrait<int>.pull(L, -1);
            if (isUserData)
                lua_pop(L, 2);
            else
                lua_pop(L, 1);

            var cls = luaRegister.GetClass(classId);
            TypeTrait<Type>.push(L, cls.type);

            return 1;
        }

        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
        private static int Cast2Type(IntPtr L)
        {
            LogUtil.Assert(lua_isuserdata(L, 1));

            var objHandle = UserDataGetObjHandle(L, 1);
            
            lua_rawgeti(L, 2, 1);
            var classId = TypeTrait<int>.pull(L, -1);
            lua_pop(L, 1);

            var obj = LuaState.GetState(L).objCache.GetObject(objHandle);
            var cls = luaRegister.GetClass(classId);
            PushObject(L, obj, cls);

            return 1;
        }

        public static void Init(LuaState state, LuaRegister luaRegister)
        {
            AutoWrap.luaRegister = luaRegister;

            state.Register("RegisterUnityClass", RegisterUnityClass);
            state.Register("RegisterUnityMethod", RegisterUnityMethod);
            state.Register("CallUnityMethod", CallUnityMethod);

            state.Register("CollectUnityObject", CollectUnityObject);
            state.Register("UnityObjectEqual", UnityObjectEqual);

            state.Register("typeof", TypeOf);
            state.Register("cast2type", Cast2Type);
        }

        public static bool CheckMethodSupportAutoWrap(MethodInfo method)
        {
            return !method.IsSpecialName && CheckPropMethodSupportAutoWrap(method);
        }

        public const int MaxArgumentCount = 10;

        public static bool CheckPropMethodSupportAutoWrap(MethodInfo method)
        {
            static bool CheckArgument(ParameterInfo a)
            {
                return a.IsOut
                    || a.IsIn
                    || a.ParameterType.IsGenericType
                    || a.ParameterType.IsByRef;
            }

            var args = method.GetParameters();
            if (args.Length > MaxArgumentCount)
                return false;

            var notSupport = method.GetCustomAttribute<ObsoleteAttribute>(false) != null
                || (method.GetCustomAttribute<LuaFieldAttribute>(false) is var lf && lf != null && lf.nowrap)
                || method.IsGenericMethod
                || method.IsGenericMethodDefinition
                || method.ReturnType.IsGenericTypeDefinition
                || method.ReturnType.IsByRef
                || Array.FindIndex(args, CheckArgument) >= 0;

            return !notSupport;
        }

        public static bool CheckPropSupportAutoWrap(PropertyInfo prop)
        {
            if (prop.GetCustomAttribute<ObsoleteAttribute>(false) != null)
                return false;

            if (prop.CanRead && !CheckPropMethodSupportAutoWrap(prop.GetGetMethod()))
                return false;

            if (prop.CanWrite && !CheckPropMethodSupportAutoWrap(prop.GetSetMethod()))
                return false;

            if (prop.IsSpecialName)
                return false;

            return true;
        }

    }
}


