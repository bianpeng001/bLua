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
 * 2021年5月15日, 边蓬
 */

using System;
using System.Collections.Generic;
using System.Reflection;

namespace bLua
{
    public class LuaRegister
    {
        private readonly List<ClassDefinition> typeList = new List<ClassDefinition>();

        public void Add(string name, Type type, Type baseClass, Type helpClass)
        {
            typeList.Add(new ClassDefinition()
            {
                index = typeList.Count,
                name = name,
                type = type,
                baseClass = baseClass,
                helpClass = helpClass,
            });
        }

        public void Add(string name, Type type, Type extClass, Type baseClass, Type helpClass)
        {
            typeList.Add(new ClassDefinition()
            {
                index = typeList.Count,
                name = name,
                type = type,
                baseClass = baseClass,
                helpClass = helpClass,
                extClass = extClass,
            });
        }

        public ClassDefinition GetClass(string name)
        {
            var index = typeList.FindIndex(a => a.name == name);
            if (index < 0)
                return null;

            return typeList[index];
        }

        public ClassDefinition GetClass(Type type)
        {
            var index = typeList.FindIndex(a => a.type == type);
            if (index < 0)
                return null;

            return typeList[index];
        }

        public int FindAllMethods(
            ClassDefinition cls,
            string methodName,
            List<MethodInfo> methodList)
        {
            methodList.Clear();

            if (cls.methodList == null)
            {
                var flag = AutoWrap.StaticMemberFlag;
                cls.methodList = new List<MethodInfo>();
                if (cls.extClass != null)
                {
                    cls.methodList.AddRange(cls.extClass.GetMethods(flag));
                }
                cls.methodList.AddRange(cls.helpClass.GetMethods(flag));
                cls.methodList.AddRange(cls.type.GetMethods(flag));
            }

            for(int i = 0; i < cls.methodList.Count; ++i)
            {
                var method = cls.methodList[i];
                if (method.Name == methodName)
                    methodList.Add(method);
            }

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


