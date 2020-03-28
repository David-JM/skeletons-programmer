// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.03 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.03;sub:START;pass:START;ps:flbk:Bumped Specular,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:True,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:2,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:6859,x:33111,y:32745,varname:node_6859,prsc:2|diff-1448-OUT,spec-6615-RGB,gloss-957-OUT,normal-8984-RGB,emission-9879-OUT;n:type:ShaderForge.SFN_Tex2d,id:8984,x:32699,y:32987,ptovrint:False,ptlb:Normals,ptin:_Normals,varname:_Normals,prsc:2,tex:dc0f23193f0d5604bb437fff8649e042,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:5068,x:32340,y:32600,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:_Diffuse,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:5233,x:31616,y:33547,ptovrint:False,ptlb:Emission_Strength,ptin:_Emission_Strength,varname:_Emission_Strength,prsc:2,min:0,cur:2,max:5;n:type:ShaderForge.SFN_OneMinus,id:8124,x:31481,y:33190,varname:node_8124,prsc:2|IN-5068-A;n:type:ShaderForge.SFN_Multiply,id:9046,x:31719,y:33363,varname:node_9046,prsc:2|A-8124-OUT,B-3990-RGB;n:type:ShaderForge.SFN_Color,id:3990,x:31419,y:33414,ptovrint:False,ptlb:Emission_Color,ptin:_Emission_Color,varname:_Emission_Color,prsc:2,glob:False,c1:0.3088235,c2:0.09537197,c3:0.09537197,c4:1;n:type:ShaderForge.SFN_Slider,id:957,x:32620,y:32875,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Color,id:6615,x:32699,y:32703,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:_Specular,prsc:2,glob:False,c1:0.02319421,c2:0.07133398,c3:0.08088237,c4:1;n:type:ShaderForge.SFN_Multiply,id:1448,x:32699,y:32539,varname:node_1448,prsc:2|A-5922-RGB,B-5068-RGB;n:type:ShaderForge.SFN_Color,id:5922,x:32340,y:32354,ptovrint:False,ptlb:Diffuse_Color,ptin:_Diffuse_Color,varname:_Diffuse_Color,prsc:2,glob:False,c1:0.9852941,c2:0.9125462,c3:0.7824394,c4:1;n:type:ShaderForge.SFN_If,id:9879,x:32699,y:33157,varname:node_9879,prsc:2|A-3334-OUT,B-1675-OUT,GT-6886-OUT,EQ-2983-OUT,LT-8201-OUT;n:type:ShaderForge.SFN_Vector1,id:3334,x:32244,y:33030,varname:node_3334,prsc:2,v1:1;n:type:ShaderForge.SFN_Time,id:4615,x:31291,y:33588,varname:node_4615,prsc:2;n:type:ShaderForge.SFN_Multiply,id:498,x:31572,y:33672,varname:node_498,prsc:2|A-4615-T,B-5422-OUT;n:type:ShaderForge.SFN_Multiply,id:6323,x:31964,y:33479,varname:node_6323,prsc:2|A-9046-OUT,B-5233-OUT;n:type:ShaderForge.SFN_Multiply,id:6886,x:32202,y:33444,varname:node_6886,prsc:2|A-8124-OUT,B-6323-OUT;n:type:ShaderForge.SFN_Multiply,id:2983,x:32449,y:33501,varname:node_2983,prsc:2|A-6886-OUT,B-773-OUT;n:type:ShaderForge.SFN_Slider,id:5422,x:31188,y:33773,ptovrint:False,ptlb:Blink_Speed,ptin:_Blink_Speed,varname:node_5422,prsc:2,min:0,cur:0.6,max:3;n:type:ShaderForge.SFN_OneMinus,id:773,x:32167,y:33600,varname:node_773,prsc:2|IN-7291-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:7291,x:31976,y:33642,varname:node_7291,prsc:2,min:-0.5,max:1|IN-9164-OUT;n:type:ShaderForge.SFN_Cos,id:9164,x:31751,y:33660,varname:node_9164,prsc:2|IN-498-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1675,x:32244,y:33158,ptovrint:False,ptlb:Emission_Type,ptin:_Emission_Type,varname:node_1675,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_ObjectPosition,id:1545,x:31400,y:32808,varname:node_1545,prsc:2;n:type:ShaderForge.SFN_ViewPosition,id:6013,x:31410,y:33021,varname:node_6013,prsc:2;n:type:ShaderForge.SFN_Subtract,id:8266,x:31964,y:32985,varname:node_8266,prsc:2|A-4972-OUT,B-1852-OUT;n:type:ShaderForge.SFN_Distance,id:4972,x:31730,y:32985,varname:node_4972,prsc:2|A-1545-XYZ,B-6013-XYZ;n:type:ShaderForge.SFN_ValueProperty,id:1852,x:31719,y:33172,ptovrint:False,ptlb:Emissive_Distance,ptin:_Emissive_Distance,varname:node_1852,prsc:2,glob:False,v1:10;n:type:ShaderForge.SFN_OneMinus,id:4642,x:31964,y:33113,varname:node_4642,prsc:2|IN-8266-OUT;n:type:ShaderForge.SFN_Multiply,id:8201,x:32260,y:33264,varname:node_8201,prsc:2|A-5536-OUT,B-6886-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:5536,x:31976,y:33251,varname:node_5536,prsc:2,min:0,max:1|IN-4642-OUT;proporder:5922-6615-957-3990-5233-5068-8984-1675-5422-1852;pass:END;sub:END;*/

