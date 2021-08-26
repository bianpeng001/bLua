using UnityEngine;

namespace bLua.Render
{
    public static class RenderUtil
    {
        public static readonly int _World2Shadow = Shader.PropertyToID("_World2Shadow");
        public static readonly int _StudyShadowmapTexture = Shader.PropertyToID("_StudyShadowmapTexture");
    }
}
