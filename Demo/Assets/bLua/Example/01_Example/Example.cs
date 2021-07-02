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
using UnityEngine;

namespace bLua
{
    public class Example : MonoBehaviour
    {
        private static Example instance;

        private void Awake()
        {
            instance = this;

            Application.targetFrameRate = 60;

            var state = LuaClient.State;
            Debug.Log("init lua ok");
            state.DoString("print(1234, nil, 4321.123)");

            (int, int) a = (1, 2);
            var (x, y) = a;
            Debug.Log($"{a} {x} {y}");

            state.DoFile("Test.lua");

            using (var tbl = state.Require("Test2.lua"))
            {
                var tblX = tbl.GetField<int>("x");
                Debug.Log($"x: {tblX}");

                using (var func = tbl.GetFunction("SayHello"))
                {
                    func.Prepare();
                    func.Execute(0, 1);
                    var ret = AutoWrap.TypeTrait<int>.pull(state, -1);
                    func.Cleanup();
                    Debug.Log($"ret: {ret}");

                    var ret2 = func.Call<int>();
                    Debug.Log($"ret: {ret2}");
                }

                using(var func = tbl.GetFunction("Add"))
                {
                    var sum = func.Call<int, int, int>(123, 321);
                    Debug.Log($"sum: {sum}");
                }
            }
        }

        public static int Add(int a, int b)
        {
            var result =  a + b;
            Debug.Log($"{a} + {b} = {result}");
            return result;
        }

        public static int Add(int a, int b, int c)
        {
            var result = a + b + c;
            Debug.Log($"{a} + {b} + {c} = {result}");
            return result;
        }

        public void SayHello(string message)
        {
            Debug.Log(message);
        }

        public void SayHello(string name, string message)
        {
            Debug.Log($"{name} {message}");
        }

        public static Example GetInstance()
        {
            return instance;
        }

        public string Name => gameObject.name;

        private int hp;
        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
            }
        }

        private static int time = 1021;
        public static int Time
        {
            get => time;
            set => time = value;
        }

        public static LuaDelegate GetDelegate()
        {
            return new LuaDelegate(AutoWrap.CreateFunc(
                (int a, int b, int c) => a + b + c
            ));
        }

        public static int[] GetIntArray()
        {
            return new int[] { 11, 22, 33, 44, 55 };
        }

        public static List<int> GetIntList()
        {
            return new List<int>{ 11, 22, 33, 44, 55 };
        }

        public static string[] GetStringArray()
        {
            return new string[] { "what", "is", "wrong" };
        }
    }

}



