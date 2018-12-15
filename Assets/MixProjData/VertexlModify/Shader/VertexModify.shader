Shader "VertexMovify/VertexModify" {
	Properties {
		[HDR]
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_MoveSpeed("MoveSpeed", Float) = 2.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard vertex:vert
		#pragma target 3.0

		sampler2D _MainTex;
		float _MoveSpeed;

		struct Input {
			float2 uv_MainTex;
		};

        float rand(float2 co) {
            return frac(sin(dot(co.xy, float2(12.9898, 78.233))) * 43758.5453);
        }

		void vert(inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			v.vertex.xyz += v.normal * (abs(sin(_Time.y * 5.0 + v.vertex.x*100.0)) * 2.5*rand(v.vertex.xy));
		}

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		UNITY_INSTANCING_BUFFER_START(Props)
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			//o.Metallic = _Metallic;
			//o.Smoothness = _Glossiness
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
