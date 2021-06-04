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
 * 2021年5月30日, 边蓬
 */

using UnityEngine;

namespace bLua
{
    public class Example02 : LuaBehaviour
    {
        private static Example02 instance;

        void Awake()
        {
            instance = this;

            Application.targetFrameRate = 60;

            var state = LuaClient.State;
            Cs2Lua.Init(state, "Cs2Lua.lua");
            Cs2Lua.SendMessage("SayHello", "hello", 1234);

            Load(state);
        }

        void Update()
        {
            if (onUpdate != null)
                onUpdate.Call();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Cs2Lua.Clean();
        }

    }
}

