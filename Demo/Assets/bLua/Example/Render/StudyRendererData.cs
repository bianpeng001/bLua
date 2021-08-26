using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace bLua.Render
{
    [CreateAssetMenu(fileName = "Study_Renderer", menuName = "Study/StudyRenderer")]
    public class StudyRendererData : ScriptableRendererData
    {
        [SerializeField]
        public bool showShadowMap = false;

        [SerializeField]
        public LayerMask opaqueLayerMask = -1;

        [SerializeField]
        public StencilStateData defaultStencilState = new StencilStateData() { passOperation = StencilOp.Replace };

        protected override ScriptableRenderer Create()
        {
            return CreateRenderer();
        }

        public ScriptableRenderer CreateRenderer()
        {
            return new StudyForwardRenderer(this);
        }
    }
}

