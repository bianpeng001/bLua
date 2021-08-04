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
    Varyings o;

    float4 positionCS = TransformObjectToHClip(input.positionOS);
#if UNITY_REVERSED_Z
    positionCS.z = min(positionCS.z, positionCS.w * UNITY_NEAR_CLIP_VALUE);
#else
    positionCS.z = max(positionCS.z, positionCS.w * UNITY_NEAR_CLIP_VALUE);
#endif
    o.positionCS = positionCS;

    return o;
}

half4 ShadowFrag (Varyings input) : SV_Target
{
    // float z = input.positionCS.z;
    // return half4(z, z, z, 1);
    return 0;
}

