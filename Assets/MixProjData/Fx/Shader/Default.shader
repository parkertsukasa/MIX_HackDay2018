Shader "Custom/Default" {
	Properties{
		_MainTex("-", 2D) = "white" {}
	}
		CGINCLUDE
#include "UnityCG.cginc"
		sampler2D _MainTex;

	half4 frag(v2f_img i) : SV_Target
	{
	
		return tex2D(_MainTex, i.uv);
	}
		ENDCG

		SubShader
	{
		Pass
		{
			ZTest Always Cull Off ZWrite Off
			CGPROGRAM
#pragma vertex vert_img
#pragma fragment frag
			ENDCG
		}
	}
}
