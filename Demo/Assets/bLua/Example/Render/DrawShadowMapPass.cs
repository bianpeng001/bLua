using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace bLua.Render
{
    public class DrawShadowMapPass : ScriptableRenderPass
    {
        private Material material;
        private Mesh mesh;

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (material == null)
            {
                material = new Material(Shader.Find("Study/ShadowTest"));
            }

            if (mesh == null)
            {
                mesh = new Mesh();
                mesh.SetVertices(new Vector3[]
                {
                    new Vector3(-1, -1, 0),
                    new Vector3(-1, 1, 0),
                    new Vector3(1, 1, 0),
                    new Vector3(1, -1, 0),
                });
                mesh.SetTriangles(new int[]
                {
                    0, 1, 2,
                    0, 2, 3,
                }, 0);
                mesh.SetUVs(0, new Vector2[]
                {
                    new Vector2(0, 0),
                    new Vector2(0, 1),
                    new Vector2(1, 1),
                    new Vector2(1, 0),
                });
                mesh.UploadMeshData(true);
            }

            var cmd = CommandBufferPool.Get(nameof(DrawShadowMapPass));
            using (new ProfilingScope(cmd, ProfilingSampler.Get(StudyRenderEvent.DrawShadowMap)))
            {
                cmd.ClearRenderTarget(true, false, Color.black);
                cmd.SetViewMatrix(Matrix4x4.LookAt(Vector3.back, Vector3.zero, Vector3.up));

                var ratio = (float)Screen.width / (float)Screen.height;
                var size = 2;
                cmd.SetProjectionMatrix(Matrix4x4.Ortho(-size * ratio, size * ratio, -size, size, -10, 10));

                cmd.DrawMesh(mesh,
                    Matrix4x4.identity,
                    material);

                context.ExecuteCommandBuffer(cmd);
                CommandBufferPool.Release(cmd);
            }
        }
    }
}


