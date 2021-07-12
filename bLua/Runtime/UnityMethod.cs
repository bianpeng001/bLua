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

#define ENABLE_ASSERT

//
// 2021年5月21日, 边蓬
//
using System;
using System.Collections.Generic;
using System.Reflection;

namespace bLua
{
    //
    // 方法的定义
    //
    public static partial class AutoWrap
    {
        // func...
        public class Func<Result> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Func<Result> cb;

            public int Call(IntPtr L)
            {
                var result = cb();
                TypeTrait<Result>.push(L, result);

                return TypeTrait<Result>.retCount;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Func<Result>)del;
            }
        }

        public class Func<T1, Result> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Func<T1, Result> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -1);

                var result = cb(t1);
                TypeTrait<Result>.push(L, result);

                return TypeTrait<Result>.retCount;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Func<T1, Result>)del;
            }
        }

        public class Func<T1, T2, Result> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Func<T1, T2, Result> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -2);
                var t2 = TypeTrait<T2>.pull(L, -1);

                var result = cb(t1, t2);
                TypeTrait<Result>.push(L, result);

                return TypeTrait<Result>.retCount;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Func<T1, T2, Result>)del;
            }
        }

        public class Func<T1, T2, T3, Result> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Func<T1, T2, T3, Result> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -3);
                var t2 = TypeTrait<T2>.pull(L, -2);
                var t3 = TypeTrait<T3>.pull(L, -1);

                var result = cb(t1, t2, t3);
                TypeTrait<Result>.push(L, result);

                return TypeTrait<Result>.retCount;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Func<T1, T2, T3, Result>)del;
            }
        }

        public class Func<T1, T2, T3, T4, Result> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Func<T1, T2, T3, T4, Result> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -4);
                var t2 = TypeTrait<T2>.pull(L, -3);
                var t3 = TypeTrait<T3>.pull(L, -2);
                var t4 = TypeTrait<T4>.pull(L, -1);

                var result = cb(t1, t2, t3, t4);
                TypeTrait<Result>.push(L, result);

                return TypeTrait<Result>.retCount;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Func<T1, T2, T3, T4, Result>)del;
            }
        }

        public class Func<T1, T2, T3, T4, T5, Result> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Func<T1, T2, T3, T4, T5, Result> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);
                LogUtil.Assert(TypeTrait<T5>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -5);
                var t2 = TypeTrait<T2>.pull(L, -4);
                var t3 = TypeTrait<T3>.pull(L, -3);
                var t4 = TypeTrait<T4>.pull(L, -2);
                var t5 = TypeTrait<T5>.pull(L, -1);

                var result = cb(t1, t2, t3, t4, t5);
                TypeTrait<Result>.push(L, result);

                return TypeTrait<Result>.retCount;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Func<T1, T2, T3, T4, T5, Result>)del;
            }
        }

        public class Func<T1, T2, T3, T4, T5, T6, Result> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Func<T1, T2, T3, T4, T5, T6, Result> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);
                LogUtil.Assert(TypeTrait<T5>.pull != null);
                LogUtil.Assert(TypeTrait<T6>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -6);
                var t2 = TypeTrait<T2>.pull(L, -5);
                var t3 = TypeTrait<T3>.pull(L, -4);
                var t4 = TypeTrait<T4>.pull(L, -3);
                var t5 = TypeTrait<T5>.pull(L, -2);
                var t6 = TypeTrait<T6>.pull(L, -1);

                var result = cb(t1, t2, t3, t4, t5, t6);
                TypeTrait<Result>.push(L, result);

                return TypeTrait<Result>.retCount;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Func<T1, T2, T3, T4, T5, T6, Result>)del;
            }
        }

        public class Func<T1, T2, T3, T4, T5, T6, T7, Result> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Func<T1, T2, T3, T4, T5, T6, T7, Result> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);
                LogUtil.Assert(TypeTrait<T5>.pull != null);
                LogUtil.Assert(TypeTrait<T6>.pull != null);
                LogUtil.Assert(TypeTrait<T7>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -7);
                var t2 = TypeTrait<T2>.pull(L, -6);
                var t3 = TypeTrait<T3>.pull(L, -5);
                var t4 = TypeTrait<T4>.pull(L, -4);
                var t5 = TypeTrait<T5>.pull(L, -3);
                var t6 = TypeTrait<T6>.pull(L, -2);
                var t7 = TypeTrait<T7>.pull(L, -1);

                var result = cb(t1, t2, t3, t4, t5, t6, t7);
                TypeTrait<Result>.push(L, result);

                return TypeTrait<Result>.retCount;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Func<T1, T2, T3, T4, T5, T6, T7, Result>)del;
            }
        }

        public class Func<T1, T2, T3, T4, T5, T6, T7, T8, Result> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Func<T1, T2, T3, T4, T5, T6, T7, T8, Result> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);
                LogUtil.Assert(TypeTrait<T5>.pull != null);
                LogUtil.Assert(TypeTrait<T6>.pull != null);
                LogUtil.Assert(TypeTrait<T7>.pull != null);
                LogUtil.Assert(TypeTrait<T8>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -8);
                var t2 = TypeTrait<T2>.pull(L, -7);
                var t3 = TypeTrait<T3>.pull(L, -6);
                var t4 = TypeTrait<T4>.pull(L, -5);
                var t5 = TypeTrait<T5>.pull(L, -4);
                var t6 = TypeTrait<T6>.pull(L, -3);
                var t7 = TypeTrait<T7>.pull(L, -2);
                var t8 = TypeTrait<T8>.pull(L, -1);

                var result = cb(t1, t2, t3, t4, t5, t6, t7, t8);
                TypeTrait<Result>.push(L, result);

                return TypeTrait<Result>.retCount;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Func<T1, T2, T3, T4, T5, T6, T7, T8, Result>)del;
            }
        }

        public class Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Result> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Result> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);
                LogUtil.Assert(TypeTrait<T5>.pull != null);
                LogUtil.Assert(TypeTrait<T6>.pull != null);
                LogUtil.Assert(TypeTrait<T7>.pull != null);
                LogUtil.Assert(TypeTrait<T8>.pull != null);
                LogUtil.Assert(TypeTrait<T9>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -9);
                var t2 = TypeTrait<T2>.pull(L, -8);
                var t3 = TypeTrait<T3>.pull(L, -7);
                var t4 = TypeTrait<T4>.pull(L, -6);
                var t5 = TypeTrait<T5>.pull(L, -5);
                var t6 = TypeTrait<T6>.pull(L, -4);
                var t7 = TypeTrait<T7>.pull(L, -3);
                var t8 = TypeTrait<T8>.pull(L, -2);
                var t9 = TypeTrait<T9>.pull(L, -1);

                var result = cb(t1, t2, t3, t4, t5, t6, t7, t8, t9);
                TypeTrait<Result>.push(L, result);

                return TypeTrait<Result>.retCount;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Result>)del;
            }
        }

        public class Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Result> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Result> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);
                LogUtil.Assert(TypeTrait<T5>.pull != null);
                LogUtil.Assert(TypeTrait<T6>.pull != null);
                LogUtil.Assert(TypeTrait<T7>.pull != null);
                LogUtil.Assert(TypeTrait<T8>.pull != null);
                LogUtil.Assert(TypeTrait<T9>.pull != null);
                LogUtil.Assert(TypeTrait<T10>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -10);
                var t2 = TypeTrait<T2>.pull(L, -9);
                var t3 = TypeTrait<T3>.pull(L, -8);
                var t4 = TypeTrait<T4>.pull(L, -7);
                var t5 = TypeTrait<T5>.pull(L, -6);
                var t6 = TypeTrait<T6>.pull(L, -5);
                var t7 = TypeTrait<T7>.pull(L, -4);
                var t8 = TypeTrait<T8>.pull(L, -3);
                var t9 = TypeTrait<T9>.pull(L, -2);
                var t10 = TypeTrait<T10>.pull(L, -1);

                var result = cb(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
                TypeTrait<Result>.push(L, result);

                return TypeTrait<Result>.retCount;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Result>)del;
            }
        }

        // action...
        public class Action : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Action cb;

            public int Call(IntPtr L)
            {
                cb();

                return 0;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Action)del;
            }
        }

        public class Action<T1> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Action<T1> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -1);

                cb(t1);

                return 0;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Action<T1>)del;
            }
        }

        public class Action<T1, T2> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Action<T1, T2> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -2);
                var t2 = TypeTrait<T2>.pull(L, -1);

                cb(t1, t2);

                return 0;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Action<T1, T2>)del;
            }
        }

        public class Action<T1, T2, T3> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Action<T1, T2, T3> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -3);
                var t2 = TypeTrait<T2>.pull(L, -2);
                var t3 = TypeTrait<T3>.pull(L, -1);

                cb(t1, t2, t3);

                return 0;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Action<T1, T2, T3>)del;
            }
        }

        public class Action<T1, T2, T3, T4> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Action<T1, T2, T3, T4> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -4);
                var t2 = TypeTrait<T2>.pull(L, -3);
                var t3 = TypeTrait<T3>.pull(L, -2);
                var t4 = TypeTrait<T4>.pull(L, -1);

                cb(t1, t2, t3, t4);

                return 0;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Action<T1, T2, T3, T4>)del;
            }
        }

        public class Action<T1, T2, T3, T4, T5> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Action<T1, T2, T3, T4, T5> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);
                LogUtil.Assert(TypeTrait<T5>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -5);
                var t2 = TypeTrait<T2>.pull(L, -4);
                var t3 = TypeTrait<T3>.pull(L, -3);
                var t4 = TypeTrait<T4>.pull(L, -2);
                var t5 = TypeTrait<T5>.pull(L, -1);

                cb(t1, t2, t3, t4, t5);

                return 0;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Action<T1, T2, T3, T4, T5>)del;
            }
        }

        public class Action<T1, T2, T3, T4, T5, T6> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Action<T1, T2, T3, T4, T5, T6> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);
                LogUtil.Assert(TypeTrait<T5>.pull != null);
                LogUtil.Assert(TypeTrait<T6>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -6);
                var t2 = TypeTrait<T2>.pull(L, -5);
                var t3 = TypeTrait<T3>.pull(L, -4);
                var t4 = TypeTrait<T4>.pull(L, -3);
                var t5 = TypeTrait<T5>.pull(L, -2);
                var t6 = TypeTrait<T6>.pull(L, -1);

                cb(t1, t2, t3, t4, t5, t6);

                return 0;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Action<T1, T2, T3, T4, T5, T6>)del;
            }
        }

        public class Action<T1, T2, T3, T4, T5, T6, T7> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Action<T1, T2, T3, T4, T5, T6, T7> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);
                LogUtil.Assert(TypeTrait<T5>.pull != null);
                LogUtil.Assert(TypeTrait<T6>.pull != null);
                LogUtil.Assert(TypeTrait<T7>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -7);
                var t2 = TypeTrait<T2>.pull(L, -6);
                var t3 = TypeTrait<T3>.pull(L, -5);
                var t4 = TypeTrait<T4>.pull(L, -4);
                var t5 = TypeTrait<T5>.pull(L, -3);
                var t6 = TypeTrait<T6>.pull(L, -2);
                var t7 = TypeTrait<T7>.pull(L, -1);

                cb(t1, t2, t3, t4, t5, t6, t7);

                return 0;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Action<T1, T2, T3, T4, T5, T6, T7>)del;
            }
        }

        public class Action<T1, T2, T3, T4, T5, T6, T7, T8> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Action<T1, T2, T3, T4, T5, T6, T7, T8> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);
                LogUtil.Assert(TypeTrait<T5>.pull != null);
                LogUtil.Assert(TypeTrait<T6>.pull != null);
                LogUtil.Assert(TypeTrait<T7>.pull != null);
                LogUtil.Assert(TypeTrait<T8>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -8);
                var t2 = TypeTrait<T2>.pull(L, -7);
                var t3 = TypeTrait<T3>.pull(L, -6);
                var t4 = TypeTrait<T4>.pull(L, -5);
                var t5 = TypeTrait<T5>.pull(L, -4);
                var t6 = TypeTrait<T6>.pull(L, -3);
                var t7 = TypeTrait<T7>.pull(L, -2);
                var t8 = TypeTrait<T8>.pull(L, -1);

                cb(t1, t2, t3, t4, t5, t6, t7, t8);

                return 0;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Action<T1, T2, T3, T4, T5, T6, T7, T8>)del;
            }
        }

        public class Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);
                LogUtil.Assert(TypeTrait<T5>.pull != null);
                LogUtil.Assert(TypeTrait<T6>.pull != null);
                LogUtil.Assert(TypeTrait<T7>.pull != null);
                LogUtil.Assert(TypeTrait<T8>.pull != null);
                LogUtil.Assert(TypeTrait<T9>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -9);
                var t2 = TypeTrait<T2>.pull(L, -8);
                var t3 = TypeTrait<T3>.pull(L, -7);
                var t4 = TypeTrait<T4>.pull(L, -6);
                var t5 = TypeTrait<T5>.pull(L, -5);
                var t6 = TypeTrait<T6>.pull(L, -4);
                var t7 = TypeTrait<T7>.pull(L, -3);
                var t8 = TypeTrait<T8>.pull(L, -2);
                var t9 = TypeTrait<T9>.pull(L, -1);

                cb(t1, t2, t3, t4, t5, t6, t7, t8, t9);

                return 0;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)del;
            }
        }

        public class Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IUnityMethod, IUnityMethodFromDelegate
        {
            public System.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> cb;

            public int Call(IntPtr L)
            {
                LogUtil.Assert(TypeTrait<T1>.pull != null);
                LogUtil.Assert(TypeTrait<T2>.pull != null);
                LogUtil.Assert(TypeTrait<T3>.pull != null);
                LogUtil.Assert(TypeTrait<T4>.pull != null);
                LogUtil.Assert(TypeTrait<T5>.pull != null);
                LogUtil.Assert(TypeTrait<T6>.pull != null);
                LogUtil.Assert(TypeTrait<T7>.pull != null);
                LogUtil.Assert(TypeTrait<T8>.pull != null);
                LogUtil.Assert(TypeTrait<T9>.pull != null);
                LogUtil.Assert(TypeTrait<T10>.pull != null);

                var t1 = TypeTrait<T1>.pull(L, -10);
                var t2 = TypeTrait<T2>.pull(L, -9);
                var t3 = TypeTrait<T3>.pull(L, -8);
                var t4 = TypeTrait<T4>.pull(L, -7);
                var t5 = TypeTrait<T5>.pull(L, -6);
                var t6 = TypeTrait<T6>.pull(L, -5);
                var t7 = TypeTrait<T7>.pull(L, -4);
                var t8 = TypeTrait<T8>.pull(L, -3);
                var t9 = TypeTrait<T9>.pull(L, -2);
                var t10 = TypeTrait<T10>.pull(L, -1);

                cb(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);

                return 0;
            }

            public void SetDelegate(Delegate del)
            {
                cb = (System.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)del;
            }
        }

        //
        // overload的解决方法
        // 同名函数, 必须以参数个数来区分. 枚举当int处理, 所以也是无法识别的
        //
        public class OverloadResolver : IUnityMethod
        {
            private (MethodInfo method, int argc, IUnityMethod wrappedMethod)[] dispatch;

            public OverloadResolver(List<MethodInfo> methodList)
            {
                // TODO: 这里的检查加多一些, 见到编辑期
                dispatch = new (MethodInfo, int, IUnityMethod)[methodList.Count];
                methodList.Sort((a, b) => a.GetParameters().Length - b.GetParameters().Length);

                for (int i = 0; i < methodList.Count; ++i)
                {
                    var method = methodList[i];
                    dispatch[i].method = method;
                    dispatch[i].argc = method.GetParameters().Length;
                    if (i > 0 && dispatch[i - 1].argc == dispatch[i].argc)
                    {
                        LogUtil.Debug("overload on args count failed");
                    }
                }
            }

            public int Call(IntPtr L)
            {
                IUnityMethod wrappedMethod = null;

                var argumentCount = LuaLib.lua_gettop(L) - 1;

                for (int i = 0; i < dispatch.Length; ++i)
                {
                    if (dispatch[i].argc == argumentCount)
                    {
                        if (dispatch[i].wrappedMethod != null)
                            wrappedMethod = dispatch[i].wrappedMethod;
                        else
                        {
                            wrappedMethod = CreateUnityMethod(dispatch[i].method);
                            dispatch[i].method = null;
                            dispatch[i].wrappedMethod = wrappedMethod;
                        }
                        break;
                    }
                }
                if (wrappedMethod == null)
                {
                    LogUtil.Error("no matched method");
                    return 0;
                }

                return wrappedMethod.Call(L);
            }
        }

        // 辅助方法, 减少点代码
        // func
        public static IUnityMethod CreateFunc<TResult>(System.Func<TResult> cb)
        {
            return new Func<TResult>() { cb = cb };
        }

        public static IUnityMethod CreateFunc<T1, TResult>(System.Func<T1, TResult> cb)
        {
            return new Func<T1, TResult>() { cb = cb };
        }

        public static IUnityMethod CreateFunc<T1, T2, TResult>(System.Func<T1, T2, TResult> cb)
        {
            return new Func<T1, T2, TResult>() { cb = cb };
        }

        public static IUnityMethod CreateFunc<T1, T2, T3, TResult>(System.Func<T1, T2, T3, TResult> cb)
        {
            return new Func<T1, T2, T3, TResult>() { cb = cb };
        }

        // action
        public static IUnityMethod CreateAction(System.Action cb)
        {
            return new Action() { cb = cb };
        }

        public static IUnityMethod CreateAction<T1>(System.Action<T1> cb)
        {
            return new Action<T1>() { cb = cb };
        }

        public static IUnityMethod CreateAction<T1, T2>(System.Action<T1, T2> cb)
        {
            return new Action<T1, T2>() { cb = cb };
        }

        public static IUnityMethod CreateAction<T1, T2, T3>(System.Action<T1, T2, T3> cb)
        {
            return new Action<T1, T2, T3>() { cb = cb };
        }
    }
}

