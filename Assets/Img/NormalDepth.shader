Shader "Custom/NormalDepth" 
{
    Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_BumpTex("Normal Texture", 2D) = "bump" {}
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag


			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;

				float3 T : TEXCOORD1;
				float3 B : TEXCOORD2;
				float3 N : TEXCOORD3;

				float3 lightDir : TEXCOORD4;
				half3 viewDir : TEXCOORD5;		
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			sampler2D _BumpTex;
			float4 _BumpTex_ST;



			void Fuc_LocalNormal2TBN(half3 localnormal, float4 tangent, inout half3 T, inout half3  B, inout half3 N)
			{
				half fTangentSign = tangent.w * unity_WorldTransformParams.w;
				N = normalize(UnityObjectToWorldNormal(localnormal));
				T = normalize(UnityObjectToWorldDir(tangent.xyz));
				B = normalize(cross(N, T) * fTangentSign);
			}

			half3 Fuc_TangentNormal2WorldNormal(half3 fTangnetNormal, half3 T, half3  B, half3 N)
			{
				float3x3 TBN = float3x3(T, B, N);
				TBN = transpose(TBN);
				return mul(TBN, fTangnetNormal);
			}


			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				o.lightDir = WorldSpaceLightDir(v.vertex);
				o.viewDir = normalize(WorldSpaceViewDir(v.vertex));

				Fuc_LocalNormal2TBN(v.normal, v.tangent, o.T, o.B, o.N);

				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				
				fixed4 col = tex2D(_MainTex, i.uv);
				half3 fTangnetNormal = UnpackNormal(tex2D(_BumpTex, i.uv * _BumpTex_ST.rg));
				fTangnetNormal.xy *= 1.5f; // ???? ??
				float3 worldNormal = Fuc_TangentNormal2WorldNormal(fTangnetNormal, i.T, i.B, i.N);

				fixed fNDotL = dot(i.lightDir, worldNormal);
	
				float3 fReflection = reflect(i.lightDir, worldNormal);
				fixed fSpec_Phong = saturate(dot(fReflection, -normalize(i.viewDir)));
				fSpec_Phong = pow(fSpec_Phong, 20.0f);

				return float4(col.rgb * fNDotL + fSpec_Phong, 1);
			}
			ENDCG
		}
	}
}