Shader "Unlit/LuanDou/TestMultiPass"
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
			"RenderType"="Opaque"
			"RenderPipeline" = "UniversalPipeline"
		}
        LOD 100

        Pass
        {
            tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
			#pragma target 4.0

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float3 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
            };

            // vert中间计算用
            struct Varyings
            {
				float4 positionCS : SV_POSITION;
                float4 positionWS;
                float3 normalWS;
                float4 tangentWS;
            };

            // 最终输出给frag用
            struct PackedVaryings
            {
                float4 positionCS : SV_POSITION;
            };

            TEXTURE2D(_BaseMap);
			SAMPLER(sampler_BaseMap);
			
			CBUFFER_START(UnityPerMaterial)
				float4 _BaseMap_ST;
				half4 _BaseColor;
			CBUFFER_END

            PackedVaryings PackVaryings (Varyings input)
            {
                PackedVaryings o = (PackedVaryings)0;
                o.positionCS = input.positionCS;
                return o;
            }
            
            PackedVaryings vert (Attributes input)
            {
                Varyings o = (Varyings)0;
                o.positionCS = TransformObjectToHClip(input.positionOS);

                return PackVaryings(o);
            }

            half4 frag (PackedVaryings input) : SV_Target
            {
                return half4(1, 0, 0, 1);
            }
            ENDHLSL
        }

        Pass
        {
            tags { "LightMode"="SRPDefaultUnlit" }

            HLSLPROGRAM
			#pragma target 4.0

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float3 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 tangentOS : TANGENT;
            };

            // vert中间计算用
            struct Varyings
            {
				float4 positionCS : SV_POSITION;
                float4 positionWS;
                float3 normalWS;
                float4 tangentWS;
            };

            // 最终输出给frag用
            struct PackedVaryings
            {
                float4 positionCS : SV_POSITION;
            };

            TEXTURE2D(_BaseMap);
			SAMPLER(sampler_BaseMap);
			
			CBUFFER_START(UnityPerMaterial)
				float4 _BaseMap_ST;
				half4 _BaseColor;
			CBUFFER_END

            PackedVaryings PackVaryings (Varyings input)
            {
                PackedVaryings o = (PackedVaryings)0;
                o.positionCS = input.positionCS;
                return o;
            }
            
            PackedVaryings vert (Attributes input)
            {
                Varyings o = (Varyings)0;
                input.positionOS += float4(0.1, 0, 0.1, 0);
                o.positionCS = TransformObjectToHClip(input.positionOS);

                return PackVaryings(o);
            }

            half4 frag (PackedVaryings input) : SV_Target
            {
                return half4(0, 1, 0, 1);
            }
            ENDHLSL
        }
    }
}
