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
// 2021年5月26日, 边蓬
//

using System;
using static bLua.AutoWrap;

namespace bLua
{
    //
    // 一个delegate的实现, 这个比较复杂, 哈哈, 见证奇迹的时刻
    // 隐隐有跟autowrap那边统一的意思, 但看下来还是现在记录一个int的方法省一些
    // 这边的需要占的内存大, 弄1w个, 有点舍不得
    // 这里是一个对象, 无论如何为了那个meta信息, 也要来一个对象
    // 
    // 似乎做完了, 我也没想到, 竟然会如此简单, 编辑器crash了几次, 但代码还是很少的
    // 核心代码:
    // bLua.LuaDelegate.__call = CallLuaDelegate or function(obj, ...)
    //     print(obj, ...)
    // end
    //
    // 最后, 我直接把IUnityMethod传给lua使用了
    [Obsolete]
    public class LuaDelegate
    {
        private readonly IUnityMethod method;

        public LuaDelegate(IUnityMethod method)
        {
            this.method = method;
        }

        internal IUnityMethod Method => method;
    }
}



