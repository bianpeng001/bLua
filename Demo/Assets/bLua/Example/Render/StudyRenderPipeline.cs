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
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace bLua.Render
{
    public class StudyRenderPipeline : RenderPipeline
    {
        public readonly StudyRenderPipelineAsset asset;

        public StudyRenderPipeline(StudyRenderPipelineAsset asset)
        {
            this.asset = asset;
        }

        protected override void Render(ScriptableRenderContext context, Camera[] cameras)
        {
            BeginFrameRendering(context, cameras);
            try
            {
                var cmd = CommandBufferPool.Get("Clear");
                cmd.ClearRenderTarget(true, true, asset.backgroundColor);
                context.ExecuteCommandBuffer(cmd);
                CommandBufferPool.Release(cmd);

                Array.Sort(cameras, (a, b) => (int)(a.depth - b.depth));
                for (int i = 0; i < cameras.Length; ++i)
                {
                    var camera = cameras[i];
                    BeginCameraRendering(context, camera);
                    try
                    {
                        RenderOneCamera(context, camera);
                    }
                    finally
                    {
                        EndCameraRendering(context, camera);
                    }
                }
            }
            finally
            {
                EndFrameRendering(context, cameras);
            }
        }

        private static void RenderOneCamera(ScriptableRenderContext context, Camera camera)
        {
            RenderingData data;
            data.camera = camera;
            if (!camera.TryGetCullingParameters(out data.cullingParameters))
                return;

#if UNITY_EDITOR
            if (camera.cameraType == CameraType.SceneView)
            {
                ScriptableRenderContext.EmitWorldGeometryForSceneView(camera);
            }
#endif

            context.SetupCameraProperties(camera, false);

            data.cullingResults = context.Cull(ref data.cullingParameters);
            data.sortingSettings = new SortingSettings(camera);
            data.shaderTagId = new ShaderTagId("ShadowCaster");
            data.drawingSettings = new DrawingSettings(data.shaderTagId, data.sortingSettings);


            data.filteringSettings = FilteringSettings.defaultValue;
            context.DrawRenderers(data.cullingResults, ref data.drawingSettings, ref data.filteringSettings);


            if (camera.clearFlags == CameraClearFlags.Skybox && RenderSettings.skybox != null)
            {
                context.DrawSkybox(camera);
            }

            context.Submit();
        }
    }
}
