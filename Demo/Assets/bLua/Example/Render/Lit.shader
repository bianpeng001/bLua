//
//
//
Shader "Study/Lit"
{
    Properties
    {
        _BaseMap ("Base Texture", 2D) = "white" {}
		_BaseColor ("Base Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags
		{
			"RenderType" = "Opaque"
			"RenderPipeline" = "UniversalPipeline"
		}
        LOD 100

        Pass
        {
            Name "ShadowCaster"
            Tags { "LightMode" = "ShadowCaster" }

            ZWrite On
            ZTest LEqual
            ColorMask 0
            Cull Back
        
            HLSLPROGRAM
            #pragma target 4.0
            
            #pragma vertex ShadowVert
            #pragma fragment ShadowFrag

            #define SHADOW_V1
            
            #include "Assets/bLua/Example/Render/Shadow.hlsl"
            
            ENDHLSL
        }


        Pass
        {
            Tags { "LightMode" = "StudyForward1" }

            ZWrite On
            ZTest LEqual
            ZTest LEqual
            Cull Back

            HLSLPROGRAM
            
			#pragma target 4.0

            #pragma vertex vert
            #pragma fragment frag

            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/EntityLighting.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/ImageBasedLighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Shadows.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float3 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
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

            TEXTURE2D(_BaseMap);
			SAMPLER(sampler_BaseMap);
			
			CBUFFER_START(UnityPerMaterial)
				float4 _BaseMap_ST;
				half4 _BaseColor;
			CBUFFER_END

            PackedVaryings vert (Attributes input)
            {
                PackedVaryings o;
                o.positionCS = TransformObjectToHClip(input.positionOS);
                o.uv = TRANSFORM_TEX(input.uv, _BaseMap);
                o.positionWS = TransformObjectToWorld(input.positionOS);
                o.normalWS = TransformObjectToWorldNormal(input.normalOS);
                o.shadowCoord = TransformWorldToShadowCoord(o.positionWS);

                return o;
            }

            half4 frag (PackedVaryings input) : SV_Target
            {
                float4 shadowCoord = input.shadowCoord;
                
                half realtimeShadow = MainLightRealtimeShadow(shadowCoord);
                //half shadowFade = GetShadowFade(input.positionWS);
                //half bakedShadow = 1.0;

                //Light light = GetMainLight(shadowCoord);
                //float atte = light.shadowAttenuation;
                //float atte = MixRealtimeAndBakedShadows(realtimeShadow, bakedShadow, shadowFade);
                float atte = realtimeShadow;

                half4 tex = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, input.uv);

                return _BaseColor * tex * atte;
                //return _BaseColor * atte;
                //return shadowCoord * atte;
                //return half4(0, atte, 0, 1);
            }

            ENDHLSL
        }

    }
}
