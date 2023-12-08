Shader "Custom/HalfTone" {
    Properties {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _HatchTex ("Hatch Pattern", 2D) ="white" {}
        _PatternSize("Base Pattern Size", Float) = 100
        _HatchMap ("Hatch Detail Map", 2D) = "white" {}
        _EmissionMap ("Emission Map", 2D) = "black" {}
        _RoughMap ("Roughness Map", 2D) = "white" {}
        _Roughness ("Roughness", Range(0,1)) = 1
        _RampSteps ("Lighting Ramp Step Count", Range(1,10)) = 1
        _ColoredHatch("Colored Hatch", Float) = 0
    }

    SubShader {
        Tags {
            "RenderType"="Opaque"
            "Queue"="Geometry"
        }
        LOD 200

        Pass {
            Name "URP"
            Tags {
                "LightMode"="ForwardBase"
                "Queue"="Overlay"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Back
            ZWrite On
            ZTest LEqual
            ColorMask RGB
            Offset 5,5

            HLSLINCLUDE
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            HLSLOPTIONS
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderVariantsMeta.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/UnityInstancing.hlsl"
            HLSLDECLARE_TEXTURE(_MainTex);
            HLSLDECLARE_TEXTURE(_HatchTex);
            HLSLDECLARE_TEXTURE(_HatchMap);
            HLSLDECLARE_TEXTURE(_EmissionMap);
            HLSLDECLARE_TEXTURE(_RoughMap);
            HLSLDECLARE_SAMPLER(_MainTex);
            HLSLDECLARE_SAMPLER(_HatchTex);
            HLSLDECLARE_SAMPLER(_HatchMap);
            HLSLDECLARE_SAMPLER(_EmissionMap);
            HLSLDECLARE_SAMPLER(_RoughMap);
            HLSLDECLARE_UNIFORM(_Color);
            HLSLDECLARE_UNIFORM(_PatternSize);
            HLSLDECLARE_UNIFORM(_Roughness);
            HLSLDECLARE_UNIFORM(_RampSteps);
            HLSLDECLARE_UNIFORM(_ColoredHatch);
            HLSLDECLARE_OUT(FragInOut, o);
            ENDHLSL

            CGPROGRAM
            #pragma vertex vert
            #pragma exclude_renderers gles xbox360 ps3
            ENDCG

            HLSLINCLUDE
            Varyings addshadow;
            half4 LightingURP (FragInputs i, UnityGI gi) {
                fixed3 worldPos = i.posWorld;
                fixed3 normal = WorldNormalVector(i,worldPos);
                fixed3 viewDir = WorldSpaceViewDir(i,worldPos);

                fixed4 c = SAMPLE_TEXTURE2D(_MainTex, _MainTex_SAMPLER, i.uv);
                fixed3 r = SAMPLE_TEXTURE2D(_RoughMap, _RoughMap_SAMPLER, i.uv);
                fixed h = SAMPLE_TEXTURE2D(_HatchMap, _HatchMap_SAMPLER, i.uv);
                fixed3 e = SAMPLE_TEXTURE2D(_EmissionMap, _EmissionMap_SAMPLER, i.uv);

                FragInOut o;
                o.Albedo = c.rgb;
                o.Alpha = c.a;
                o.Normal = normal;
                o.PosWorld = worldPos;
                o.Specular = 0;
                o.Smoothness = r;
                o.Occlusion = 1;
                o.Emission = e;

                o.ScreenPos = ComputeScreenPos(o.PosWorld);
                o.ScreenPos = TRANSFORM_TEX(o.ScreenPos, _HatchTex);

                o.Col = h;
                o.NormalWorld = normal;
                o.Specular = 0;
                o.Smoothness = r;
                o.Emission = e;

                UNITY_TRANSFER_FOG(o,o.PosWorld);
                UNITY_APPLY_FOG(i.fogCoord, o.Color);
                return o.Color;
            }
            ENDHLSL
        }
    }

    FallBack "Diffuse"
}
