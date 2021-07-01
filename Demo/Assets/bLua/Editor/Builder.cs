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

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace bLua
{
    public class Builder
    {
        public static List<string> levels = new List<string>()
        {
            "Assets/bLua/Example/05_Tower/TowerScene.unity",
            "Assets/bLua/Example/01_Example/ExampleScene.unity",
            "Assets/bLua/Example/02_War/WarScene.unity",
            "Assets/bLua/Example/06_UI/UIScene.unity",
        };

        [MenuItem("Tools/Build/Bundle")]
        public static void BuildBundle()
        {
        }

        private static void Build(BuildTargetGroup group,
            BuildTarget target,
            string outputPath,
            bool isRelase)
        {
            var activeTarget = EditorUserBuildSettings.activeBuildTarget;
            if (target != activeTarget)
                throw new Exception($"{target}");

            var t0 = DateTime.Now;
            BuildOptions options = BuildOptions.None;
            if (!isRelase)
            {
                options = BuildOptions.Development
                    | BuildOptions.AllowDebugging
                    | BuildOptions.ConnectWithProfiler;
            }
            
            PlayerSettings.SplashScreen.showUnityLogo = false;
            PlayerSettings.SplashScreen.show = true;
            PlayerSettings.SplashScreen.backgroundColor = Color.white;

            PlayerSettings.SetManagedStrippingLevel(group, ManagedStrippingLevel.Low);
            PlayerSettings.SetScriptingBackend(group, ScriptingImplementation.IL2CPP);
            PlayerSettings.SetApiCompatibilityLevel(group, ApiCompatibilityLevel.NET_Standard_2_0);
            PlayerSettings.SetIncrementalIl2CppBuild(group, false);
            PlayerSettings.gcIncremental = true;
            PlayerSettings.runInBackground = true;
            PlayerSettings.usePlayerLog = true;

            var symbols = new HashSet<string>();
            if (!isRelase)
            {
                symbols.Add("ENABLE_ASSERT");
            }
            symbols.UnionWith(PlayerSettings.GetScriptingDefineSymbolsForGroup(group).Split(';'));
            PlayerSettings.SetScriptingDefineSymbolsForGroup(group, string.Join(";", symbols));

            switch(target)
            {
                case BuildTarget.Android:
                    PlayerSettings.SetMobileMTRendering(group, true);

                    PlayerSettings.Android.androidIsGame = true;
                    PlayerSettings.Android.startInFullscreen = true;
                    PlayerSettings.Android.blitType = AndroidBlitType.Auto;
                    PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
                    PlayerSettings.Android.splashScreenScale = AndroidSplashScreenScale.Center;
                    
                    EditorUserBuildSettings.exportAsGoogleAndroidProject = false;
                    EditorUserBuildSettings.androidCreateSymbolsZip = false;
                    PlayerSettings.Android.bundleVersionCode = 100;
                    break;

                case BuildTarget.iOS:
                    PlayerSettings.SetMobileMTRendering(group, true);

                    PlayerSettings.iOS.requiresFullScreen = true;
                    PlayerSettings.iOS.appInBackgroundBehavior = iOSAppInBackgroundBehavior.Custom;
                    PlayerSettings.SetArchitecture(BuildTargetGroup.iOS, 1);
                    PlayerSettings.iOS.buildNumber = "100";
                    break;
            }

            var report = BuildPipeline.BuildPlayer(levels.ToArray(), outputPath, target, options);

            var t1 = DateTime.Now;
            var t = Mathf.RoundToInt((float)(t1 - t0).TotalSeconds);
            Debug.Log($"{target} {report.summary.result} in {t}s");
        }

        [MenuItem("Tools/Build/Win64 Debug")]
        public static void BuildWin64()
        {
            Build(BuildTargetGroup.Standalone,
                BuildTarget.StandaloneWindows64,
                "BuildWin64/Demo.exe",
                false);
        }

        [MenuItem("Tools/Build/Android Debug")]
        public static void BuildAndroid()
        {
            Build(BuildTargetGroup.Android,
                BuildTarget.Android,
                "BuildAndroid/Demo.apk",
                false);
        }

    }
}


