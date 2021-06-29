﻿/*
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
using UnityEditor;
using UnityEngine;

namespace bLua
{
    public class Builder
    {
        public static List<string> levels = new List<string>()
        {
            "Assets/bLua/Example/01_Example/ExampleScene.unity",
            "Assets/bLua/Example/02_War/WarScene.unity",
            "Assets/bLua/Example/05_Tower/TowerScene.unity",
            "Assets/bLua/Example/06_UI/UIScene.unity",
        };

        [MenuItem("Tools/Build/Bundle")]
        public static void BuildBundle()
        {
            
        }

        [MenuItem("Tools/Build/Win64")]
        public static void BuildWin64()
        {

        }
    }
}


