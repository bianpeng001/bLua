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
// 2021年5月15日, 边蓬
//

using System;
using System.Collections.Generic;
using System.Reflection;

namespace bLua
{
    //
    // 注册表: 类, 函数
    //
    public class LuaRegister
    {
        private readonly List<ClassDefinition> typeList = new List<ClassDefinition>() { null };

        public void Add(string name, Type type, Type baseClass, Type helpClass)
        {
            typeList.Add(new ClassDefinition(typeList.Count)
            {
                name = name,
                type = type,
                baseClass = baseClass,
                helpClass = helpClass,
            });
        }

        public void Add(string name, Type type, Type extClass, Type baseClass, Type helpClass)
        {
            typeList.Add(new ClassDefinition(typeList.Count)
            {
                name = name,
                type = type,
                baseClass = baseClass,
                helpClass = helpClass,
                extClass = extClass,
            });
        }

        public ClassDefinition GetClass(string name)
        {
            for (int i = 1; i < typeList.Count; ++i)
            {
                var cls = typeList[i];
                if (cls.name == name)
                    return cls;
            }
            return null;
        }

        public ClassDefinition GetClass(int classId)
        {
            return typeList[classId];
        }

        // 做一些cache, 提高速度, 反正类型还是有限的
        private readonly Dictionary<Type, ClassDefinition> type2clsCache = new Dictionary<Type, ClassDefinition>();

        public ClassDefinition GetClass(Type type)
        {
            ClassDefinition cls;
            if (type2clsCache.TryGetValue(type, out cls))
                return cls;

            for (int i = 1; i < typeList.Count; ++i)
            {
                cls = typeList[i];
                if (cls.type == type)
                {
                    type2clsCache[type] = cls;
                    return cls;
                }
            }
            return null;
        }

        // 根据名字找方法
        // TODO: 这个查找方式还能改, 并且最好再释放一下
        public int FindAllMethods(
            ClassDefinition cls,
            string methodName,
            List<MethodInfo> methodList)
        {
            methodList.Clear();

            // 这也是一个lazy操作, 用到了再去初始化出来
            if (cls.methodList == null)
            {
                var flag = AutoWrap.StaticMemberFlag;
                cls.methodList = new List<MethodInfo>();
                if (cls.extClass != null)
                    cls.methodList.AddRange(cls.extClass.GetMethods(flag));
                cls.methodList.AddRange(cls.helpClass.GetMethods(flag));
                cls.methodList.AddRange(cls.type.GetMethods(flag));
            }

            for (int i = 0; i < cls.methodList.Count; ++i)
            {
                var method = cls.methodList[i];
                if (method.Name == methodName)
                    methodList.Add(method);
            }

            // 没找到, 则往基类再查一下
            if (methodList.Count == 0)
            {
                var baseClass = cls.baseClass;
                if (baseClass == null)
                {
                    if (cls.type == typeof(object))
                        return 0;
                    baseClass = typeof(object);
                }

                return FindAllMethods(
                    GetClass(baseClass),
                    methodName,
                    methodList);
            }

            return methodList.Count;
        }

    }

}


