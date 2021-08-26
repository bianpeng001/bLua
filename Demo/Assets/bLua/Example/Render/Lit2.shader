//
//
//
Shader "Study/Lit2"
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
            Name "StudyForward"
            Tags { "LightMode" = "StudyForward" }

            ZWrite On
            ZTest LEqual
            ZTest LEqual
            Cull Back

            HLSLPROGRAM
            
			#pragma target 4.0

            #pragma vertex StudyForwardVert
            #pragma fragment StudyForwardFrag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"

            #define STUDY_FORWARD
            #include "Assets/bLua/Example/Render/Shadow.hlsl"

            ENDHLSL
        }

        pass
        {
            Name "StudyShadowCaster"
            Tags { "LightMode" = "StudyShadowCaster" }

            ZWrite On
            ZTest LEqual
            Cull Back

            HLSLPROGRAM
            #pragma target 4.0
            
            #pragma vertex ShadowVert_V2
            #pragma fragment ShadowFrag_V2

            #define SHADOW_V2
            
            #include "Assets/bLua/Example/Render/Shadow.hlsl"
            
            ENDHLSL
        }
    }
}
