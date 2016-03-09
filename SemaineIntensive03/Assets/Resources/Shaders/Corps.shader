// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:33123,y:32669,varname:node_4795,prsc:2|diff-5084-RGB,emission-8865-RGB,alpha-9832-OUT;n:type:ShaderForge.SFN_TexCoord,id:124,x:31485,y:32990,varname:node_124,prsc:2,uv:0;n:type:ShaderForge.SFN_Rotator,id:7040,x:31719,y:32990,varname:node_7040,prsc:2|UVIN-124-UVOUT,SPD-4013-OUT;n:type:ShaderForge.SFN_Panner,id:8794,x:31895,y:32990,varname:node_8794,prsc:2,spu:0.05,spv:0.01|UVIN-7040-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:593,x:32074,y:32990,varname:node_593,prsc:2,tex:53f9b9fe3d338084d8df8f36cc32d4ff,ntxv:0,isnm:False|UVIN-8794-UVOUT,TEX-6688-TEX;n:type:ShaderForge.SFN_Vector1,id:4013,x:31422,y:33165,varname:node_4013,prsc:2,v1:0.05;n:type:ShaderForge.SFN_Rotator,id:8935,x:31719,y:33210,varname:node_8935,prsc:2|UVIN-124-UVOUT,SPD-8591-OUT;n:type:ShaderForge.SFN_Vector1,id:8591,x:31422,y:33279,varname:node_8591,prsc:2,v1:-0.05;n:type:ShaderForge.SFN_Panner,id:5821,x:31895,y:33210,varname:node_5821,prsc:2,spu:0.05,spv:0.01|UVIN-8935-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:5174,x:32074,y:33210,varname:_node_593_copy,prsc:2,tex:53f9b9fe3d338084d8df8f36cc32d4ff,ntxv:0,isnm:False|UVIN-5821-UVOUT,TEX-6688-TEX;n:type:ShaderForge.SFN_Add,id:6473,x:32238,y:33070,varname:node_6473,prsc:2|A-593-R,B-5174-R;n:type:ShaderForge.SFN_Rotator,id:2974,x:31719,y:33450,varname:node_2974,prsc:2|UVIN-124-UVOUT,SPD-5535-OUT;n:type:ShaderForge.SFN_Panner,id:9507,x:31906,y:33440,varname:node_9507,prsc:2,spu:-0.05,spv:-0.01|UVIN-2974-UVOUT;n:type:ShaderForge.SFN_Vector1,id:5535,x:31478,y:33461,varname:node_5535,prsc:2,v1:-0.01;n:type:ShaderForge.SFN_Tex2d,id:175,x:32101,y:33440,varname:_node_593_copy_copy,prsc:2,tex:53f9b9fe3d338084d8df8f36cc32d4ff,ntxv:0,isnm:False|UVIN-9507-UVOUT,TEX-6688-TEX;n:type:ShaderForge.SFN_RemapRange,id:4158,x:32302,y:33440,varname:node_4158,prsc:2,frmn:-1,frmx:1,tomn:-0.2,tomx:0.2|IN-175-R;n:type:ShaderForge.SFN_Add,id:8566,x:32272,y:33227,varname:node_8566,prsc:2|A-6473-OUT,B-4158-OUT;n:type:ShaderForge.SFN_Fresnel,id:9115,x:32461,y:32889,varname:node_9115,prsc:2|NRM-6330-OUT,EXP-2546-OUT;n:type:ShaderForge.SFN_NormalVector,id:6330,x:32090,y:32788,prsc:2,pt:False;n:type:ShaderForge.SFN_Vector1,id:2546,x:32207,y:32923,varname:node_2546,prsc:2,v1:0.9;n:type:ShaderForge.SFN_Add,id:3770,x:32608,y:33043,varname:node_3770,prsc:2|A-9115-OUT,B-645-OUT;n:type:ShaderForge.SFN_Color,id:5217,x:32507,y:32511,ptovrint:False,ptlb:node_5217,ptin:_node_5217,varname:node_5217,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5812067,c2:0.8352225,c3:0.9191176,c4:1;n:type:ShaderForge.SFN_Clamp01,id:9832,x:32941,y:32973,varname:node_9832,prsc:2|IN-8723-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:6688,x:31729,y:33672,ptovrint:False,ptlb:node_6688,ptin:_node_6688,varname:node_6688,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:53f9b9fe3d338084d8df8f36cc32d4ff,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6362,x:32706,y:33326,ptovrint:False,ptlb:node_6362,ptin:_node_6362,varname:node_6362,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:278fdefbb78337d46aac9abdf42a3e0f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:8723,x:32786,y:33108,varname:node_8723,prsc:2|A-3770-OUT,B-6362-R;n:type:ShaderForge.SFN_Color,id:635,x:32795,y:32513,ptovrint:False,ptlb:node_635,ptin:_node_635,varname:node_635,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3027681,c2:0.3236486,c3:0.7352941,c4:1;n:type:ShaderForge.SFN_Tex2d,id:6995,x:32618,y:32732,ptovrint:False,ptlb:node_6995,ptin:_node_6995,varname:node_6995,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:278fdefbb78337d46aac9abdf42a3e0f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_OneMinus,id:9924,x:32837,y:32792,varname:node_9924,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:645,x:32454,y:33139,varname:node_645,prsc:2,frmn:-1,frmx:1,tomn:-0.9,tomx:0.9|IN-8566-OUT;n:type:ShaderForge.SFN_Tex2d,id:8865,x:32272,y:32510,ptovrint:False,ptlb:node_8865,ptin:_node_8865,varname:node_8865,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:01399698eebbbac43978d8624e4315ee,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5084,x:32777,y:32273,ptovrint:False,ptlb:node_5084,ptin:_node_5084,varname:node_5084,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:df491c6e51638fb4cb32c787c63a2666,ntxv:0,isnm:False;proporder:5217-6688-6362-635-6995-8865-5084;pass:END;sub:END;*/

