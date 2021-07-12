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

namespace bLua
{
    //
    // 扩展方法, 就是为了让和List保持一致
    //
    public static class ArrayEx<T>
    {
        public static int get_Count(T[] _this) => _this.Length;

        public static T get_Item(T[] _this, int index) => _this[index];

        public static void set_Item(T[] _this, int index, T value) => _this[index] = value;
    }
}
