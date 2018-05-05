Shader "Custom/Select" {
	Properties{
		_BaseColor("Base Color", Color) = (1,1,1,1)
		_Position("Position", Vector) = (0,0,0,1)
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
#pragma surface surf Standard fullforwardshadows
#pragma target 3.0

		struct Input {
		float2 uv_MainTex;
		float3 worldPos;
	};

	fixed4 _BaseColor;
	fixed4 _Position;

	void surf(Input IN, inout SurfaceOutputStandard o) {
		float dist = distance(_Position, IN.worldPos);
		float val = abs(sin(dist*3.0 - _Time * 50));
		if (val > 0.98) {
			o.Albedo = fixed4(1, 1, 1, 1);
		}
		else {
			o.Albedo = _BaseColor.rgb;
		}
	}
	ENDCG
	}
		FallBack "Diffuse"
}