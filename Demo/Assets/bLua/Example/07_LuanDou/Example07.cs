using UnityEngine.Rendering;

namespace bLua
{
    public class Example07 : LuaBehaviour
    {
        private RenderPipelineAsset oldAsset;
        public RenderPipelineAsset studyrpAsset;

        private void Awake()
        {
            oldAsset = GraphicsSettings.renderPipelineAsset;
            GraphicsSettings.renderPipelineAsset = studyrpAsset;

            var state = LuaClient.State;
            LoadModule(state);

            if (onAwake != null)
                onAwake.Call();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            GraphicsSettings.renderPipelineAsset = oldAsset;
        }

    }
}


