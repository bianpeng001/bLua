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

using UnityEngine;
using static bLua.AutoWrap;

namespace bLua
{
    //
    // unity这边到lua那边对应的模块
    //
    public class LuaBehaviour : MonoBehaviour
    {
        // 模块的使用方式, 一般来说, 是不用requre的, 除非很特殊
        public enum ModuleType
        {
            Dofile,
            Require,
        }

        public ModuleType mode;
        public string path;
        protected LuaTable module;

        // update event callback
        protected LuaFunction onAwake,
            onUpdate,
            onLateUpdate,
            onFixedUpdate;

        // 支持了delegate之后, 就可以做这个功能了
        protected void CreateProperty<T>(
            string name,
            System.Func<T> getter,
            System.Action<T> setter)
        {
            using (var f = module.GetFunction("CreateProperty"))
            {
                
                f.Call<string, IUnityMethod, IUnityMethod, int>(name,
                    AutoWrap.CreateFunc<T>(getter),
                    AutoWrap.CreateAction<T>(setter));
            }
        }

        // 加载, 根据记录的path
        public void LoadModule(LuaState state)
        {
            if (mode == ModuleType.Dofile)
                module = state.DoFileRetTable(path);
            else
                module = state.Require(path);

            // 固有属性, 而且是只读
            module.SetField("gameObject", gameObject);
            module.SetField("luaBehaviour", this);

            // 动态属性
            CreateProperty("path", () => path, value => path = value);
            CreateProperty("name", () => name, value => name = value);
            CreateProperty("enabled", () => enabled, value => enabled = value);

            onAwake = module.GetFunction("Awake");
            onUpdate = module.GetFunction("Update");
            onLateUpdate = module.GetFunction("LateUpdate");
            onFixedUpdate = module.GetFunction("FixedUpdate");
        }

        public virtual void OnDestroy()
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




