Shader "Custom/StancilEqual"
{
	Properties {
		_Color ("Tint", Color) = (0, 0, 0, 1)
		_MainTex ("Texture", 2D) = "white" {}
		_BumpTex("Normal Map", 2D) = "bump" {}
		_Smoothness ("Smoothness", Range(0, 1)) = 0
		_Metallic ("Metalness", Range(0, 1)) = 0
		[HDR] _Emission ("Emission", color) = (0,0,0)

		[IntRange] _StencilRef ("Stencil Reference Value", Range(0,255)) = 0
		_Comp("Equal State", Int) = 3
	}
	SubShader {
		Tags{ "RenderType"="Opaque" "Queue"="Geometry"}

		Stencil{
			Ref [_StencilRef]
			Comp [_Comp]
			Pass keep
		}

		CGPROGRAM

		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _BumpTex;
		fixed4 _Color;

		half _Smoothness;
		half _Metallic;
		half3 _Emission;
		

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_BumpTex;
		};
		void surf (Input i, inout SurfaceOutputStandard o) {
			fixed4 col = tex2D(_MainTex, i.uv_MainTex);
			float3 n = UnpackNormal(tex2D(_BumpTex, i.uv_BumpTex));
			col *= _Color;
			o.Albedo = col.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Smoothness;
			o.Emission = _Emission;
			o.Normal = n;
		}
		ENDCG
	}
	FallBack "Standard"
}