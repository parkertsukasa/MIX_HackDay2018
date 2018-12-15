Shader "Hidden/BadTV"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _distortion("Distortion", float) = 3.0
        _distortion2("Distortion2", float) = 5.0
        _rollSpeed("RollSpeed", float) = 0.1

       
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

            float rand(float2 co) {
                return frac(sin(dot(co.xy, float2(12.9898, 78.233))) * 43758.5453);
            }

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
                return mod289(((x*34.0)+1.0)*x);
            }

            float snoise(float2 v)
                {
                const float4 C = float4(0.211324865405187,  // (3.0-sqrt(3.0))/6.0",
                                    0.366025403784439,  // 0.5*(sqrt(3.0)-1.0)",
                                    -0.577350269189626,  // -1.0 + 2.0 * C.x",
                                    0.024390243902439); // 1.0 / 41.0",
                float2 i  = floor(v + dot(v, C.yy) );
                float2 x0 = v -   i + dot(i, C.xx);

                float2 i1;
                i1 = (x0.x > x0.y) ? float2(1.0, 0.0) : float2(0.0, 1.0);
                float4 x12 = x0.xyxy + C.xxzz;
                x12.xy -= i1;

                i = mod289(i); // Avoid truncation effects in permutation",
                float3 p = permute( permute( i.y + float3(0.0, i1.y, 1.0 ))
                    + i.x + float3(0.0, i1.x, 1.0 ));

                float3 m = max(0.5 - float3(dot(x0,x0), dot(x12.xy,x12.xy), dot(x12.zw,x12.zw)), 0.0);
                m = m*m ;
                m = m*m ;

                float3 x = 2.0 * frac(p * C.www) - 1.0;
                float3 h = abs(x) - 0.5;
                float3 ox = floor(x + 0.5);
                float3 a0 = x - ox;

                m *= 1.79284291400159 - 0.85373472095314 * ( a0*a0 + h*h );

                float3 g;
                g.x  = a0.x  * x0.x  + h.x  * x0.y;
                g.yz = a0.yz * x12.xz + h.yz * x12.yw;
                return 130.0 * dot(m, g);
            }
			
			sampler2D _MainTex;
            float _distortion;
            float _distortion2;
            float _rollSpeed;


			fixed4 frag (v2f i) : SV_Target
			{
               
                float speed = 1.0;
                float2 p = i.uv;
                float ty = _Time.z*speed;
                float yt = p.y - ty;    //高さが同じピクセルを時間で揺らす
                float offset = snoise(float2(yt*3.0,0.0))*0.2;
                offset = offset * _distortion * offset*_distortion * offset;    //大きい揺れ
                offset += snoise(float2(yt*50.0,0.0))*_distortion2*0.001;   //細かい揺れ
                fixed4 col = tex2D(_MainTex, float2(frac(p.x + offset), frac(p.y - _Time.z*_rollSpeed)));

                if (sin(_Time.y) < -0.5) {
                    col = tex2D(_MainTex, float2(frac(p.x + offset), frac(p.y - _Time.z*_rollSpeed)));
                }
                else if (sin(_Time.y) > -0.5) {
                    col = tex2D(_MainTex, float2(frac(p.x + offset), frac(p.y - _Time.z*_rollSpeed)));
                    col = fixed4(1.0, 1.0, 1.0, 2.0) - col;
                }
                
				return col;
			}
			ENDCG
		}
	}
}