Shader "Shader Forge/Corps" {
    Properties {
        _node_5217 ("node_5217", Color) = (0.5812067,0.8352225,0.9191176,1)
        _node_6688 ("node_6688", 2D) = "white" {}
        _node_6362 ("node_6362", 2D) = "white" {}
        _node_635 ("node_635", Color) = (0.3027681,0.3236486,0.7352941,1)
        _node_6995 ("node_6995", 2D) = "white" {}
        _node_8865 ("node_8865", 2D) = "white" {}
        _node_5084 ("node_5084", 2D) = "white" {}
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
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _node_6688; uniform float4 _node_6688_ST;
            uniform sampler2D _node_6362; uniform float4 _node_6362_ST;
            uniform sampler2D _node_8865; uniform float4 _node_8865_ST;
            uniform sampler2D _node_5084; uniform float4 _node_5084_ST;
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
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _node_5084_var = tex2D(_node_5084,TRANSFORM_TEX(i.uv0, _node_5084));
                float3 diffuseColor = _node_5084_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _node_8865_var = tex2D(_node_8865,TRANSFORM_TEX(i.uv0, _node_8865));
                float3 emissive = _node_8865_var.rgb;
/// Final Color:
                float3 finalColor = diffuse + emissive;
                float4 node_5560 = _Time + _TimeEditor;
                float node_7040_ang = node_5560.g;
                float node_7040_spd = 0.05;
                float node_7040_cos = cos(node_7040_spd*node_7040_ang);
                float node_7040_sin = sin(node_7040_spd*node_7040_ang);
                float2 node_7040_piv = float2(0.5,0.5);
                float2 node_7040 = (mul(i.uv0-node_7040_piv,float2x2( node_7040_cos, -node_7040_sin, node_7040_sin, node_7040_cos))+node_7040_piv);
                float2 node_8794 = (node_7040+node_5560.g*float2(0.05,0.01));
                float4 node_593 = tex2D(_node_6688,TRANSFORM_TEX(node_8794, _node_6688));
                float node_8935_ang = node_5560.g;
                float node_8935_spd = (-0.05);
                float node_8935_cos = cos(node_8935_spd*node_8935_ang);
                float node_8935_sin = sin(node_8935_spd*node_8935_ang);
                float2 node_8935_piv = float2(0.5,0.5);
                float2 node_8935 = (mul(i.uv0-node_8935_piv,float2x2( node_8935_cos, -node_8935_sin, node_8935_sin, node_8935_cos))+node_8935_piv);
                float2 node_5821 = (node_8935+node_5560.g*float2(0.05,0.01));
                float4 _node_593_copy = tex2D(_node_6688,TRANSFORM_TEX(node_5821, _node_6688));
                float node_2974_ang = node_5560.g;
                float node_2974_spd = (-0.01);
                float node_2974_cos = cos(node_2974_spd*node_2974_ang);
                float node_2974_sin = sin(node_2974_spd*node_2974_ang);
                float2 node_2974_piv = float2(0.5,0.5);
                float2 node_2974 = (mul(i.uv0-node_2974_piv,float2x2( node_2974_cos, -node_2974_sin, node_2974_sin, node_2974_cos))+node_2974_piv);
                float2 node_9507 = (node_2974+node_5560.g*float2(-0.05,-0.01));
                float4 _node_593_copy_copy = tex2D(_node_6688,TRANSFORM_TEX(node_9507, _node_6688));
                float4 _node_6362_var = tex2D(_node_6362,TRANSFORM_TEX(i.uv0, _node_6362));
                fixed4 finalRGBA = fixed4(finalColor,saturate(((pow(1.0-max(0,dot(i.normalDir, viewDirection)),0.9)+(((node_593.r+_node_593_copy.r)+(_node_593_copy_copy.r*0.2+0.0))*0.9+0.0))+_node_6362_var.r)));
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _node_6688; uniform float4 _node_6688_ST;
            uniform sampler2D _node_6362; uniform float4 _node_6362_ST;
            uniform sampler2D _node_8865; uniform float4 _node_8865_ST;
            uniform sampler2D _node_5084; uniform float4 _node_5084_ST;
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
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _node_5084_var = tex2D(_node_5084,TRANSFORM_TEX(i.uv0, _node_5084));
                float3 diffuseColor = _node_5084_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float4 node_8146 = _Time + _TimeEditor;
                float node_7040_ang = node_8146.g;
                float node_7040_spd = 0.05;
                float node_7040_cos = cos(node_7040_spd*node_7040_ang);
                float node_7040_sin = sin(node_7040_spd*node_7040_ang);
                float2 node_7040_piv = float2(0.5,0.5);
                float2 node_7040 = (mul(i.uv0-node_7040_piv,float2x2( node_7040_cos, -node_7040_sin, node_7040_sin, node_7040_cos))+node_7040_piv);
                float2 node_8794 = (node_7040+node_8146.g*float2(0.05,0.01));
                float4 node_593 = tex2D(_node_6688,TRANSFORM_TEX(node_8794, _node_6688));
                float node_8935_ang = node_8146.g;
                float node_8935_spd = (-0.05);
                float node_8935_cos = cos(node_8935_spd*node_8935_ang);
                float node_8935_sin = sin(node_8935_spd*node_8935_ang);
                float2 node_8935_piv = float2(0.5,0.5);
                float2 node_8935 = (mul(i.uv0-node_8935_piv,float2x2( node_8935_cos, -node_8935_sin, node_8935_sin, node_8935_cos))+node_8935_piv);
                float2 node_5821 = (node_8935+node_8146.g*float2(0.05,0.01));
                float4 _node_593_copy = tex2D(_node_6688,TRANSFORM_TEX(node_5821, _node_6688));
                float node_2974_ang = node_8146.g;
                float node_2974_spd = (-0.01);
                float node_2974_cos = cos(node_2974_spd*node_2974_ang);
                float node_2974_sin = sin(node_2974_spd*node_2974_ang);
                float2 node_2974_piv = float2(0.5,0.5);
                float2 node_2974 = (mul(i.uv0-node_2974_piv,float2x2( node_2974_cos, -node_2974_sin, node_2974_sin, node_2974_cos))+node_2974_piv);
                float2 node_9507 = (node_2974+node_8146.g*float2(-0.05,-0.01));
                float4 _node_593_copy_copy = tex2D(_node_6688,TRANSFORM_TEX(node_9507, _node_6688));
                float4 _node_6362_var = tex2D(_node_6362,TRANSFORM_TEX(i.uv0, _node_6362));
                fixed4 finalRGBA = fixed4(finalColor * saturate(((pow(1.0-max(0,dot(i.normalDir, viewDirection)),0.9)+(((node_593.r+_node_593_copy.r)+(_node_593_copy_copy.r*0.2+0.0))*0.9+0.0))+_node_6362_var.r)),0);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
