Shader "Custom/ShakerFx" {
	Properties {
		_MainTex("Texture", 2D) = "white"{}
		_Color ("Color", Color) = (1,1,1,1)
		
	}
	SubShader
	{

		Cull Off
		ZTest Always
		Zwrite Off

		Tags{ "RenderType" = "opawue" }
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
			float4 vertex : POSITION;
			float2 uv : TEXCOORD0;
			};

			struct v2f
			{
			float2 uv : TEXCOORD0;
			float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float2 _blur_vec;
			
			v2f vert(appdata v)
			{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			o.uv = TRANSFORM_TEX(v.uv, _MainTex);
			return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float pix_w = 1.0;
				float pix_h = 1.0;
				float2 uv = float2(i.uv);
				fixed4 col = tex2D(_MainTex, uv);

				fixed4 col_s[5];
				fixed4 col_s2[5];
				
				_blur_vec /= 2.0;
				for (int i = 0; i < 5; i++) {
					col_s[i] = tex2D(_MainTex, uv + float2(-pix_w * float(i)*_blur_vec.x, -pix_h * float(i)*_blur_vec.y));
					col_s2[i] = tex2D(_MainTex, uv + float2(pix_w*float(i)*_blur_vec.x, pix_h*float(i)*_blur_vec.y));
				}

				col_s[0] = (col_s[0] + col_s[1] + col_s[2] + col_s[3] + col_s[4]) / 5.0;
				col_s2[0] = (col_s2[0] + col_s2[1] + col_s2[2] + col_s2[3] + col_s2[4]) / 5.0;
				col = fixed4((col_s[0] + col_s2[0])) / 2.0;

				return col;
			}
			ENDCG
		}
	}
		
}
