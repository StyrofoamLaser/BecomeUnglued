Shader "Custom/PostRendering/VRWorld"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "black" {}
		_PixelSize ("Pixel Size", Range(0.001, 0.1)) = 1.0
		_ColorSpace ("Color Space", Range(1.0, 255)) = 8.0
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

			fixed4 frag(v2f_img i) : SV_Target
			{
				/*fixed4 col;
				float ratioX = (int)(i.uv.x / _PixelSize) * _PixelSize;
				float ratioY = (int)(i.uv.y / _PixelSize) * _PixelSize;
				col = tex2D(_MainTex, float2(ratioX, ratioY));

				float r = ceil(col[0] * 255.0 / _ColorSpace) * _ColorSpace / 256.0;
				float g = ceil(col[1] * 255.0 / _ColorSpace) * _ColorSpace / 256.0;
				float b = ceil(col[2] * 255.0 / _ColorSpace) * _ColorSpace / 256.0;

				col = fixed4(r, g, b, 1.0);
		
				return col;*/

				fixed4 col;
				float ratioX = (int)(i.uv.x / _PixelSize) * _PixelSize;
				float ratioY = (int)(i.uv.y / _PixelSize) * _PixelSize;
				col = tex2D(_MainTex, float2(ratioX, ratioY));

				float k = pow(2.0, _ColorSpace / 3.0);

				col = floor(col * k + 0.5) / k;
		
				return col;

			}

			ENDCG
		}
	}
}