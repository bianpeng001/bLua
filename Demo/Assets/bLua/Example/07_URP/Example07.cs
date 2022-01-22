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

using bLua.Render;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace bLua
{
    public class Example07 : LuaBehaviour
    {
        private RenderPipelineAsset oldAsset;
        public UniversalRenderPipelineAsset SRPAsset;

        private string sysinfo;

        private GameObject mainHero;

        private void Awake()
        {
            oldAsset = GraphicsSettings.renderPipelineAsset;
            GraphicsSettings.renderPipelineAsset = SRPAsset;

            SRPAsset.useSRPBatcher = true;

            var state = LuaClient.State;
            LoadModule(state);

            if (onAwake != null)
                onAwake.Call();

            sysinfo = $"device:{SystemInfo.deviceName},{SystemInfo.graphicsDeviceName}\n" +
                $"reversedZ:{SystemInfo.usesReversedZBuffer}";
        }

        public void Update()
        {
            if (mainHero == null)
            {
                mainHero = GameObject.Find("MainHero");
            }
            mainHero.transform.localRotation = Quaternion.AngleAxis(Time.time*10, Vector3.up);
        }

        public override void OnDestroy()
        {
            GraphicsSettings.renderPipelineAsset = oldAsset;
            base.OnDestroy();
        }

        public void OnGUI()
        {
            if (GUI.Button(new Rect(15, 500, 160, 56), "ShadowMap"))
            {
                var renderer = SRPAsset.scriptableRenderer as StudyForwardRenderer;
                renderer.asset.showShadowMap = !renderer.asset.showShadowMap;
            }

            GUI.Label(new Rect(15, 560, 160, 100), sysinfo);
        }

        private static void Dummy()
        {
            new AutoWrap.Action<LogUtil.LogLevel>();
        }
    }
}


