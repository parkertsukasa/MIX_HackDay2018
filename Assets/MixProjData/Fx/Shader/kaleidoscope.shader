Shader "Hidden/ConvertFx"
{
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _BlockNum("_BlockNum", Int) = 2
    }
        SubShader
    {
        Cull Off
        ZTest Always
        ZWrite Off

        Tags{ "RenderType" = "Opaque" }

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

    v2f vert(appdata v)
    {
        v2f o;
        o.vertex = UnityObjectToClipPos(v.vertex);
        o.uv = TRANSFORM_TEX(v.uv, _MainTex);
        return o;
    }

    int _BlockNum = 2;
    fixed4 frag(v2f i) : SV_Target
    {
        float n = _BlockNum;
        float2 st = frac(i.uv * n);
        float2 _st = float2(floor(i.uv.x * n), floor(i.uv.y * n));

        fixed4 col = tex2D(_MainTex, st);

        int f = 0;
        if (fmod(_st.y, 2.0)) {
            f = fmod(_st.x, 2.0);
        }
        else {
            f = fmod(floor(fmod(_st.x, 2.0) + 1), 2.0);
        }
        if (f) {
           col =  fixed4(1.0, 1.0, 1.0, 2.0) - col;
        }
        return col;

    }
        ENDCG
    }
    }
}