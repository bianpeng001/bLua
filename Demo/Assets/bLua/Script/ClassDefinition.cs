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
    public class ClassDefinition
    {
        public LuaRef luaref = LuaLib.LUA_NOREF;

        public string name;

        public Type type;
        public Type baseClass;


        public Type helpClass;
        public Type extClass;

        public List<MethodInfo> methodList;
        
        public readonly int classId;


        public ClassDefinition(int classId)
        {
            this.classId = classId;
        }
    }

}


