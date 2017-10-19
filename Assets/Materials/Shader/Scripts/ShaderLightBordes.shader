Shader "Custom/ShaderLightBordes" {
	Properties {
		_Textura ("Textura (RGB)", 2D) = "white" {}
		_Factor ("_Factor", Range(0,1)) = 0
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
			float3 worldNormal;
			float3 viewDir;
		};

		fixed4 _Color;
		float _Factor;

		void surf (Input IN, inout SurfaceOutput o) {

			fixed4 c = tex2D (_Textura, IN.uv_Textura);
			float bordes = dot(IN.worldNormal,IN.viewDir);
			
			if(bordes < _Factor)
			{
				bordes = 0;
			}else
			{
				bordes = 1;
			}

			_Color *=(1-bordes);

			o.Albedo = (c.rgb * bordes)+_Color;
			
			o.Alpha =_Color.a ;

		}

		float4 LightingModeloBase(SurfaceOutput s, float3 direccionLuz, float3 direccionCamara, float atenuacion) {
			float luz = dot(s.Normal, direccionCamara);
			float4 c;

			if(luz < _Factor)
			{
				luz = 1.5f;
				c.rgb = luz*s.Albedo*_LightColor0.rgb;
			}else
			{
				//luz = 0;
				c.rgb = luz*s.Albedo*atenuacion*_LightColor0.rgb;
			}

			
			
			return c;
		}

		ENDCG
	}
	FallBack "Diffuse"
}
