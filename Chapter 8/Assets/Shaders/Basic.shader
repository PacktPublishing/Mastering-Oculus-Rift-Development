Shader "Custom/Basic"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Diffuse", 2D) = "white" {}
		[Normal]_NormalTex("Normal", 2D) = "white" {}
	}

		SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		fixed4 _Color;
		sampler2D _MainTex;
		sampler2D _NormalTex;

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Normal = UnpackNormal(tex2D(_NormalTex, IN.uv_MainTex));
		}
		ENDCG
	}
		
	FallBack "Diffuse"
}
