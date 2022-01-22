using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace bLua
{
    public class Example08 : LuaBehaviour
    {
        private void Awake()
        {
            var state = LuaClient.State;
            LoadModule(state);

            if (onAwake != null)
                onAwake.Call();


            var urpAsset = (UniversalRenderPipelineAsset)GraphicsSettings.renderPipelineAsset;
            var renderer = urpAsset.GetRenderer(0);


        }
    }
}
