Shader "Custom/BlackWhiteFx" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex("Texture", 2D) = "white" {}
		_Threshold("Threshold", Float) = 0.5

	}
	SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#pragma target 3.0
			 

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

		v2f vert(appdata v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			o.uv = TRANSFORM_TEX(v.uv, _MainTex);
			return o;
		}

		fixed4 frag(v2f i) : SV_Target
		{
			fixed4 col = tex2D(_MainTex, i.uv);
			float bh = 0.299*col.r + 0.587*col.g + 0.114*col.b;
			fixed4 mono;
			if (bh > 0.5) {
				mono = fixed4(1.0, 1.0, 1.0, 1.0);
			}
			else {
				mono = fixed4(.0, .0, .0, 1.0);
			}
			
			return mono;
		}
		ENDCG
		}
	}
}
