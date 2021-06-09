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

        public interface IUnityMethodFromDelegate
        {
            void SetDelegate(Delegate del);
        }

        private static readonly Type[][] gparamsCache;

        private static readonly (Type, Type)[] funcTypeMap, actionTypeMap;

        private class GenericTypeTree
        {
            public readonly Type gType;

            public GenericTypeTree(Type argType)
            {
                this.gType = argType;
            }

            public List<GenericTypeTree> childList;

            public Type funcType, cbType;
        }

        private static readonly GenericTypeTree
            funcRoot = new GenericTypeTree(null),
            actionRoot = new GenericTypeTree(null);

        private static (Type, Type) GetFuncType(GenericTypeTree node,
            Type funcTemplate, Type cbTemplate,
            Type[] gparams, int gindex)
        {
            if (gindex < gparams.Length)
            {
                var gtype = gparams[gindex];
                if (node.childList == null)
                    node.childList = new List<GenericTypeTree>();

                GenericTypeTree child;
                var index = node.childList.FindIndex(a => a.gType == gtype);
                if (index >= 0)
                    child = node.childList[index];
                else
                {
                    child = new GenericTypeTree(gtype);
                    node.childList.Add(child);
                }
                return GetFuncType(child, funcTemplate, cbTemplate, gparams, gindex + 1);
            }
            else
            {
                if (node.funcType == null)
                {
                    node.funcType = funcTemplate.MakeGenericType(gparams);
                    node.cbType = cbTemplate.MakeGenericType(gparams);
                }
                return (node.funcType, node.cbType);
            }
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
            int cnt = lua_gettop(L);
            if (!(cnt >= count))
            {
                throw new Exception("argument count not match");
            }
        }

#if HAS_MONO_PINVOKE
        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
#endif
        private static int CallUnityMethod(IntPtr L)
        {
            CheckArgumentCount(L, 1);

            var argumentCount = lua_gettop(L) - 1;
            var methodId = (int)lua_tointeger(L, 1);


            var method = unityMethodMap[methodId];
            if (method == null)
            {
                LogUtil.Error($"method not found: methodId={methodId}, args={argumentCount} {lua_type(L, 1)}");
                throw new Exception();
            }
            return method.Call(L);
        }

#if HAS_MONO_PINVOKE
        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
#endif
        private static int CallLuaDelegate(IntPtr L)
        {
            var dele = TypeTrait<LuaDelegate>.pull(L, 1);
            return dele.Call(L);
        }

        private static readonly List<IUnityMethod> unityMethodMap = new List<IUnityMethod>(1024) { null, };

        private static readonly List<MethodInfo> methodList = new List<MethodInfo>(8);

#if HAS_MONO_PINVOKE
        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
#endif
        private static int RegisterUnityMethod(IntPtr L)
        {
            CheckArgumentCount(L, 2);
            var argumentCount = lua_gettop(L);

            var className = lua_tostring(L, -2);
            var methodName = lua_tostring(L, -1);

            var cls = luaRegister.GetClass(className);
            luaRegister.FindAllMethods(cls, methodName, methodList);

            if (methodList.Count == 0)
            {
                LogUtil.Debug($"method not exists: {className}.{methodName}@{argumentCount}");
                return 0;
            }
            else if (methodList.Count == 1)
            {
                var method = CreateUnityMethod(methodList[0]);
                var methodId = unityMethodMap.Count;
                unityMethodMap.Add(method);

                lua_pushinteger(L, methodId);
                return 1;
            }
            else
            {

                var method = new OverloadRecolveMethod(methodList);
                var methodId = unityMethodMap.Count;
                unityMethodMap.Add(method);
                methodList.Clear();

                lua_pushinteger(L, methodId);
                return 1;
            }
        }

        private static IUnityMethod CreateUnityMethod(MethodInfo method)
        {
            var retType = method.ReturnType;
            var arguments = method.GetParameters();
            var argumentCount = arguments.Length;

            Type unityMethodType, cbType;

            if (retType != typeof(void))
            {
                var gparams = gparamsCache[argumentCount + 1];
                for (int i = 0; i < argumentCount; ++i)
                    gparams[i] = arguments[i].ParameterType;
                gparams[argumentCount] = retType;

                var (funcTemplate, cbTemplate) = funcTypeMap[argumentCount];
                (unityMethodType, cbType) = GetFuncType(funcRoot, funcTemplate, cbTemplate, gparams, 0);
            }
            else
            {
                var (actionTemplate, cbTemplate) = actionTypeMap[argumentCount];
                if (argumentCount == 0)
                    (unityMethodType, cbType) = (actionTemplate, cbTemplate);
                else
                {
                    var gparams = gparamsCache[argumentCount];
                    for (int i = 0; i < argumentCount; ++i)
                        gparams[i] = arguments[i].ParameterType;

                    (unityMethodType, cbType) = GetFuncType(actionRoot, actionTemplate, cbTemplate, gparams, 0);
                }
            }

            var obj = Activator.CreateInstance(unityMethodType) as IUnityMethod;
            var cb = Delegate.CreateDelegate(cbType, null, method);

            (obj as IUnityMethodFromDelegate).SetDelegate(cb);

            return obj;
        }

        private static LuaRegister luaRegister;
        private static LuaState state;

        public static readonly BindingFlags InstanceMemberFlag = BindingFlags.Public 
            | BindingFlags.Instance
            | BindingFlags.DeclaredOnly;
        public static readonly BindingFlags StaticMemberFlag = BindingFlags.Public
            | BindingFlags.Static
            | BindingFlags.DeclaredOnly;


