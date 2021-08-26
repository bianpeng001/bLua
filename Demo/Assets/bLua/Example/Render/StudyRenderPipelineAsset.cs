using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace bLua.Render
{
    [CreateAssetMenu(fileName = "StudyRenderPipelineAsset", menuName = "Study/StudyRenderPipelineAsset")]
    public class StudyRenderPipelineAsset : RenderPipelineAsset
    {

        [SerializeField]
        public Color backgroundColor;

        [SerializeField]
        public StudyRendererData[] rendererDatas = new StudyRendererData[1];
        private ScriptableRenderer[] renderers = new ScriptableRenderer[1];

        protected override RenderPipeline CreatePipeline()
        {
            CreateRenders();
            return new StudyRenderPipeline(this);
        }

        private void CreateRenders()
        {
            var count = rendererDatas.Length;
            renderers = new ScriptableRenderer[count];
            for (int i = 0; i < count; ++i)
            {
                if (rendererDatas[i] != null)
                {
                    renderers[i] = rendererDatas[i].CreateRenderer();
                }
            }
        }

    }
}
