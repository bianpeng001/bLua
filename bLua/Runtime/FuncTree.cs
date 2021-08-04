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
// 2021年5月11日, 边蓬
//
using System;
using System.Collections.Generic;
using System.Reflection;

namespace bLua
{
    //
    //
    //
    public static partial class AutoWrap
    {

        // 减少内存分配, 预分配的一些参数模版
        // 用来做泛型参数的
        private static readonly Type[][] gparamsCache;

        // 函数的类型, 映射
        private static readonly (Type, Type)[] funcTypeMap, actionTypeMap;

        //
        // 这里用来缓存类型, 避免同类型的生成多个类型, 节约内存
        //
        public class FuncTree
        {
            // 泛型参数, 某个
            public readonly Type argType;

            public FuncTree(Type argType)
            {
                this.argType = argType;
            }

            public List<FuncTree> childList;

            // 缓存的类型, 回调类型
            public Type funcType, cbType;
        }

        private static readonly FuncTree
            funcRoot = new FuncTree(null),
            actionRoot = new FuncTree(null);

        // 根据泛型参数, 获取缓存好的func, cb类型
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

        // 创建一个wrap函数实例
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

            // 创建一个wrap的实例
            var obj = Activator.CreateInstance(unityMethodType) as IUnityMethod;
            // 关键代码, 就这一行
            // 实际的cb的实例
            var cb = Delegate.CreateDelegate(cbType, null, method);

            // 还是用了反射, 省点代码生成, 而且就反射这一次, 性能总还行吧
            // unityMethodType.GetField("cb").SetValue(obj, cb);
            // 反射去掉吧, 性能好一点点
            if (obj is IUnityMethodFromDelegate umd)
            {
                //(obj as IUnityMethodFromDelegate).SetDelegate(cb);
                umd.SetDelegate(cb);
            }
            else
            {
                //unityMethodType.GetField("cb").SetValue(obj, cb);
            }

            return obj;
        }

    }
}


