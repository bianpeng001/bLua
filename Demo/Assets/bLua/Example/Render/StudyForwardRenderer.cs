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
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.Internal;

namespace bLua.Render
{

    public enum StudyRenderEvent
    {
        DrawShadowMap,
    }

    public sealed class StudyForwardRenderer : ScriptableRenderer
    {
        private readonly StudyRendererData asset;

        private StencilState defaultStencilState;

        private readonly MainLightShadowCasterPass mainLightShadowCasterPass;
        private readonly DrawObjectsPass renderURPForwardPass;
        private readonly StudyShadowCasterPass studyShadowCasterPass;
        private readonly DrawObjectsPass renderStudyOpaqueForwardPass;

        private readonly DrawSkyboxPass drawSkyboxPass;
        private readonly DrawShadowMapPass drawShadowMapPass;

        public StudyForwardRenderer(StudyRendererData data) : base(data)
        {
            this.asset = data;

            StencilStateData stencilData = data.defaultStencilState;
            defaultStencilState = StencilState.defaultValue;
            defaultStencilState.enabled = stencilData.overrideStencilState;
            defaultStencilState.SetCompareFunction(stencilData.stencilCompareFunction);
            defaultStencilState.SetPassOperation(stencilData.passOperation);
            defaultStencilState.SetFailOperation(stencilData.failOperation);
            defaultStencilState.SetZFailOperation(stencilData.zFailOperation);

            mainLightShadowCasterPass = new MainLightShadowCasterPass(RenderPassEvent.BeforeRenderingShadows);

            studyShadowCasterPass = new StudyShadowCasterPass();

            renderStudyOpaqueForwardPass = new DrawObjectsPass(
                nameof(renderStudyOpaqueForwardPass),
                new ShaderTagId[] { new ShaderTagId("StudyForward") },
                true,
                RenderPassEvent.BeforeRenderingOpaques + 1,
                RenderQueueRange.opaque,
                data.opaqueLayerMask,
                defaultStencilState,
                stencilData.stencilReference);

            renderURPForwardPass = new DrawObjectsPass(
                nameof(renderURPForwardPass),
                new ShaderTagId[] { new ShaderTagId("UniversalForward") },
                true,
                RenderPassEvent.BeforeRenderingOpaques,
                RenderQueueRange.opaque,
                data.opaqueLayerMask,
                defaultStencilState,
                stencilData.stencilReference
                );

            drawSkyboxPass = new DrawSkyboxPass(RenderPassEvent.BeforeRenderingSkybox);

            drawShadowMapPass = new DrawShadowMapPass();
        }

        public override void Setup(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var camera = renderingData.cameraData.camera;
            var mainLightShadows = mainLightShadowCasterPass.Setup(ref renderingData);
            if (mainLightShadows)
                EnqueuePass(mainLightShadowCasterPass);

            EnqueuePass(studyShadowCasterPass);
            EnqueuePass(renderStudyOpaqueForwardPass);
            EnqueuePass(renderURPForwardPass);
            
            if (asset.showShadowMap)
                EnqueuePass(drawShadowMapPass);

            if (camera.clearFlags == CameraClearFlags.Skybox && RenderSettings.skybox != null)
                EnqueuePass(drawSkyboxPass);
        }
    }
}


