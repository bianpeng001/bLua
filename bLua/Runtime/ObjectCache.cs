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
// 2021年5月20日, 边蓬
//

using System;

namespace bLua
{
    //
    // 值类型需要装箱, 不然我都不知道如何改回去
    // 要不然值类型的数据, 修改不到原来的内存里
    // 实际只有struct, 需要这样处理
    //
    public class Box<T> /*where T : struct*/
    {
        public T value;

        public static implicit operator Box<T>(T value)
        {
            return new Box<T>() { value = value };
        }
    }

    //
    // object的交换区, 把这个做了, 就可以传object了, 注意要把setmetatable标正确
    // 只要一个entry, 只对应lua那边一个table, 那引用关系就是安全的
    // table用的数组形式存储 obj = { [1]=objHandle }, 所以内存占用也不大
    //
    public class ObjectCache
    {
        public struct Entry
        {
            public object value;

            // 下一个位置, 用来串联的, 但是为了节省空间, 当next没用的时候, 就存了特殊值
            // -1: index的末尾, 不能用
            // -2: 已分配
            public int next;

            // 这个会有需求的, 我坚信
            public bool isLive => next == -2;
        }

        // 空闲队列
        private int freeIndex = -1;
        // 可以分配的位置, 这个肯定是递增的, 从1开始, 用这个来跳过0位置
        private int allocIndex = 1;

        // 回收队列, 待回收的数量, 死亡队列
        private int killIndex = -1, killCount = 0, deadIndex = -1;
        private const int ALLOC_SIZE = 2048;
        private Entry[] cache = new Entry[ALLOC_SIZE];

        // objHandle 就是下标
        public object GetObject(int objHandle)
        {
            return cache[objHandle].value;
        }

        public int Add(object value)
        {
            if (value == null)
                throw new Exception();

            // 最终的objHandle, 是一个handle
            // 切记, 不要在c#端做复制objHandle的操作, 让lua那边去进行引用关系的, 好正确gc
            int objHandle;

            if (freeIndex >= 0)
            {
                objHandle = freeIndex;
                freeIndex = cache[objHandle].next;
            }
            else
            {
                // never happened
                if (allocIndex > cache.Length)
                    throw new Exception();

                if (allocIndex == cache.Length)
                {
                    // 这里要重新分配
                    var buf = new Entry[cache.Length + ALLOC_SIZE];
                    new Memory<Entry>(cache).CopyTo(new Memory<Entry>(buf));
                    cache = buf;
                    //allocIndex = cache.Length;
                }
                objHandle = allocIndex++;
            }

            cache[objHandle].value = value;
            cache[objHandle].next = -2;

            return objHandle;
        }

        private const int KillQueueSize = 16;

        public void Free(int index)
        {
            // 清空
            cache[index].next = killIndex;
            cache[index].value = null;

            // 加到死亡队列
            killIndex = index;
            ++killCount;

            // 死亡列表超过阈值, 则先清理一半的数据, 避免立刻清理, 立刻分配出来
            if (killCount >= KillQueueSize)
            {
                // 首次hellIndex是负数, 不会产生实际的销毁
                // 且由于, 这里是单向队列, 只能访问到下一个, 无法获得上一个,
                // 所以, 只能从下一个开始清空, 所以, 首次清理的时候, 是(DeadQueueSize - 1)项
                if (deadIndex >= 0)
                {
                    var curr = cache[deadIndex].next;
                    cache[deadIndex].next = -1;

                    while (curr >= 0)
                    {
                        var next = cache[curr].next;
                        cache[curr].next = freeIndex;
                        freeIndex = curr;
                        curr = next;
                    }
                }

                deadIndex = killIndex;
                killCount = 0;
            }
        }

    }
}


