Shader "Universal Render Pipeline/2D/SimpleSpriteOutline"
{
    Properties
    {
        _MainTex ("Sprite", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineSize ("Outline Size", Range(0, 5)) = 1
    }

    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue"="Transparent"
            "RenderPipeline"="UniversalPipeline"
            "IgnoreProjector"="True"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Sprite"
        }

        Blend One OneMinusSrcAlpha
        Cull Off
        Lighting Off
        ZWrite Off

        Pass
        {
            Name "Outline"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv         : TEXCOORD0;
                float4 color      : COLOR;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv          : TEXCOORD0;
                float4 color       : COLOR;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            float4 _MainTex_ST;
            float4 _MainTex_TexelSize;

            float4 _Color;
            float4 _OutlineColor;
            float  _OutlineSize;

            Varyings vert (Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv, _MainTex);
                OUT.color = IN.color * _Color;
                return OUT;
            }

            half4 frag (Varyings IN) : SV_Target
            {
                // Center alpha
                half4 center = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv);
                half centerA = center.a;

                // Sample neighbours (up / down / left / right)
                float2 offset = _MainTex_TexelSize.xy * _OutlineSize;

                half a1 = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv + float2( offset.x, 0)).a;
                half a2 = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv + float2(-offset.x, 0)).a;
                half a3 = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv + float2(0,  offset.y)).a;
                half a4 = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv + float2(0, -offset.y)).a;

                half outlineA = max(max(a1, a2), max(a3, a4));

                // Only keep pixels that are in outline but not in the filled sprite
                half border = saturate(outlineA - centerA + 0.001);

                float4 col;
                col.rgb = _OutlineColor.rgb;
                col.a   = border * _OutlineColor.a;

                return col;
            }
            ENDHLSL
        }
    }
}