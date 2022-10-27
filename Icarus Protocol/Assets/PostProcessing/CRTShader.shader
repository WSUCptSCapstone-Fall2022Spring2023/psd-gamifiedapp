Shader "Hidden/CrtPostProcess"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;

			uniform float u_time;
			uniform float u_scanline_size_1;
			uniform float u_scanline_speed_1;
			uniform float u_scanline_size_2;
			uniform float u_scanline_speed_2;
			uniform float u_scanline_amount;

			float scanline(half2 uv, float lines, float speed)
			{
				return sin(uv.y * lines + u_time * speed);
			}

			float random(half2 uv)
			{
				return frac(sin(dot(uv, half2(15.1511, 42.5225))) * 12341.51611 * sin(u_time * 0.03));
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);

				float s1 = scanline(i.uv, u_scanline_size_1, u_scanline_speed_1);
				float s2 = scanline(i.uv, u_scanline_size_2, u_scanline_speed_2);

				col = lerp(col, fixed(s1 + s2), u_scanline_amount);

				return col;
			}
			ENDCG
		}
	}
}