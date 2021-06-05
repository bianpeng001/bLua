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

        private Camera mainCamera;
        public Camera GetMainCamera()
        {
            if (mainCamera == null)
                mainCamera = Camera.main;
            return mainCamera;
        }

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

        public Vector3 GetFloorPoint()
        {
            var ray = GetMainCamera().ScreenPointToRay(Input.mousePosition);
            new Plane(Vector3.up, 0.0f).Raycast(ray, out var d);
            var pos = ray.GetPoint(d);

            return pos;
        }

    }
}

