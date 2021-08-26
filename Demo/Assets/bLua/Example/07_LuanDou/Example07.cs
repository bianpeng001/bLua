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

using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace bLua
{
    public class Example07 : LuaBehaviour
    {
        private RenderPipelineAsset oldAsset;
        public UniversalRenderPipelineAsset SRPAsset;

        private void Awake()
        {
            oldAsset = GraphicsSettings.renderPipelineAsset;
            GraphicsSettings.renderPipelineAsset = SRPAsset;

            SRPAsset.useSRPBatcher = true;

            var state = LuaClient.State;
            LoadModule(state);

            if (onAwake != null)
                onAwake.Call();
        }

        public override void OnDestroy()
        {
            GraphicsSettings.renderPipelineAsset = oldAsset;
            base.OnDestroy();
        }

    }
}


