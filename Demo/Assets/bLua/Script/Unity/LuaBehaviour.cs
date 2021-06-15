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
using UnityEngine;

namespace bLua
{
    public class LuaBehaviour : MonoBehaviour
    {
        public enum ModuleType
        {
            Dofile,
            Require,
        }

        public ModuleType mode;
        public string path;
        protected LuaTable module;

        protected LuaFunction onAwake,
            onUpdate,
            onLateUpdate,
            onFixedUpdate;

        protected void CreateProperty<T>(
            string name,
            System.Func<T> getter,
            System.Action<T> setter)
        {
            using (var f = module.GetFunction("CreateProperty"))
            {
                f.Call<string, LuaDelegate, LuaDelegate, int>(
                    name,
                    new LuaDelegate(new AutoWrap.Func<T>() { cb = getter }),
                    new LuaDelegate(new AutoWrap.Action<T>() { cb = setter })
                );
            }
        }

        public void LoadModule(LuaState state)
        {
            if (mode == ModuleType.Dofile)
                module = state.DoFileRetTable(path);
            else
                module = state.Require(path);

            module.SetField("gameObject", gameObject);
            module.SetField("luaBehaviour", this);

            CreateProperty("path", () => path, value => path = value);
            CreateProperty("name", () => name, value => name = value);
            CreateProperty("enabled", () => enabled, value => enabled = value);

            onAwake = module.GetFunction("Awake");
            onUpdate = module.GetFunction("Update");
            onLateUpdate = module.GetFunction("LateUpdate");
            onFixedUpdate = module.GetFunction("FixedUpdate");
        }


        protected virtual void OnDestroy()
        {
            if (onAwake != null)
                onAwake.Dispose();
            if (onUpdate != null)
                onUpdate.Dispose();
            if (onLateUpdate != null)
                onLateUpdate.Dispose();
            if (onFixedUpdate != null)
                onFixedUpdate.Dispose();

            if (module != null)
            {
                using (var onDestroy = module.GetFunction("OnDestroy"))
                {
                    if (onDestroy != null)
                        onDestroy.Call();
                }
                module.Dispose();
            }
        }
    }

}




