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
 * 2021年5月26日, 边蓬
 */
using System;

namespace bLua
{
    //
    // 注入到lua那边去
    // TODO: 刚才觉得注入一个常量过去就有用了, 但是想了想还是不行
    // 会改的才有用, 如果是gameObject之类的, 是可以注入过去的
    //
    public class LuaFieldAttribute : Attribute
    {
        public bool nowrap = false;
    }

}
