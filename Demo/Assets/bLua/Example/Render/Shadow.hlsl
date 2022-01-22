//-----------------------------------
// common begin
//-----------------------------------

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

// basemap
TEXTURE2D(_BaseMap);
SAMPLER(sampler_BaseMap);

// shadowmap
TEXTURE2D(_StudyShadowmapTexture);
SAMPLER_CMP(sampler_StudyShadowmapTexture);

CBUFFER_START(UnityPerMaterial)
    half4 _BaseColor;
    float4 _BaseMap_ST;
    float4 _StudyShadowmapTexture_ST;
CBUFFER_END

// global defines
float4x4 _World2Shadow;

//-----------------------------------
// end common
//-----------------------------------

#ifdef SHADOW_V1

struct Attributes
{
    float3 positionOS : POSITION;
    float3 normalOS : NORMAL;
    float2 texcoord     : TEXCOORD0;
};

struct Varyings
{
    float2 uv           : TEXCOORD0;
    float4 positionCS : SV_POSITION;
};

// 在shadowmap阶段, 就把bias都算好了, 这样算阴影的时候, 就不用计算了, 优秀

float3 _LightDirection;
float4 _ShadowBias; // x: depth bias, y: normal bias

float3 ApplyShadowBias(float3 positionWS, float3 normalWS, float3 lightDirection)
{
    float invNdotL = 1.0 - saturate(dot(lightDirection, normalWS));
    float scale = invNdotL * _ShadowBias.y;

    // normal bias is negative since we want to apply an inset normal offset
    positionWS = lightDirection * _ShadowBias.xxx + positionWS;
    positionWS = normalWS * scale.xxx + positionWS;
    return positionWS;
}

#define APPLY_SHADOW_BIAS
//#define UNITY_REVERSED_Z

Varyings ShadowVert (Attributes input)
{

#ifdef APPLY_SHADOW_BIAS
    float3 positionWS = TransformObjectToWorld(input.positionOS.xyz);
    float3 normalWS = TransformObjectToWorldNormal(input.normalOS);
    float4 positionCS = TransformWorldToHClip(ApplyShadowBias(positionWS, normalWS, _LightDirection));
#else
    // 不做bias的情况下, 阴影采样出来, 会有黑色条纹
    // 相关资料参见: https://zhuanlan.zhihu.com/p/358799534
    float4 positionCS = TransformObjectToHClip(input.positionOS);
#endif

#ifdef UNITY_REVERSED_Z
    positionCS.z = min(positionCS.z, positionCS.w * UNITY_NEAR_CLIP_VALUE);
#else
    positionCS.z = max(positionCS.z, positionCS.w * UNITY_NEAR_CLIP_VALUE);
#endif

    Varyings o;
    o.uv = TRANSFORM_TEX(input.texcoord, _BaseMap);
    o.positionCS = positionCS;

    return o;
}

/*
half4 SampleAlbedoAlpha(float2 uv, TEXTURE2D_PARAM(albedoAlphaMap, sampler_albedoAlphaMap))
{
    return SAMPLE_TEXTURE2D(albedoAlphaMap, sampler_albedoAlphaMap, uv);
}

half Alpha(half albedoAlpha, half4 color, half cutoff)
{
#if !defined(_SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A) && !defined(_GLOSSINESS_FROM_BASE_ALPHA)
    half alpha = albedoAlpha * color.a;
#else
    half alpha = color.a;
#endif

#if defined(_ALPHATEST_ON)
    clip(alpha - cutoff);
#endif

    return alpha;
}
*/

half4 ShadowFrag (Varyings input) : SV_Target
{
    //Alpha(SampleAlbedoAlpha(input.uv, TEXTURE2D_ARGS(_BaseMap, sampler_BaseMap)).a, half4(1, 1, 1, 1), 1);
    return 0;
}

#endif

#ifdef SHADOW_V2

struct Attributes
{
    float3 positionOS : POSITION;
    float3 normalOS : NORMAL;
    float2 texcoord     : TEXCOORD0;
};