#if HAS_MONO_PINVOKE
        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
#endif
        private static int CollectUnityHandle(IntPtr L)
        {
            CheckArgumentCount(L, 1);

            lua_rawgeti(L, 1, 1);
            var objIndex = (int)lua_tointeger(L, 2);
            lua_remove(L, 2);
            
            state.objCache.Free(objIndex);
            return 0;
        }

#if HAS_MONO_PINVOKE
        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
#endif
        private static int RegisterUnityClass(IntPtr L)
        {
            CheckArgumentCount(L, 2);

            var className = lua_tostring(L, 1);
            var cls = luaRegister.GetClass(className);
            AssertTable(lua_istable(L, 2));
            lua_pushvalue(L, 2);
            AssertTable(lua_istable(L, 3));

            if (cls.luaref != LUA_NOREF)
            {
                cls.luaref.Destroy(state);
            }
            cls.luaref = new LuaRef(state);

            return 0;
        }

#if HAS_MONO_PINVOKE
        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
#endif
        private static int TypeOf(IntPtr L)
        {
            CheckArgumentCount(L, 1);
            AssertTable(lua_istable(L, 1));

            lua_pushstring(L, "class");
            lua_rawget(L, -2);
            var className = lua_tostring(L, -1);
            lua_pop(L, 1);

            var cls = luaRegister.GetClass(className);
            TypeTrait<Type>.push(L, cls.type);

            return 1;
        }

#if HAS_MONO_PINVOKE
        [MonoPInvokeCallbackAttribute(typeof(lua_CFunction))]
#endif
        private static int Cast2Type(IntPtr L)
        {
            lua_rawgeti(L, 1, 1);
            var objIndex = (int)lua_tointeger(L, -1);
            lua_pop(L, 1);
            
            lua_pushstring(L, "class");
            lua_rawget(L, -2);
            var className = lua_tostring(L, -1);
            lua_pop(L, 1);

            var obj = state.objCache.GetObject(objIndex);
            var cls = luaRegister.GetClass(className);
            PushObject(L, obj, cls);

            return 1;
        }

        public static void Init(LuaState state, LuaRegister luaRegister)
        {
            AutoWrap.luaRegister = luaRegister;
            AutoWrap.state = state;

            lua_register(state, "RegisterUnityClass", RegisterUnityClass);
            lua_register(state, "RegisterUnityMethod", RegisterUnityMethod);
            lua_register(state, "CallUnityMethod", CallUnityMethod);
            lua_register(state, "CallLuaDelegate", CallLuaDelegate);
            lua_register(state, "CollectUnityHandle", CollectUnityHandle);

            lua_register(state, "typeof", TypeOf);
            lua_register(state, "cast2type", Cast2Type);
        }

        public static bool CheckMethodSupportAutoWrap(MethodInfo method)
        {
            return !method.IsSpecialName && CheckPropMethodSupportAutoWrap(method);
        }

        public static bool CheckPropMethodSupportAutoWrap(MethodInfo method)
        {
            static bool CheckArgument(ParameterInfo a)
            {
                return a.IsOut
                    || a.IsIn
                    || a.ParameterType.IsGenericType
                    || a.ParameterType.IsByRef;
            }

            var notSupport = method.GetCustomAttribute<ObsoleteAttribute>(false) != null
                || method.IsGenericMethod
                || method.IsGenericMethodDefinition
                || method.ReturnType.IsGenericType
                || ((method.GetParameters() is var arguments) && Array.FindIndex(arguments, CheckArgument) >= 0);

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

        private static void AssertTable(bool success)
        {
            LogUtil.Assert(success, "table expected");
        }
    }
}


