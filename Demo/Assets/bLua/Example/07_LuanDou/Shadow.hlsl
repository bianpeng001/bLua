//
// 渲染影子用的一些公用代码
//

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

struct Attributes
{
    float3 positionOS : POSITION;
};

struct Varyings
{
    float4 positionCS : SV_POSITION;
};

Varyings ShadowVert (Attributes input)
{
    Varyings o = (Varyings)0;
    o.positionCS = TransformObjectToHClip(input.positionOS);
    return o;
}

half4 ShadowFrag (Varyings input) : SV_Target
{
    return half4(1, 1, 1, 1);
}

