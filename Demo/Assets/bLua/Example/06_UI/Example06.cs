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
using UnityEngine.UI;

namespace bLua
{
    public class Example06 : LuaBehaviour
    {
        public Text lblName;

        private void Awake()
        {
            var state = LuaClient.State;
            LoadModule(state);

            onAwake.Call();

            var bind = new DataBind();
            bind.Connect("name", lblName);

            using (var t = module.GetTable("dataset"))
            {
                t.SetItem(2, bind);
            }

            using (var f = module.GetFunction("Test1"))
            {
                f.Call();
            }
        }
    }
}
