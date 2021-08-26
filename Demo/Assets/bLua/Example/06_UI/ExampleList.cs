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
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace bLua
{
    public class ExampleList : MonoBehaviour
    {
        private List<string> sceneList = new List<string>()
        {
            "TowerScene",
            "ExampleScene",
            "WarScene",
            "UIScene",
            "LuanDouScene",
        };

        private void Awake()
        {
            GameObject.DontDestroyOnLoad(gameObject);
        }

        private void OnGUI()
        {
            for(int i = 0;  i <  sceneList.Count; ++i)
            {
                var sceneName = sceneList[i];
                if (GUI.Button(new Rect(15, 60 + i * 60, 160, 56), sceneName))
                {
                    SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
                    break;
                }
            }
        }

    }
}
