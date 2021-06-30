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

namespace bLua
{
    public static partial class AutoWrap
    {

        private static readonly Type[][] gparamsCache;

        private static readonly (Type, Type)[] funcTypeMap, actionTypeMap;

        public class FuncTree
        {
            public readonly Type argType;

            public FuncTree(Type argType)
            {
                this.argType = argType;
            }

            public List<FuncTree> childList;

            public Type funcType, cbType;
        }

        private static readonly FuncTree
            funcRoot = new FuncTree(null),
            actionRoot = new FuncTree(null);

        private static (Type, Type) GetFuncType(
            FuncTree node,
            Type funcTemplate,
            Type cbTemplate,
            Type[] gparams,
            int gIndex)
        {
            if (gIndex < gparams.Length)
            {
                var gtype = gparams[gIndex];
                if (node.childList == null)
                    node.childList = new List<FuncTree>();

                FuncTree child;
                var index = node.childList.FindIndex(a => a.argType == gtype);
                if (index >= 0)
                    child = node.childList[index];
                else
                {
                    child = new FuncTree(gtype);
                    node.childList.Add(child);
                }
                return GetFuncType(child, funcTemplate, cbTemplate, gparams, gIndex + 1);
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

        private static IUnityMethod CreateUnityMethod(MethodInfo method)
        {
            var retType = method.ReturnType;
            var args = method.GetParameters();
            var argc = args.Length;

            Type unityMethodType, cbType;

            if (retType != typeof(void))
            {
                var gparams = gparamsCache[argc + 1];
                for (int i = 0; i < argc; ++i)
                    gparams[i] = args[i].ParameterType;
                gparams[argc] = retType;

                var (funcTemplate, cbTemplate) = funcTypeMap[argc];
                (unityMethodType, cbType) = GetFuncType(funcRoot, funcTemplate, cbTemplate, gparams, 0);
            }
            else
            {
                var (actionTemplate, cbTemplate) = actionTypeMap[argc];
                if (argc == 0)
                    (unityMethodType, cbType) = (actionTemplate, cbTemplate);
                else
                {
                    var gparams = gparamsCache[argc];
                    for (int i = 0; i < argc; ++i)
                        gparams[i] = args[i].ParameterType;

                    (unityMethodType, cbType) = GetFuncType(actionRoot, actionTemplate, cbTemplate, gparams, 0);
                }
            }

            var obj = Activator.CreateInstance(unityMethodType) as IUnityMethod;
            var cb = Delegate.CreateDelegate(cbType, null, method);

            if (obj is IUnityMethodFromDelegate umd)
            {
                umd.SetDelegate(cb);
            }
            else
            {
            }

            return obj;
        }

    }
}


