Shader "SoundVertexMovify/VertexModify" {
	Properties {
		[HDR]
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_MoveSpeed("MoveSpeed", Float) = 2.0
		_Vol("Volume", Float) = 0.0
		_BufferVol("BufferVol", Float) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard vertex:vert
		#pragma target 3.0

		sampler2D _MainTex;
		float _MoveSpeed;
        float _Vol;
        float _BufferVol;
		struct Input {
			float2 uv_MainTex;
		};

		void vert(inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			//v.vertex.x
			float _v = smoothstep(_BufferVol, _Vol, 0.5);
			/*normal setup*/
			v.vertex.xyz += normalize(v.normal) * (sin(_Time.y)) * _Vol * 10.0;
			
			/*each vertex*/
			//v.vertex.xyz += normalize(v.normal) * (sin(_Time.y * 1.01 + v.vertex.x + v.vertex.z)) * _Vol * 10.0;
			
			/*OffSet*/
			v.vertex.xyz += normalize(v.normal) * (sin(_Time.y + v.vertex.x + v.vertex.y + v.vertex.z)) * _v * 0.5;
		}

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		UNITY_INSTANCING_BUFFER_START(Props)
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			/*
			o.Albedo.g = max(sin(_Time.y * 3.0), 0.0); 
			lerp
			*/
			o.Albedo.rgb = max(1.0*sin(_Time.y * 1.0), 0.0); 
			
			
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
