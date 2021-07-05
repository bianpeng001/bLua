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

namespace bLua
{
    public class Box<T> /*where T : struct*/
    {
        public T value;

        public static implicit operator Box<T>(T value)
        {
            return new Box<T>() { value = value };
        }
    }

    public class ObjectCache
    {
        public struct Entry
        {
            public object value;

            public int next;

            public bool isLive => next == -2;
        }

        private int freeIndex = -1;
        private int allocIndex = 1;

        private int killIndex = -1, killCount = 0, deadIndex = -1;
        private const int ALLOC_SIZE = 2048;
        private Entry[] cache = new Entry[ALLOC_SIZE];

        public object GetObject(int objHandle)
        {
            return cache[objHandle].value;
        }

        public int Add(object value)
        {
            if (value == null)
                throw new Exception();

            int objHandle;

            if (freeIndex >= 0)
            {
                objHandle = freeIndex;
                freeIndex = cache[objHandle].next;
            }
            else
            {
                if (allocIndex > cache.Length)
                    throw new Exception();

                if (allocIndex == cache.Length)
                {
                    var buf = new Entry[cache.Length + ALLOC_SIZE];
                    new Memory<Entry>(cache).CopyTo(new Memory<Entry>(buf));
                    cache = buf;
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
            cache[index].next = killIndex;
            cache[index].value = null;

            killIndex = index;
            ++killCount;

            if (killCount >= KillQueueSize)
            {
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


