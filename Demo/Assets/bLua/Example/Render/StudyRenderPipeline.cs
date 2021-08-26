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
            StudyRenderingData data;
            data.camera = camera;
            
#if UNITY_EDITOR
            if (camera.cameraType == CameraType.SceneView)
            {
                ScriptableRenderContext.EmitWorldGeometryForSceneView(camera);
            }
#endif
            if (!camera.TryGetCullingParameters(out data.cullingParameters))
                return;

            context.SetupCameraProperties(camera, false);

            data.cullingResults = context.Cull(ref data.cullingParameters);
            data.sortingSettings = new SortingSettings(camera);
            data.shaderTagId = new ShaderTagId("ExampleTag");
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
