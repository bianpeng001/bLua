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


using System.Collections.Generic;

namespace bLua
{
    public static class Cs2Lua
    {
        private static int msgIdSeed = 0;
        private static readonly Dictionary<string, int> msgDict = new Dictionary<string, int>();

        private static void PushMessage(string message)
        {
            if (!msgDict.TryGetValue(message, out var msgId))
            {
                msgId = ++msgIdSeed;
                msgDict.Add(message, msgId);
                RegisterMessage(message, msgId);
            }
            AutoWrap.TypeTrait<int>.push(state, msgId);
        }

        private static void RegisterMessage(string message, int msgId)
        {
            register.BeginExecute();
            AutoWrap.TypeTrait<string>.push(state, message);
            AutoWrap.TypeTrait<int>.push(state, msgId);
            register.Execute(2, 0);
            register.EndExecute();
        }

        public static void SendMessage<T1>(string message)
        {
            send.BeginExecute();
            PushMessage(message);
            send.Execute(1, 0);
            send.EndExecute();
        }

        public static void SendMessage<T1>(string message, T1 t1)
        {
            send.BeginExecute();
            PushMessage(message);
            AutoWrap.TypeTrait<T1>.push(state, t1);
            send.Execute(2, 0);
            send.EndExecute();
        }

        public static void SendMessage<T1, T2>(string message, T1 t1, T2 t2)
        {
            send.BeginExecute();
            PushMessage(message);
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            send.Execute(3, 0);
            send.EndExecute();
        }

        public static void SendMessage<T1, T2, T3>(string message, T1 t1, T2 t2, T3 t3)
        {
            send.BeginExecute();
            PushMessage(message);
            AutoWrap.TypeTrait<T1>.push(state, t1);
            AutoWrap.TypeTrait<T2>.push(state, t2);
            AutoWrap.TypeTrait<T3>.push(state, t3);
            send.Execute(4, 0);
            send.EndExecute();
        }

        private static LuaTable cs2lua;
        private static LuaState state;
        private static LuaFunction send, register;

        public static void Init(LuaState astate, string path)
        {
            state = astate;

            cs2lua = state.Require(path);
            send = cs2lua.GetFunction("SendMessage");
            register = cs2lua.GetFunction("RegisterMessage");
        }

        public static void Clean()
        {
            if (send != null)
                send.Dispose();
            if (register != null)
                register.Dispose();
            if (cs2lua != null)
                cs2lua.Dispose();
        }

    }
}