struct Varyings
{
    float2 uv           : TEXCOORD0;
    float4 positionCS : SV_POSITION;
};

//
// 尝试了一下自己实现, 他原来的方法总归有点不太舒服
//

#define APPLY_SHADOW_BIAS

Varyings ShadowVert_V2 (Attributes input)
{
#ifdef APPLY_SHADOW_BIAS
    float3 positionWS = TransformObjectToWorld(input.positionOS.xyz);

    // 如果不做bias, 则自阴影会有条纹. 条纹的原因在于算出来的深度, 跟采样出来的深度比较
    // 采样出来的像素精度有限, 所以差不多部分超过部分不到, 导致条纹, 条纹的形状跟光线方向有关

    // nomral bias
    //float3 normalWS = TransformObjectToWorldNormal(input.normalOS);
    //positionWS = positionWS + normalWS * (-0.1);

    // depth bias
    float3 positionVS = TransformWorldToView(positionWS);
    positionVS.z -= 0.2;
    float4 positionCS = TransformWViewToHClip(positionVS);

    //float4 positionCS = TransformWorldToHClip(positionWS);
#else

    float4 positionCS = TransformObjectToHClip(input.positionOS.xyz);

#endif

    // 注意:
    // 在editor下面, z离near plane越近, 越大
    // 

    Varyings o;
    //o.uv = TRANSFORM_TEX(input.texcoord, _BaseMap);
    o.positionCS = positionCS;

    return o;
}

half4 ShadowFrag_V2(Varyings input) : SV_Target
{
    //float z = input.positionCS.z;
    //z = z * 0.5 + 0.5;
    //z = 1 - z;

    //return half4(z, z, z, 1);
    
    return 0;
}

#endif


#ifdef STUDY_FORWARD

struct Attributes
{
    float3 positionOS : POSITION;
    float3 normalOS : NORMAL;
    float2 uv : TEXCOORD0;
};

struct PackedVaryings
{
    float4 positionCS : SV_POSITION;
    float2 uv : TEXCOORD0;
    float3 positionWS : TEXCOORD1;
    float3 normalWS: TEXCOORD2;
    float4 shadowCoord: TEXCOORD3;
};

PackedVaryings StudyForwardVert (Attributes input)
{
    PackedVaryings o;
    
    o.positionCS = TransformObjectToHClip(input.positionOS);
    o.normalWS = TransformObjectToWorldNormal(input.normalOS);

    o.positionWS = TransformObjectToWorld(input.positionOS);
    o.shadowCoord =mul(_World2Shadow, float4(o.positionWS, 1));

    o.uv = TRANSFORM_TEX(input.uv, _BaseMap);

    return o;
}

half4 StudyForwardFrag (PackedVaryings input) : SV_Target
{
    float4 shadowCoord = input.shadowCoord / input.shadowCoord.w;
    //float depth = SAMPLE_TEXTURE2D(_StudyShadowmapTexture, sampler_StudyShadowmapTexture, shadowCoord.xy).r;
    float depth = SAMPLE_TEXTURE2D_SHADOW(_StudyShadowmapTexture, sampler_StudyShadowmapTexture, shadowCoord.xyz);
    #ifdef UNITY_REVERSED_Z
        #ifdef SHADER_API_GLES3

        #endif

        #ifdef SHADER_API_D3D11
            // 说明往shadowmap里面写的时候, 是需要修正的
            depth = 1.0 - depth;
        #endif
    #endif

    float lightDepth = shadowCoord.z;

    float light = 1;
    if (lightDepth > depth)
        light = 0.3;

    // 看一下采样值, 和计算值的差距, 理论上, 无阴影处是一样的, 就是黑色
    //light = lightDepth - depth;

    // 输出depth, 这个是修正过的
    //light = depth;
    
    half4 tex = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, input.uv);

    return _BaseColor * tex * light;
    
}

#endif

