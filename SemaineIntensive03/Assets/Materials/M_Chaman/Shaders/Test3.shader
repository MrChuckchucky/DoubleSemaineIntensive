// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:33323,y:32736,varname:node_4795,prsc:2|normal-6977-RGB,emission-3581-OUT,alpha-3704-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32235,y:32601,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2393,x:32446,y:32839,varname:node_2393,prsc:2|A-6074-RGB,B-2053-RGB,C-797-RGB,D-9248-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32235,y:32772,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32235,y:32930,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32235,y:33081,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Tex2d,id:7228,x:31718,y:33351,ptovrint:False,ptlb:node_7228,ptin:_node_7228,varname:node_7228,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-6980-UVOUT;n:type:ShaderForge.SFN_Time,id:5250,x:31879,y:33550,varname:node_5250,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2572,x:32377,y:33225,varname:node_2572,prsc:2|A-9885-R,B-5336-OUT;n:type:ShaderForge.SFN_Rotator,id:6963,x:32044,y:33132,varname:node_6963,prsc:2|UVIN-6976-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:6976,x:31706,y:32735,varname:node_6976,prsc:2,uv:0;n:type:ShaderForge.SFN_ComponentMask,id:9885,x:32222,y:33132,varname:node_9885,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6963-UVOUT;n:type:ShaderForge.SFN_Add,id:5336,x:32222,y:33369,varname:node_5336,prsc:2|A-7228-R,B-9674-OUT;n:type:ShaderForge.SFN_Sin,id:9674,x:32092,y:33530,varname:node_9674,prsc:2|IN-5250-T;n:type:ShaderForge.SFN_RemapRange,id:4629,x:32438,y:33369,varname:node_4629,prsc:2,frmn:-0.5,frmx:1,tomn:0,tomx:0.5|IN-5336-OUT;n:type:ShaderForge.SFN_Fresnel,id:7726,x:32535,y:32995,varname:node_7726,prsc:2|EXP-1304-OUT;n:type:ShaderForge.SFN_Vector1,id:1304,x:32417,y:33113,varname:node_1304,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Add,id:3704,x:32591,y:33201,varname:node_3704,prsc:2|A-7726-OUT,B-4629-OUT;n:type:ShaderForge.SFN_Multiply,id:3581,x:32958,y:32873,varname:node_3581,prsc:2|A-3704-OUT,B-9419-RGB;n:type:ShaderForge.SFN_Color,id:9419,x:32666,y:32671,ptovrint:False,ptlb:node_9419,ptin:_node_9419,varname:node_9419,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4174957,c2:0.7320353,c3:0.8602941,c4:1;n:type:ShaderForge.SFN_Vector1,id:5272,x:32458,y:33679,varname:node_5272,prsc:2,v1:0;n:type:ShaderForge.SFN_Panner,id:4208,x:31368,y:33202,varname:node_4208,prsc:2,spu:0.005,spv:0.005|UVIN-6976-UVOUT;n:type:ShaderForge.SFN_Panner,id:8840,x:31646,y:33083,varname:node_8840,prsc:2,spu:0.001,spv:0.001|UVIN-6976-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6977,x:33124,y:32909,ptovrint:False,ptlb:node_6977,ptin:_node_6977,varname:node_6977,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d1342d67367dfd74c89ca01c37f0ef18,ntxv:3,isnm:True|UVIN-8840-UVOUT;n:type:ShaderForge.SFN_Rotator,id:6980,x:31507,y:33335,varname:node_6980,prsc:2|UVIN-4208-UVOUT,SPD-5215-OUT;n:type:ShaderForge.SFN_Vector1,id:5215,x:31343,y:33416,varname:node_5215,prsc:2,v1:0.01;proporder:6074-797-7228-9419-6977;pass:END;sub:END;*/

Shader "Shader Forge/Test3" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _node_7228 ("node_7228", 2D) = "white" {}
        _node_9419 ("node_9419", Color) = (0.4174957,0.7320353,0.8602941,1)
        _node_6977 ("node_6977", 2D) = "bump" {}
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
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _node_7228; uniform float4 _node_7228_ST;
            uniform float4 _node_9419;
            uniform sampler2D _node_6977; uniform float4 _node_6977_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_8801 = _Time + _TimeEditor;
                float2 node_8840 = (i.uv0+node_8801.g*float2(0.001,0.001));
                float3 _node_6977_var = UnpackNormal(tex2D(_node_6977,TRANSFORM_TEX(node_8840, _node_6977)));
                float3 normalLocal = _node_6977_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float node_6980_ang = node_8801.g;
                float node_6980_spd = 0.01;
                float node_6980_cos = cos(node_6980_spd*node_6980_ang);
                float node_6980_sin = sin(node_6980_spd*node_6980_ang);
                float2 node_6980_piv = float2(0.5,0.5);
                float2 node_6980 = (mul((i.uv0+node_8801.g*float2(0.005,0.005))-node_6980_piv,float2x2( node_6980_cos, -node_6980_sin, node_6980_sin, node_6980_cos))+node_6980_piv);
                float4 _node_7228_var = tex2D(_node_7228,TRANSFORM_TEX(node_6980, _node_7228));
                float4 node_5250 = _Time + _TimeEditor;
                float node_5336 = (_node_7228_var.r+sin(node_5250.g));
                float node_3704 = (pow(1.0-max(0,dot(normalDirection, viewDirection)),0.8)+(node_5336*0.3333333+0.1666667));
                float3 emissive = (node_3704*_node_9419.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,node_3704);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
