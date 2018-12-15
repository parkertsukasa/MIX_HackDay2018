﻿Shader "Hidden/SlicerShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
        _sliceNum("SliceNum", Int) = 10
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

            float3 mod289(float3 x) {
                return x - floor(x * (1.0 / 289.0)) * 289.0;
            }

            float2 mod289(float2 x) {
                return x - floor(x * (1.0 / 289.0)) * 289.0;
            }

            float3 permute(float3 x) {
                return mod289(((x*34.0) + 1.0)*x);
            }

            float snoise(float2 v)
            {
                const float4 C = float4(0.211324865405187,  // (3.0-sqrt(3.0))/6.0",
                    0.366025403784439,  // 0.5*(sqrt(3.0)-1.0)",
                    -0.577350269189626,  // -1.0 + 2.0 * C.x",
                    0.024390243902439); // 1.0 / 41.0",
                float2 i = floor(v + dot(v, C.yy));
                float2 x0 = v - i + dot(i, C.xx);

                float2 i1;
                i1 = (x0.x > x0.y) ? float2(1.0, 0.0) : float2(0.0, 1.0);
                float4 x12 = x0.xyxy + C.xxzz;
                x12.xy -= i1;

                i = mod289(i); // Avoid truncation effects in permutation",
                float3 p = permute(permute(i.y + float3(0.0, i1.y, 1.0))
                    + i.x + float3(0.0, i1.x, 1.0));

                float3 m = max(0.5 - float3(dot(x0, x0), dot(x12.xy, x12.xy), dot(x12.zw, x12.zw)), 0.0);
                m = m * m;
                m = m * m;

                float3 x = 2.0 * frac(p * C.www) - 1.0;
                float3 h = abs(x) - 0.5;
                float3 ox = floor(x + 0.5);
                float3 a0 = x - ox;

                m *= 1.79284291400159 - 0.85373472095314 * (a0*a0 + h * h);

                float3 g;
                g.x = a0.x  * x0.x + h.x  * x0.y;
                g.yz = a0.yz * x12.xz + h.yz * x12.yw;
                return 130.0 * dot(m, g);
            }
			
			sampler2D _MainTex;
            int _sliceNum = 10;

			fixed4 frag (v2f i) : SV_Target
			{
                float2 uv = i.uv;
                float x = floor(uv.x * _sliceNum) / _sliceNum;
                float _x = floor(uv.x * _sliceNum);
                uv += ( snoise(float2(x, uv.y)) -0.5 ) * (snoise(uv + float2(_Time.z, _Time.y)) - 0.5) * 0.5 * sin(_Time.z) * cos(_Time.z);
				fixed4 col = tex2D(_MainTex, uv);


				
                /*if (sin(_Time.y) < 0.0) {
                    col = col;
                }
                else if (sin(_Time.y) > 0.0) {
                    col = fixed4(1.0, 1.0, 1.0, 2.0) - col;
                }*/

				return col;
			}
			ENDCG
		}
	}
}
