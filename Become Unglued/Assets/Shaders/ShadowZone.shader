﻿Shader "Custom/PostRendering/ShadowZone"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_PixelSize ("Pixel Size", Range(0.001, 0.1)) = 1.0
		_ColorSpace ("Color Space", Range(1.0, 255)) = 8.0
		_Negative ("Negative", Range(0.1, 1)) = 0.0
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float _PixelSize;
			float _ColorSpace;
			float _Negative;

			fixed4 frag(v2f_img i) : SV_Target
			{
				fixed4 col;
				float ratioX = (int)(i.uv.x / _PixelSize) * _PixelSize;
				float ratioY = (int)(i.uv.y / _PixelSize) * _PixelSize;
				col = tex2D(_MainTex, float2(ratioX, ratioY));

				float r = ceil(col[0] * 255.0 / _ColorSpace) * _ColorSpace / 256.0;
				float g = ceil(col[1] * 255.0 / _ColorSpace) * _ColorSpace / 256.0;
				float b = ceil(col[2] * 255.0 / _ColorSpace) * _ColorSpace / 256.0;

				col = fixed4(1 - (r / _Negative),1 -( g / _Negative),1 - ( b / _Negative), 1.0);
		
				return col;
			}

			ENDCG
		}
	}
}