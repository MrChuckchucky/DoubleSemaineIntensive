// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:33122,y:32718,varname:node_4795,prsc:2|emission-797-RGB,alpha-4609-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:31908,y:32546,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2393,x:32403,y:32785,varname:node_2393,prsc:2|A-6074-RGB,B-2053-RGB,C-797-RGB,D-9248-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:31867,y:32743,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:31864,y:32902,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6397059,c2:0.8509128,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:31864,y:33071,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Tex2d,id:8682,x:32176,y:33198,ptovrint:False,ptlb:node_8682,ptin:_node_8682,varname:node_8682,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:53f9b9fe3d338084d8df8f36cc32d4ff,ntxv:0,isnm:False|UVIN-7291-UVOUT;n:type:ShaderForge.SFN_Panner,id:7291,x:31984,y:33198,varname:node_7291,prsc:2,spu:0.05,spv:0.1|UVIN-7612-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:4046,x:31490,y:33202,varname:node_4046,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:651,x:32101,y:33380,ptovrint:False,ptlb:node_8682_copy,ptin:_node_8682_copy,varname:_node_8682_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:53f9b9fe3d338084d8df8f36cc32d4ff,ntxv:0,isnm:False|UVIN-6295-UVOUT;n:type:ShaderForge.SFN_Panner,id:6295,x:31912,y:33409,varname:node_6295,prsc:2,spu:-0.05,spv:-0.1|UVIN-7239-UVOUT;n:type:ShaderForge.SFN_Rotator,id:4982,x:31788,y:33612,varname:node_4982,prsc:2|UVIN-4046-UVOUT,SPD-7728-OUT;n:type:ShaderForge.SFN_Tex2d,id:612,x:32159,y:33609,ptovrint:False,ptlb:n,ptin:_n,varname:_node_8682_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:53f9b9fe3d338084d8df8f36cc32d4ff,ntxv:0,isnm:False|UVIN-9420-UVOUT;n:type:ShaderForge.SFN_Vector1,id:7728,x:31534,y:33612,varname:node_7728,prsc:2,v1:-0.01;n:type:ShaderForge.SFN_Add,id:6122,x:32414,y:33309,varname:node_6122,prsc:2|A-8682-R,B-651-R;n:type:ShaderForge.SFN_Add,id:9503,x:32730,y:33322,varname:node_9503,prsc:2|A-6122-OUT,B-6487-OUT;n:type:ShaderForge.SFN_Rotator,id:7612,x:31784,y:33208,varname:node_7612,prsc:2|UVIN-4046-UVOUT,SPD-3755-OUT;n:type:ShaderForge.SFN_Vector1,id:3755,x:31490,y:33414,varname:node_3755,prsc:2,v1:0.05;n:type:ShaderForge.SFN_Rotator,id:7239,x:31719,y:33380,varname:node_7239,prsc:2|UVIN-4046-UVOUT,SPD-2527-OUT;n:type:ShaderForge.SFN_Vector1,id:2527,x:31508,y:33478,varname:node_2527,prsc:2,v1:-0.05;n:type:ShaderForge.SFN_Panner,id:9420,x:31970,y:33609,varname:node_9420,prsc:2,spu:0.05,spv:-0.1|UVIN-4982-UVOUT;n:type:ShaderForge.SFN_NormalVector,id:7115,x:32258,y:33084,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:2618,x:32448,y:33094,varname:node_2618,prsc:2|A-7115-OUT;n:type:ShaderForge.SFN_RemapRange,id:8894,x:32600,y:33291,varname:node_8894,prsc:2,frmn:-1,frmx:1,tomn:0.1,tomx:0.2|IN-6122-OUT;n:type:ShaderForge.SFN_RemapRange,id:6487,x:32333,y:33629,varname:node_6487,prsc:2,frmn:-1,frmx:1,tomn:-0.2,tomx:0.2|IN-612-R;n:type:ShaderForge.SFN_Fresnel,id:3142,x:32600,y:33094,varname:node_3142,prsc:2|EXP-2838-OUT;n:type:ShaderForge.SFN_Vector1,id:2838,x:32448,y:33017,varname:node_2838,prsc:2,v1:0.9;n:type:ShaderForge.SFN_Multiply,id:2668,x:32790,y:32991,varname:node_2668,prsc:2|A-3142-OUT,B-797-RGB;n:type:ShaderForge.SFN_Add,id:4609,x:32854,y:33124,varname:node_4609,prsc:2|A-3142-OUT,B-9503-OUT;proporder:6074-797-8682-651-612;pass:END;sub:END;*/

Shader "Shader Forge/Test5" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.6397059,0.8509128,1,1)
        _node_8682 ("node_8682", 2D) = "white" {}
        _node_8682_copy ("node_8682_copy", 2D) = "white" {}
        _n ("n", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _TintColor;
            uniform sampler2D _node_8682; uniform float4 _node_8682_ST;
            uniform sampler2D _node_8682_copy; uniform float4 _node_8682_copy_ST;
            uniform sampler2D _n; uniform float4 _n_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float3 emissive = _TintColor.rgb;
                float3 finalColor = emissive;
                float node_3142 = pow(1.0-max(0,dot(normalDirection, viewDirection)),0.9);
                float4 node_9179 = _Time + _TimeEditor;
                float node_7612_ang = node_9179.g;
                float node_7612_spd = 0.05;
                float node_7612_cos = cos(node_7612_spd*node_7612_ang);
                float node_7612_sin = sin(node_7612_spd*node_7612_ang);
                float2 node_7612_piv = float2(0.5,0.5);
                float2 node_7612 = (mul(i.uv0-node_7612_piv,float2x2( node_7612_cos, -node_7612_sin, node_7612_sin, node_7612_cos))+node_7612_piv);
                float2 node_7291 = (node_7612+node_9179.g*float2(0.05,0.1));
                float4 _node_8682_var = tex2D(_node_8682,TRANSFORM_TEX(node_7291, _node_8682));
                float node_7239_ang = node_9179.g;
                float node_7239_spd = (-0.05);
                float node_7239_cos = cos(node_7239_spd*node_7239_ang);
                float node_7239_sin = sin(node_7239_spd*node_7239_ang);
                float2 node_7239_piv = float2(0.5,0.5);
                float2 node_7239 = (mul(i.uv0-node_7239_piv,float2x2( node_7239_cos, -node_7239_sin, node_7239_sin, node_7239_cos))+node_7239_piv);
                float2 node_6295 = (node_7239+node_9179.g*float2(-0.05,-0.1));
                float4 _node_8682_copy_var = tex2D(_node_8682_copy,TRANSFORM_TEX(node_6295, _node_8682_copy));
                float node_6122 = (_node_8682_var.r+_node_8682_copy_var.r);
                float node_4982_ang = node_9179.g;
                float node_4982_spd = (-0.01);
                float node_4982_cos = cos(node_4982_spd*node_4982_ang);
                float node_4982_sin = sin(node_4982_spd*node_4982_ang);
                float2 node_4982_piv = float2(0.5,0.5);
                float2 node_4982 = (mul(i.uv0-node_4982_piv,float2x2( node_4982_cos, -node_4982_sin, node_4982_sin, node_4982_cos))+node_4982_piv);
                float2 node_9420 = (node_4982+node_9179.g*float2(0.05,-0.1));
                float4 _n_var = tex2D(_n,TRANSFORM_TEX(node_9420, _n));
                fixed4 finalRGBA = fixed4(finalColor,(node_3142+(node_6122+(_n_var.r*0.2+0.0))));
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
