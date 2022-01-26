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
    public class LuaRegister
    {
        private readonly List<Assembly> assemblyList = new List<Assembly>();

        public void AddAssembly(Assembly assembly)
        {
            assemblyList.Add(assembly);
        }

        private readonly List<ClassDefinition> typeList = new List<ClassDefinition>() { null };

        public void Add(string name, Type type, Type baseClass, Type helpClass)
        {
            Add(name, type, null, baseClass, helpClass);
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

            var dyncls = MakeDynClass(name);
            if (dyncls != null)
            {
                return dyncls;
            }

            return null;
        }

        private ClassDefinition MakeDynClass(string fullname)
        {
            for (int i = 0; i < assemblyList.Count; ++i)
            {
                var assembly = assemblyList[i];
                var type = assembly.GetType(fullname);
                if (type != null)
                {
                    Add(fullname, type, null, null);
                    var cls = typeList[typeList.Count - 1];
                    cls.isDynClass = true;
                    return cls;
                }
            }

            return null;
        }

        public ClassDefinition GetClass(int classId)
        {
            return typeList[classId];
        }

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

        public int FindAllMethods(
            ClassDefinition cls,
            string methodName,
            List<MethodInfo> matchedList)
        {
            matchedList.Clear();

            if (cls.methodList == null)
            {
                var flag = AutoWrap.StaticMemberFlag;
                cls.methodList = new List<MethodInfo>();
                if (cls.extClass != null)
                    cls.methodList.AddRange(cls.extClass.GetMethods(flag));
                if (cls.helpClass != null)
                    cls.methodList.AddRange(cls.helpClass.GetMethods(flag));

                cls.methodList.AddRange(cls.type.GetMethods(flag));
            }

            if (cls.isDynClass && cls.dynMethodList == null)
            {
                var flag = BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.DeclaredOnly;

                cls.dynMethodList = new List<MethodInfo>();
                cls.dynMethodList.AddRange(cls.type.GetMethods(flag));
            }

            static void FindMatched(List<MethodInfo> aList, string methodName, List<MethodInfo> matched)
            {
                if (aList == null)
                    return;

                for (int i = 0; i < aList.Count; ++i)
                {
                    var m = aList[i];
                    if (m.Name == methodName)
                        matched.Add(m);
                }
            }

            FindMatched(cls.methodList, methodName, matchedList);

            if (cls.isDynClass)
                FindMatched(cls.dynMethodList, methodName, matchedList);

            if (matchedList.Count == 0)
            {
                var baseClass = cls.baseClass;
                if (baseClass == null)
                {
                    if (cls.type == typeof(object))
                        return 0;
                    baseClass = typeof(object);
                }

                FindAllMethods(
                    GetClass(baseClass),
                    methodName,
                    matchedList);
            }

            return matchedList.Count;
        }

    }

}


