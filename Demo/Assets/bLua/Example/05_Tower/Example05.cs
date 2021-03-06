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


using UnityEngine;

namespace bLua
{
    public class Example05 : LuaBehaviour
    {
        private static Example05 instance;

        private MoveSystem moveSystem;

        void Awake()
        {
            Application.targetFrameRate = 60;
            instance = this;
            moveSystem = new MoveSystem();

            var state = LuaClient.State;
            Cs2Lua.Init(state, "Cs2Lua.lua");
            LoadModule(state);

            module.SetField("moveSystem", moveSystem);

            if (onAwake != null)
                onAwake.Call();
        }

        void Update()
        {
            if (onUpdate != null)
                onUpdate.Call();
        }

        

    }
}


