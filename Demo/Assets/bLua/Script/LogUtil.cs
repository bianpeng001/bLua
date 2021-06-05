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
    public static class LogUtil
    {
        public enum LogLevel
        {
            Debug,
            Error,
        }

        public static Action<LogLevel, string> logCallback;

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

        public static void Debug(string message)
        {
            logCallback(LogLevel.Debug, message);
        }

        public static void Error(string message)
        {
            logCallback(LogLevel.Error, message);
        }

        public static void Assert(bool success, string message)
        {
            if (!success)
                throw new Exception(message);
        }
    }
}
