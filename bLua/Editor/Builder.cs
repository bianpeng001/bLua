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
    //
    // build 脚本, 全部用c#来写, 不用外面加工具了
    //
    public class Builder
    {
        public static readonly BuildTarget activeBuildTarget = EditorUserBuildSettings.activeBuildTarget;

        public static List<string> levels = new List<string>()
        {
            "Assets/bLua/Example/06_UI/UIScene.unity",
            "Assets/bLua/Example/05_Tower/TowerScene.unity",
            "Assets/bLua/Example/01_Example/ExampleScene.unity",
            "Assets/bLua/Example/02_War/WarScene.unity",
            "Assets/bLua/Example/07_LuanDou/LuanDouScene.unity",
        };

        [MenuItem("Tools/bLua/Build/Bundle")]
        public static void BuildBundle()
        {
            // TODO:
        }

        private static void DoBuild(BuildTargetGroup group,
            BuildTarget target,
            string outputPath,
            bool isRelease)
        {
            var activeTarget = EditorUserBuildSettings.activeBuildTarget;
            if (target != activeTarget)
                throw new Exception($"Editor Enviroment not match: {target}");

            var t0 = DateTime.Now;
            Debug.Log($"{t0} start build");

            BuildOptions options = BuildOptions.None;
            if (!isRelease)
            {
                options |= BuildOptions.Development;
                options |= BuildOptions.AllowDebugging;
                options |= BuildOptions.ConnectWithProfiler;
            }
            
            // splash
            PlayerSettings.SplashScreen.showUnityLogo = false;
            PlayerSettings.SplashScreen.show = false;
            PlayerSettings.SplashScreen.backgroundColor = Color.white;

            // 公共参数
            PlayerSettings.SetApiCompatibilityLevel(group, ApiCompatibilityLevel.NET_Standard_2_0);
            PlayerSettings.SetManagedStrippingLevel(group, ManagedStrippingLevel.Low);
            PlayerSettings.SetScriptingBackend(group, ScriptingImplementation.IL2CPP);
            PlayerSettings.SetIncrementalIl2CppBuild(group, false);

            // 朝向
            PlayerSettings.allowedAutorotateToLandscapeRight = true;
            PlayerSettings.allowedAutorotateToLandscapeLeft = true;
            PlayerSettings.allowedAutorotateToPortraitUpsideDown = false;
            PlayerSettings.allowedAutorotateToPortrait = false;

            // il2cpp
            if (isRelease)
            {
                //PlayerSettings.SetAdditionalCompilerArgumentsForGroup(group, new string[]
                //{
                //});
                PlayerSettings.SetIl2CppCompilerConfiguration(group, Il2CppCompilerConfiguration.Release);
                //PlayerSettings.SetIl2CppCompilerConfiguration(group, Il2CppCompilerConfiguration.Master);
                //PlayerSettings.SetIl2CppCompilerConfiguration(group, Il2CppCompilerConfiguration.Debug);
                //PlayerSettings.SetAdditionalIl2CppArgs("--compiler-flags=\"-O0\" --linker-flags=\"-O0\"");
                //PlayerSettings.SetAdditionalIl2CppArgs("--compiler-flags=\"-O1\" --linker-flags=\"-O1\"");
                //PlayerSettings.SetAdditionalIl2CppArgs("--compiler-flags=\"-O2\" --linker-flags=\"-O2\"");
            }
            else
            {
                PlayerSettings.SetIl2CppCompilerConfiguration(group, Il2CppCompilerConfiguration.Debug);
                PlayerSettings.SetAdditionalIl2CppArgs("--compiler-flags=\"-O0\" --linker-flags=\"-O0\"");
            }

            // symbols
            var symbols = new HashSet<string>();
            if (!isRelease)
            {
                symbols.Add("ENABLE_ASSERT");
            }
            symbols.UnionWith(PlayerSettings.GetScriptingDefineSymbolsForGroup(group).Split(';'));
            PlayerSettings.SetScriptingDefineSymbolsForGroup(group, string.Join(";", symbols));

            PlayerSettings.gcIncremental = true;
            PlayerSettings.runInBackground = true;
            PlayerSettings.usePlayerLog = true;

            // mutithread rendering
            PlayerSettings.MTRendering = true;
            PlayerSettings.SetMobileMTRendering(group, true);

            int buildNumber = 100;

            switch (target)
            {
                case BuildTarget.Android:
                    PlayerSettings.Android.androidIsGame = true;
                    PlayerSettings.Android.startInFullscreen = true;
                    PlayerSettings.Android.blitType = AndroidBlitType.Auto;
                    PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
                    PlayerSettings.Android.splashScreenScale = AndroidSplashScreenScale.Center;
                    
                    // 导出工程 gradle
                    EditorUserBuildSettings.exportAsGoogleAndroidProject = false;

                    EditorUserBuildSettings.androidCreateSymbolsZip = true;
                    PlayerSettings.Android.bundleVersionCode = buildNumber;

                    PlayerSettings.Android.useCustomKeystore = true;
                    PlayerSettings.Android.keystoreName = "android_build.keystore";
                    PlayerSettings.Android.keystorePass = "123456";
                    PlayerSettings.Android.keyaliasName = "build";
                    PlayerSettings.Android.keyaliasPass = "123456";

                    break;

                case BuildTarget.iOS:
                    PlayerSettings.iOS.scriptCallOptimization = ScriptCallOptimizationLevel.SlowAndSafe;
                    PlayerSettings.iOS.requiresFullScreen = true;
                    PlayerSettings.iOS.backgroundModes = iOSBackgroundMode.None;
                    PlayerSettings.iOS.appInBackgroundBehavior = iOSAppInBackgroundBehavior.Custom;

                    // arch64 only: 0 - None, 1 - ARM64, 2 - Universal
                    PlayerSettings.SetArchitecture(BuildTargetGroup.iOS, 1);
                    PlayerSettings.iOS.buildNumber = buildNumber.ToString();

                    break;
            }

            // build
            var report = BuildPipeline.BuildPlayer(levels.ToArray(), outputPath, target, options);

            var t1 = DateTime.Now;
            Debug.Log($"{t1} build ok");

            var t = Mathf.RoundToInt((float)(t1 - t0).TotalSeconds);
            Debug.Log($"{target} release:{isRelease} {report.summary.result} in {t}s");
        }

        [MenuItem("Tools/bLua/Build/Win64 Debug")]
        public static void BuildWin64()
        {
            DoBuild(BuildTargetGroup.Standalone,
                BuildTarget.StandaloneWindows64,
                "BuildWin64/Demo.exe",
                false);
        }

        [MenuItem("Tools/bLua/Build/Android Debug")]
        public static void BuildAndroidDebug()
        {
            DoBuild(BuildTargetGroup.Android,
                BuildTarget.Android,
                "BuildAndroid/Demo.apk",
                false);
        }

        [MenuItem("Tools/bLua/Build/Android Release")]
        public static void BuildAndroid()
        {
            DoBuild(BuildTargetGroup.Android,
                BuildTarget.Android,
                "BuildAndroid/Demo.apk",
                true);
        }

    }
}


