// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:2,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:False,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32200,y:32691|emission-185-OUT,voffset-37-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:32970,y:32493,ptlb:Texture,ptin:_Texture,tex:989cb0c502b59264fb0897c942508b41,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Time,id:21,x:33405,y:32864;n:type:ShaderForge.SFN_Sin,id:22,x:33006,y:32930|IN-195-OUT;n:type:ShaderForge.SFN_Multiply,id:23,x:32817,y:32972|A-22-OUT,B-24-OUT;n:type:ShaderForge.SFN_ValueProperty,id:24,x:33066,y:33214,ptlb:Amplitude,ptin:_Amplitude,glob:False,v1:20;n:type:ShaderForge.SFN_Append,id:30,x:32637,y:33028|A-36-OUT,B-23-OUT;n:type:ShaderForge.SFN_Vector1,id:36,x:32840,y:33228,v1:0;n:type:ShaderForge.SFN_Append,id:37,x:32476,y:33108|A-36-OUT,B-30-OUT;n:type:ShaderForge.SFN_Multiply,id:166,x:33295,y:33047|A-21-T,B-167-OUT;n:type:ShaderForge.SFN_ValueProperty,id:167,x:33552,y:33157,ptlb:Vitesse,ptin:_Vitesse,glob:False,v1:0.4;n:type:ShaderForge.SFN_Multiply,id:185,x:32459,y:32700|A-239-OUT,B-186-RGB;n:type:ShaderForge.SFN_Color,id:186,x:32743,y:32550,ptlb:Color,ptin:_Color,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:194,x:33551,y:32648;n:type:ShaderForge.SFN_Add,id:195,x:33175,y:32769|A-166-OUT,B-221-OUT;n:type:ShaderForge.SFN_ValueProperty,id:220,x:33441,y:32576,ptlb:Offset,ptin:_Offset,glob:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:221,x:33299,y:32648|A-220-OUT,B-194-R;n:type:ShaderForge.SFN_Multiply,id:239,x:32727,y:32757|A-2-RGB,B-256-OUT;n:type:ShaderForge.SFN_Abs,id:248,x:32949,y:32791|IN-22-OUT;n:type:ShaderForge.SFN_Clamp,id:256,x:33017,y:32661|IN-248-OUT,MIN-260-OUT,MAX-258-OUT;n:type:ShaderForge.SFN_Vector1,id:258,x:33143,y:32582,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:260,x:33166,y:32520,ptlb:Opacité min,ptin:_Opacitmin,glob:False,v1:0;proporder:2-24-167-186-220-260;pass:END;sub:END;*/

Shader "Custom/sunshine" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _Amplitude ("Amplitude", Float ) = 20
        _Vitesse ("Vitesse", Float ) = 0.4
        _Color ("Color", Color) = (1,1,1,1)
        _Offset ("Offset", Float ) = 0
        _Opacitmin ("Opacité min", Float ) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _Amplitude;
            uniform float _Vitesse;
            uniform float4 _Color;
            uniform float _Offset;
            uniform float _Opacitmin;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                float node_36 = 0.0;
                float4 node_21 = _Time + _TimeEditor;
                float node_22 = sin(((node_21.g*_Vitesse)+(_Offset*o.vertexColor.r)));
                v.vertex.xyz += float3(node_36,float2(node_36,(node_22*_Amplitude)));
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float2 node_268 = i.uv0;
                float4 node_21 = _Time + _TimeEditor;
                float node_22 = sin(((node_21.g*_Vitesse)+(_Offset*i.vertexColor.r)));
                float3 emissive = ((tex2D(_Texture,TRANSFORM_TEX(node_268.rg, _Texture)).rgb*clamp(abs(node_22),_Opacitmin,1.0))*_Color.rgb);
                float3 finalColor = emissive;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCollector"
            Tags {
                "LightMode"="ShadowCollector"
            }
            
            Fog {Mode Off}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCOLLECTOR
            #define SHADOW_COLLECTOR_PASS
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcollector
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Amplitude;
            uniform float _Vitesse;
            uniform float _Offset;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_COLLECTOR;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.vertexColor = v.vertexColor;
                float node_36 = 0.0;
                float4 node_21 = _Time + _TimeEditor;
                float node_22 = sin(((node_21.g*_Vitesse)+(_Offset*o.vertexColor.r)));
                v.vertex.xyz += float3(node_36,float2(node_36,(node_22*_Amplitude)));
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_COLLECTOR(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                SHADOW_COLLECTOR_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Cull Off
            Offset 1, 1
            
            Fog {Mode Off}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Amplitude;
            uniform float _Vitesse;
            uniform float _Offset;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.vertexColor = v.vertexColor;
                float node_36 = 0.0;
                float4 node_21 = _Time + _TimeEditor;
                float node_22 = sin(((node_21.g*_Vitesse)+(_Offset*o.vertexColor.r)));
                v.vertex.xyz += float3(node_36,float2(node_36,(node_22*_Amplitude)));
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
