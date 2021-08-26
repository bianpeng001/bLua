Shader "Study/ShadowTest"
{
    Properties
    {
    }
    SubShader
    {
        Tags
		{
			"RenderType"="Opaque"
			"RenderPipeline" = "UniversalPipeline"
		}
        LOD 100

        Pass
        {
            Name "StudyForward"
            Tags { "LightMode" = "StudyForward" }

            HLSLPROGRAM
			#pragma target 4.0

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float3 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            // 最终输出给frag用
            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            TEXTURE2D(_StudyShadowmapTexture);
            SAMPLER(sampler_StudyShadowmapTexture);

			CBUFFER_START(UnityPerMaterial)

			CBUFFER_END

            Varyings vert (Attributes input)
            {
                Varyings o;
                o.positionCS = TransformObjectToHClip(input.positionOS);
                o.uv = input.uv;
                // o.uv = TRANSFORM_TEX(input.uv, _BaseMap);

                return o;
            }

            half4 frag (Varyings input) : SV_Target
            {
                float r = SAMPLE_TEXTURE2D(_StudyShadowmapTexture, sampler_StudyShadowmapTexture, input.uv).r;
                half4 color = half4(r, r, r, 1);
                return color;
                
            }
            ENDHLSL
        }
    }
}
