// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/NewSpriteShader"
{
	Properties
     {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _ColorFactorChanger("Color Factor Changer", Range(0,1)) = 0
     }
     SubShader
     {
         Tags 
         { 
             "RenderType" = "Opaque" 
             "Queue" = "Transparent+1" 
         }
 
         Pass
         {
             ZWrite Off
             Blend SrcAlpha OneMinusSrcAlpha 
  
             CGPROGRAM
             #pragma vertex vert
             #pragma fragment frag
             #pragma multi_compile DUMMY PIXELSNAP_ON
  
             sampler2D _MainTex;
             float4 _Color;
             float _ColorFactorChanger;
 
             struct Vertex
             {
                 float4 vertex : POSITION;
                 float2 uv_MainTex : TEXCOORD0;
                 float2 uv2 : TEXCOORD1;
             };
     
             struct Fragment
             {
                 float4 vertex : POSITION;
                 float2 uv_MainTex : TEXCOORD0;
                 float2 uv2 : TEXCOORD1;
             };
  
             Fragment vert(Vertex v)
             {
                 Fragment o;
     
                 o.vertex = UnityObjectToClipPos(v.vertex);
                 o.uv_MainTex = v.uv_MainTex;
                 o.uv2 = v.uv2;
     
                 return o;
             }

             inline float3 applyHue(float3 aColor, float aHue)
			 {
			     float angle = radians(aHue);
			     float3 k = float3(0.57735, 0.57735, 0.57735);
			     float cosAngle = cos(angle);
			     //Rodrigues' rotation formula
			     return aColor * cosAngle + cross(k, aColor) * sin(angle) + k * dot(k, aColor) * (1 - cosAngle);
			 }
                                                     
             float4 frag(Fragment IN) : COLOR
             {
                 float4 o = float4(1, 0, 0, 0.2);
 
                 half4 c = tex2D (_MainTex, IN.uv_MainTex);
                 o.rgb = applyHue(c, _ColorFactorChanger * 360);
                 o.a = c.a;
                 return o;
             }
 
             ENDCG
         }
     }
}
