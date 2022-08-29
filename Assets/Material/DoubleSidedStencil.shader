Shader "Custom/DoubleSidedStencil"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

        [IntRange] _StencilRef ("Stencil Reference Value", Range(0,255)) = 0
		[Enum(equal,notequal)] _Comp("Equal State", Int) = 3
    }
    SubShader {
		Tags{ "RenderType"="Opaque" "Queue"="Geometry"}
        LOD 400
        cull off

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

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input i, inout SurfaceOutputStandard o) {
			fixed4 col = tex2D(_MainTex, i.uv_MainTex);
			float3 n = UnpackNormal(tex2D(_BumpTex, i.uv_BumpTex));
			col *= _Color;
			o.Albedo = col.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Smoothness;
			o.Emission = _Emission;
			o.Normal = n;
			o.Alpha = col.a;
		}

        ENDCG
	}
    FallBack "Diffuse"
}
