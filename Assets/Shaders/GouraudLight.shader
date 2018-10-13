﻿Shader "Custom/GouraudLight" {
	Properties{
		_NumTextures("Number of textures", Float) = 0
		_MainTex("Texture 1 (RGBA)", 2D) = "black" {}
		_MainTex2("Texture 2 (RGBA)", 2D) = "black" {}
		_MainTex3("Texture 3 (RGBA)", 2D) = "black" {}
		_MainTex4("Texture 4 (RGBA)", 2D) = "black" {}
		_Color("Color", Vector) = (1,1,1,1)
		_DiffuseCoef("Diffuse Coef", Vector) = (1,1,1,1)
		_AmbientCoef("Ambient Coef", Vector) = (1,1,1,1)
		_SpecularCoef("Specular Coef", Vector) = (1,1,1,1)
		_SpecularFactor("Shininess", Float) = 1
		_EmissionColor("Emission color", Color) = (0,0,0,1)
		[MaterialToggle] _UVSec("Use secondary UVs", Float) = 0
		[MaterialToggle] _ShadingMode("Is fragment shaded", Float) = 0
		[MaterialToggle] _Blend("Use secondary texture", Float) = 0

		// Lighting
		//_SectorAmbient("Sector Ambient light", Vector) = (1,1,1,1)
		_SectorFog("Sector fog", Vector) = (0,0,0,0)
		_SectorFogParams("Sector fog params", Vector) = (0,0,0,0)
	}
	SubShader{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" }
		ZWrite Off
		Cull Off
		Pass{
			Tags{ "LightMode" = "ForwardBase" }
			Blend SrcAlpha One
			//Blend One One
			// pass for ambient light and first light source

			CGPROGRAM

			#pragma vertex vert  
			#pragma fragment frag
			#pragma multi_compile_fog

			#include "GouraudShared.cginc"

			v2f vert(appdata_full v) {
				return process_vert(v, 0.0);
			}
			float4 frag(v2f i) : COLOR{
				return process_frag(i, 0.0, 1.0);
			}
			ENDCG
		}
		Pass{
			Tags{ "LightMode" = "ForwardAdd" }
			Blend SrcAlpha One
			// pass for additional light sources
			//Blend One One // additive blending 

			CGPROGRAM

			#pragma vertex vert  
			#pragma fragment frag 
			#pragma multi_compile_fog

			#include "GouraudShared.cginc"

			v2f vert(appdata_full v) {
				return process_vert(v, 1.0);
			}
			float4 frag(v2f i) : COLOR{
				return process_frag(i, 0.0, 1.0);
			}
			ENDCG
		}

	}
	Fallback "Specular"
}