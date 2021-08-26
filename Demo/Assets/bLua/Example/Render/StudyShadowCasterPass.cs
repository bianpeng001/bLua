#define HAND_WRITE_VIEW_MATRIX

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace bLua.Render
{
    class StudyShadowCasterPass : ScriptableRenderPass
    {
        private RenderTexture shadowmapTexture;
        private static readonly RenderTextureFormat shadowmapFormat;
        private static readonly int shadowmapSize;

        private MeshRenderer mainShadowCaster;
        private Mesh mainMesh;

        static StudyShadowCasterPass()
        {

            shadowmapFormat = RenderTextureFormat.Depth;
            shadowmapSize = 512;
        }

        public StudyShadowCasterPass()
        {
            renderPassEvent = RenderPassEvent.BeforeRenderingShadows;
        }

        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            if (mainShadowCaster == null)
            {
                var go = GameObject.Find("MainHero");
                if (go != null)
                {
                    mainShadowCaster = go.GetComponent<MeshRenderer>();
                    mainMesh = go.GetComponent<MeshFilter>().sharedMesh;
                }
            }

            shadowmapTexture = GetTemporaryShadowTexture();
            ConfigureTarget(new RenderTargetIdentifier(shadowmapTexture));
            ConfigureClear(ClearFlag.All, Color.black);
        }

        private static RenderTexture GetTemporaryShadowTexture()
        {
            var shadowTexture = RenderTexture.GetTemporary(shadowmapSize, shadowmapSize, 16, shadowmapFormat);
            shadowTexture.filterMode = FilterMode.Bilinear;
            shadowTexture.wrapMode = TextureWrapMode.Clamp;
            return shadowTexture;
        }

        public override void OnCameraCleanup(CommandBuffer cmd)
        {
            if (shadowmapTexture != null)
            {
                RenderTexture.ReleaseTemporary(shadowmapTexture);
                shadowmapTexture = null;
            }
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            ref var lightData = ref renderingData.lightData;
            var mainLightIndex = lightData.mainLightIndex;
            if (mainLightIndex < 0)
                return;

            var light = lightData.visibleLights[mainLightIndex];

            CommandBuffer cmd = CommandBufferPool.Get();

            var from = new Vector3(1, 5, -5);
            var to = new Vector3(0, 0, 0);

#if !HAND_WRITE_VIEW_MATRIX

            var lookatMatrix = Matrix4x4.LookAt(from, to, Vector3.up);
            var scaleMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(1, 1, -1));

            var viewMatrix = scaleMatrix * lookatMatrix.inverse;

#else

            var z_axis = (to - from).normalized;
            var x_axis = Vector3.Cross(Vector3.up, z_axis);
            var y_axis = Vector3.Cross(z_axis, x_axis);

            var transMatrix = Matrix4x4.Translate(-from);
            var rotMatrix = Matrix4x4.identity;
            rotMatrix.SetRow(0, x_axis);
            rotMatrix.SetRow(1, y_axis);
            rotMatrix.SetRow(2, z_axis);

            var scaleMatrix = Matrix4x4.Scale(new Vector3(1, 1, -1));
            var viewMatrix = scaleMatrix * rotMatrix * transMatrix;
#endif

            cmd.SetViewMatrix(viewMatrix);
            var projMatrix = Matrix4x4.Ortho(-10, 10, -10, 10, -10, 30);
            cmd.SetProjectionMatrix(projMatrix);

            var normMatrix = new Matrix4x4();
            normMatrix.m00 = 0.5f;
            normMatrix.m11 = 0.5f;
            normMatrix.m22 = 0.5f;
            normMatrix.m03 = 0.5f;
            normMatrix.m13 = 0.5f;
            normMatrix.m23 = 0.5f;

            normMatrix.m33 = 1.0f;

            cmd.SetViewport(new Rect(0, 0, shadowmapSize, shadowmapSize));

            var mat = mainShadowCaster.sharedMaterial;
            var pass = mat.FindPass("StudyShadowCaster");

            cmd.DrawMesh(mainMesh, Matrix4x4.identity, mat, 0, pass);

            cmd.DrawRenderer(mainShadowCaster, mat, 0, pass);

            cmd.SetGlobalMatrix(RenderUtil._World2Shadow, normMatrix * projMatrix * viewMatrix);
            cmd.SetGlobalTexture(RenderUtil._StudyShadowmapTexture, shadowmapTexture);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
}

