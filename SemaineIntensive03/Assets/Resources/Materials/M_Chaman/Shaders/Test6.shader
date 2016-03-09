// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:32862,y:32765,varname:node_4795,prsc:2|emission-4182-RGB,clip-2177-OUT;n:type:ShaderForge.SFN_Fresnel,id:9508,x:32153,y:32944,varname:node_9508,prsc:2|EXP-6671-OUT;n:type:ShaderForge.SFN_Vector1,id:6671,x:31952,y:33019,varname:node_6671,prsc:2,v1:0.99;n:type:ShaderForge.SFN_Tex2d,id:2363,x:31997,y:33142,ptovrint:False,ptlb:node_2363,ptin:_node_2363,varname:node_2363,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:53f9b9fe3d338084d8df8f36cc32d4ff,ntxv:0,isnm:False|UVIN-6698-UVOUT;n:type:ShaderForge.SFN_Add,id:2177,x:32552,y:33020,varname:node_2177,prsc:2|A-9508-OUT,B-2136-OUT;n:type:ShaderForge.SFN_TexCoord,id:4978,x:31551,y:33132,varname:node_4978,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:6698,x:31734,y:33132,varname:node_6698,prsc:2,spu:0.1,spv:0.1|UVIN-4978-UVOUT;n:type:ShaderForge.SFN_Panner,id:876,x:31734,y:33291,varname:node_876,prsc:2,spu:-0.2,spv:0.2|UVIN-1646-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:1646,x:31571,y:33291,varname:node_1646,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:6848,x:31930,y:33291,ptovrint:False,ptlb:node_2363_copy,ptin:_node_2363_copy,varname:_node_2363_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:53f9b9fe3d338084d8df8f36cc32d4ff,ntxv:0,isnm:False|UVIN-876-UVOUT;n:type:ShaderForge.SFN_Add,id:8270,x:32168,y:33194,varname:node_8270,prsc:2|A-2363-R,B-6848-R;n:type:ShaderForge.SFN_Color,id:4182,x:32159,y:32550,ptovrint:False,ptlb:node_1320_copy,ptin:_node_1320_copy,varname:_node_1320_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3739187,c2:0.9779412,c3:0.9029591,c4:1;n:type:ShaderForge.SFN_RemapRange,id:2136,x:32338,y:33194,varname:node_2136,prsc:2,frmn:-1,frmx:1,tomn:-0.5,tomx:0.5|IN-8270-OUT;proporder:2363-6848-4182;pass:END;sub:END;*/

Shader "Shader Forge/Test6" {
    Properties {
        _node_2363 ("node_2363", 2D) = "white" {}
        _node_2363_copy ("node_2363_copy", 2D) = "white" {}
        _node_1320_copy ("node_1320_copy", Color) = (0.3739187,0.9779412,0.9029591,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _node_2363; uniform float4 _node_2363_ST;
            uniform sampler2D _node_2363_copy; uniform float4 _node_2363_copy_ST;
            uniform float4 _node_1320_copy;
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
                float4 node_3061 = _Time + _TimeEditor;
                float2 node_6698 = (i.uv0+node_3061.g*float2(0.1,0.1));
                float4 _node_2363_var = tex2D(_node_2363,TRANSFORM_TEX(node_6698, _node_2363));
                float2 node_876 = (i.uv0+node_3061.g*float2(-0.2,0.2));
                float4 _node_2363_copy_var = tex2D(_node_2363_copy,TRANSFORM_TEX(node_876, _node_2363_copy));
                clip((pow(1.0-max(0,dot(normalDirection, viewDirection)),0.99)+((_node_2363_var.r+_node_2363_copy_var.r)*0.5+0.0)) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = _node_1320_copy.rgb;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