Shader "RockShaders/BumpedEmissive" {
    Properties {
        _Diffuse_Color ("Diffuse_Color", Color) = (0.9852941,0.9125462,0.7824394,1)
        _Specular ("Specular", Color) = (0.02319421,0.07133398,0.08088237,1)
        _Gloss ("Gloss", Range(0, 1)) = 1
        _Emission_Color ("Emission_Color", Color) = (0.3088235,0.09537197,0.09537197,1)
        _Emission_Strength ("Emission_Strength", Range(0, 5)) = 2
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Normals ("Normals", 2D) = "bump" {}
        _Emission_Type ("Emission_Type", Float ) = 0
        _Blink_Speed ("Blink_Speed", Range(0, 3)) = 0.6
        _Emissive_Distance ("Emissive_Distance", Float ) = 10
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _Normals; uniform float4 _Normals_ST;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _Emission_Strength;
            uniform float4 _Emission_Color;
            uniform float _Gloss;
            uniform float4 _Specular;
            uniform float4 _Diffuse_Color;
            uniform float _Blink_Speed;
            uniform float _Emission_Type;
            uniform float _Emissive_Distance;
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
                float3 binormalDir : TEXCOORD4;
                float4 screenPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normals_var = UnpackNormal(tex2D(_Normals,TRANSFORM_TEX(i.uv0, _Normals)));
                float3 normalLocal = _Normals_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i)*2;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = _Specular.rgb;
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb*2; // Ambient Light
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuse = (directDiffuse + indirectDiffuse) * (_Diffuse_Color.rgb*_Diffuse_var.rgb);
////// Emissive:
                float node_9879_if_leA = step(1.0,_Emission_Type);
                float node_9879_if_leB = step(_Emission_Type,1.0);
                float node_8124 = (1.0 - _Diffuse_var.a);
                float3 node_6886 = (node_8124*((node_8124*_Emission_Color.rgb)*_Emission_Strength));
                float4 node_4615 = _Time + _TimeEditor;
                float3 emissive = lerp((node_9879_if_leA*(clamp((1.0 - (distance(objPos.rgb,_WorldSpaceCameraPos)-_Emissive_Distance)),0,1)*node_6886))+(node_9879_if_leB*node_6886),(node_6886*(1.0 - clamp(cos((node_4615.g*_Blink_Speed)),-0.5,1))),node_9879_if_leA*node_9879_if_leB);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _Normals; uniform float4 _Normals_ST;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _Emission_Strength;
            uniform float4 _Emission_Color;
            uniform float _Gloss;
            uniform float4 _Specular;
            uniform float4 _Diffuse_Color;
            uniform float _Blink_Speed;
            uniform float _Emission_Type;
            uniform float _Emissive_Distance;
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
                float3 binormalDir : TEXCOORD4;
                float4 screenPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normals_var = UnpackNormal(tex2D(_Normals,TRANSFORM_TEX(i.uv0, _Normals)));
                float3 normalLocal = _Normals_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i)*2;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = _Specular.rgb;
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuse = directDiffuse * (_Diffuse_Color.rgb*_Diffuse_var.rgb);
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Bumped Specular"
    CustomEditor "ShaderForgeMaterialInspector"
}
