Shader "Custom/ShaderHolograma" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_Factor ("Factor", Range (0, 1)) = 0.2
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags
		{
			 "Queue" = "Transparent" 
			 "IgnoreProjector" = "True"
			 "RenderType" = "TransparentCutout"
		}
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 worldNormal;
			float3 viewDir;
		};

		fixed4 _Color;
		float _Factor;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
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
		ENDCG
	}
	FallBack "Diffuse"
}
