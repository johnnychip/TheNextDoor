Shader "Custom/ShaderCueva" {
	Properties {
		_Textura ("Textura (RGB)", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf ModeloBase
		#pragma target 3.0

		sampler2D _Textura;
		struct Input {
			float2 uv_Textura;
		};

		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutput o) {

			float4 c = tex2D(_Textura, IN.uv_Textura);
			o.Albedo = c.rgb*_Color;
		}

		float4 LightingModeloBase(SurfaceOutput s, float3 direccionLuz, float atenuacion) {
			float luz = 0.8; //dot(s.Normal, direccionLuz);
			float4 c;
			c.rgb = luz*atenuacion*s.Albedo*_LightColor0.rgb;
			return c;
		}

		ENDCG
	}
	FallBack "Diffuse"
}
