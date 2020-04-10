/*Please do support www.bitshiftprogrammer.com by joining the facebook page : fb.com/BitshiftProgrammer
Legal Stuff:
This code is free to use no restrictions but attribution would be appreciated.
Any damage caused either partly or completly due to usage of this stuff is not my responsibility*/
Shader "BitshiftProgrammer/Skybox"
{
	Properties
	{
		_SkyColor1("Top Color Day", Color) = (0.37, 0.52, 0.73, 0)
		_SkyColor2("Horizon Color Day", Color) = (0.89, 0.96, 1, 0)
		_SkyColor3("Top Color Night", Color) = (0.2 ,0.4 ,0.6 , 0)
		_SkyColor4("Horizon Color Night",Color) = (0.4, 0.2, 0.1, 0)
		_Transition("Transition Value",Range(0.0 , 1.0)) = 0.5
		_BaseLevel("Base Start Level",Range(-2.0 , 0.0)) = 0.0
		_GradientExponent("Gradient Exponent",Range(1,100)) = 1
		_SunColor("Sun Colour",Color) = (0.8,0.4,0.0)
		_Scaling("Sun Scaling Factor",Range(1,350)) = 10
		_SunRim("Sun Rim",Range(0.5,1.0)) = 0.8
		_Perlin("Perlin", 2D) = "white" {}
	}
		SubShader
	{
		Tags{ "RenderType" = "Opaque" "Queue" = "Background" }
		ZWrite Off
		Fog{ Mode Off }
		Cull Off
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			struct appdata
			{
				float4 position : POSITION;
				float3 texcoord : TEXCOORD0;
			};
			struct v2f
			{
				float4 position : SV_POSITION;
				float3 texcoord : TEXCOORD0;
			};

			fixed3 _SkyColor1;
			fixed3 _SkyColor2;
			fixed3 _SkyColor3;
			fixed3 _SkyColor4;
			half _Transition;
			half _BaseLevel;
			int _GradientExponent;
			fixed3 _SunColor;
			int _Scaling;
			half _SunRim;
			sampler2D _Perlin;

			v2f vert(appdata v)
			{
				v2f o;
				o.position = UnityObjectToClipPos(v.position);
				o.texcoord = v.texcoord;
				return o;
			}

			fixed4 frag(v2f i) : COLOR
			{
				half3 v = normalize(i.texcoord);
				half p = pow(v.y + _BaseLevel, _GradientExponent);
				fixed3 topCol = lerp(_SkyColor1, _SkyColor3, _Transition);
				fixed3 bottomCol = lerp(_SkyColor2, _SkyColor4, _Transition);
				half dotVal = dot(v, _WorldSpaceLightPos0.xyz);
				float4 noise = tex2D(_Perlin, i.texcoord);
				float4 color = (1,1,1,1);
				if (noise.r > 0.2)
					color = (0, 1, 1, 1);
				if (noise.r > 0.5)
					color = (0, 0, 1, 1);
				if (noise.r < 0.2) 
					color = (1, 1, 0, 1);
				if (dotVal > _SunRim)
					return lerp(fixed4(lerp(topCol, bottomCol, p), 1.0), fixed4(_SunColor,1.0), pow(dotVal, _Scaling)) * color;
				else
					return fixed4(lerp(topCol, bottomCol, p), 1.0) * noise;
			}
			ENDCG
		}
	}
}