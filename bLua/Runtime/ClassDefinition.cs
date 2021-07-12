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
    // 一个类型定义
    //
    public class ClassDefinition
    {
        // 存一个lua端的ref, 是对应的lua的class的引用
        public LuaRef luaref = LuaLib.LUA_NOREF;

        // 记录fullname, 全局唯一
        public string name;

        // 类型, 基类, 功能扩展
        public Type type;
        public Type baseClass;

        // 不用支持interface, 完全用不着

        // 静态方法的帮助类, 这个是生成出来的
        public Type helpClass;
        // 两个, 就是有一个优先级, 可以方便的覆盖, 这个是手工写的
        public Type extClass;

        // 所有的静态method, help, help2, 以及自己这里
        public List<MethodInfo> methodList;
        
        // 用这个减少GC
        public readonly int classId;

        // 这里看上去没啥实际用途 , 先注掉
        //public List<PropertyInfo> propList;

        public ClassDefinition(int classId)
        {
            this.classId = classId;
        }
    }

}


