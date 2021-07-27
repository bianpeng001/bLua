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
using System.Diagnostics;
using System.Text;

namespace bLua
{
    //
    //
    //
    public static class LogUtil
    {
        public enum LogLevel
        {
            Debug,
            Error,
        }

        public static Action<LogLevel, string> logCallback;
        public static string Sep = " ";

        static LogUtil()
        {
            logCallback = (level, message) =>
            {
                switch(level)
                {
                    case LogLevel.Error:
                        UnityEngine.Debug.LogError(message);
                        break;

                    default:
                        UnityEngine.Debug.Log(message);
                        break;
                }
            };
        }

        public static void PrintMessage(LogLevel level, string message)
        {
            logCallback?.Invoke(level, message);
        }

        private static readonly StringBuilder sb = new StringBuilder();

        public static void Print<T1>(LogLevel level, T1 arg1)
        {
            sb.Clear();
            sb.Append(arg1.ToString());

            var message = sb.ToString();
            PrintMessage(level, message);
        }

        public static void Print<T1, T2>(LogLevel level, T1 arg1, T2 arg2)
        {
            sb.Clear();
            sb.Append(arg1.ToString());
            sb.Append(Sep);
            sb.Append(arg2.ToString());

            var message = sb.ToString();
            PrintMessage(level, message);
        }

        public static void Print<T1, T2, T3>(LogLevel level, T1 arg1, T2 arg2, T3 arg3)
        {
            sb.Clear();
            sb.Append(arg1.ToString());
            sb.Append(Sep);
            sb.Append(arg2.ToString());
            sb.Append(Sep);
            sb.Append(arg3.ToString());

            var message = sb.ToString();
            PrintMessage(level, message);
        }

        public static void Debug(string message)
        {
            //UnityEngine.Debug.Log(message);
            PrintMessage(LogLevel.Debug, message);
        }

        public static void Error(string message)
        {
            //UnityEngine.Debug.LogError(message);
            PrintMessage(LogLevel.Error, message);
        }

        [Conditional("ENABLE_ASSERT")]
        public static void Assert(bool success)
        {
            Assert(success, "asset failed");
        }

        [Conditional("ENABLE_ASSERT")]
        public static void Assert(bool success, string message)
        {
            if (!success)
                throw new Exception(message);
        }
    }
}

