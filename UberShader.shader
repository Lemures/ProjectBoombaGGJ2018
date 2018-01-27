Shader "hidden/preview"
{
	Properties
	{
				Float_639B7DA("Energy Level", Float) = 0.5
				Color_13786F36("Color Empty", Color) = (0.764151,0.2754091,0.2487095,0)
				Color_3E588C("Color Full", Color) = (0.4309678,0.6792453,0.3926038,0)
	}
	CGINCLUDE
	#include "UnityCG.cginc"
			void Unity_Lerp_float(float4 A, float4 B, float4 T, out float4 Out)
			{
			    Out = lerp(A, B, T);
			}
			void Unity_Multiply_float(float A, float B, out float Out)
			{
			    Out = A * B;
			}
			void Unity_Sine_float(float In, out float Out)
			{
			    Out = sin(In);
			}
			void Unity_Remap_float(float In, float2 InMinMax, float2 OutMinMax, out float Out)
			{
			    Out = OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
			}
			void Unity_Add_float(float A, float B, out float Out)
			{
			    Out = A + B;
			}
			void Unity_Clamp_float(float In, float Min, float Max, out float Out)
			{
			    Out = clamp(In, Min, Max);
			}
			void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
			{
			    Out = A * B;
			}
			struct GraphVertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			struct SurfaceInputs{
			};
			struct SurfaceDescription{
				float4 PreviewOutput;
			};
			float Float_9031DB85;
			float Float_639B7DA;
			float4 Color_13786F36;
			float4 Color_3E588C;
			float _Multiply_F055DB4E_B;
			float4 _Remap_AB38022_InMinMax;
			float4 _Remap_AB38022_OutMinMax;
			float _Add_F4B23BCA_B;
			float _Clamp_DBED94F0_Min;
			float _Clamp_DBED94F0_Max;
			GraphVertexInput PopulateVertexData(GraphVertexInput v){
				return v;
			}
			SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
				SurfaceDescription surface = (SurfaceDescription)0;
				float4 _Property_8741CC03_Out = Color_13786F36;
				float4 _Property_478E4D8D_Out = Color_3E588C;
				float _Property_9F4F0D47_Out = Float_639B7DA;
				float4 _Lerp_F60D4D8C_Out;
				Unity_Lerp_float(_Property_8741CC03_Out, _Property_478E4D8D_Out, (_Property_9F4F0D47_Out.xxxx), _Lerp_F60D4D8C_Out);
				if (Float_9031DB85 == 0) { surface.PreviewOutput = half4(_Lerp_F60D4D8C_Out.x, _Lerp_F60D4D8C_Out.y, _Lerp_F60D4D8C_Out.z, 1.0); return surface; }
				float _Multiply_F055DB4E_Out;
				Unity_Multiply_float(_Property_9F4F0D47_Out, _Multiply_F055DB4E_B, _Multiply_F055DB4E_Out);
				if (Float_9031DB85 == 1) { surface.PreviewOutput = half4(_Multiply_F055DB4E_Out, _Multiply_F055DB4E_Out, _Multiply_F055DB4E_Out, 1.0); return surface; }
				float _Multiply_2A2BA189_Out;
				Unity_Multiply_float(_Time.y, _Multiply_F055DB4E_Out, _Multiply_2A2BA189_Out);
				if (Float_9031DB85 == 2) { surface.PreviewOutput = half4(_Multiply_2A2BA189_Out, _Multiply_2A2BA189_Out, _Multiply_2A2BA189_Out, 1.0); return surface; }
				float _Sine_5EE8126F_Out;
				Unity_Sine_float(_Multiply_2A2BA189_Out, _Sine_5EE8126F_Out);
				if (Float_9031DB85 == 3) { surface.PreviewOutput = half4(_Sine_5EE8126F_Out, _Sine_5EE8126F_Out, _Sine_5EE8126F_Out, 1.0); return surface; }
				float _Remap_AB38022_Out;
				Unity_Remap_float(_Sine_5EE8126F_Out, _Remap_AB38022_InMinMax, _Remap_AB38022_OutMinMax, _Remap_AB38022_Out);
				if (Float_9031DB85 == 4) { surface.PreviewOutput = half4(_Remap_AB38022_Out, _Remap_AB38022_Out, _Remap_AB38022_Out, 1.0); return surface; }
				float _Add_F4B23BCA_Out;
				Unity_Add_float(_Remap_AB38022_Out, _Add_F4B23BCA_B, _Add_F4B23BCA_Out);
				if (Float_9031DB85 == 5) { surface.PreviewOutput = half4(_Add_F4B23BCA_Out, _Add_F4B23BCA_Out, _Add_F4B23BCA_Out, 1.0); return surface; }
				float _Clamp_DBED94F0_Out;
				Unity_Clamp_float(_Add_F4B23BCA_Out, _Clamp_DBED94F0_Min, _Clamp_DBED94F0_Max, _Clamp_DBED94F0_Out);
				if (Float_9031DB85 == 6) { surface.PreviewOutput = half4(_Clamp_DBED94F0_Out, _Clamp_DBED94F0_Out, _Clamp_DBED94F0_Out, 1.0); return surface; }
				float4 _Multiply_DD8DDE6B_Out;
				Unity_Multiply_float(_Lerp_F60D4D8C_Out, (_Clamp_DBED94F0_Out.xxxx), _Multiply_DD8DDE6B_Out);
				if (Float_9031DB85 == 7) { surface.PreviewOutput = half4(_Multiply_DD8DDE6B_Out.x, _Multiply_DD8DDE6B_Out.y, _Multiply_DD8DDE6B_Out.z, 1.0); return surface; }
				return surface;
			}
	ENDCG
	SubShader
	{
	    Tags { "RenderType"="Opaque" }
	    LOD 100
	    Pass
	    {
	        CGPROGRAM
	        #pragma vertex vert
	        #pragma fragment frag
	        #include "UnityCG.cginc"
	        struct GraphVertexOutput
	        {
	            float4 position : POSITION;
	            
	        };
	        GraphVertexOutput vert (GraphVertexInput v)
	        {
	            v = PopulateVertexData(v);
	            GraphVertexOutput o;
	            o.position = UnityObjectToClipPos(v.vertex);
	            
	            return o;
	        }
	        fixed4 frag (GraphVertexOutput IN) : SV_Target
	        {
	            
	            SurfaceInputs surfaceInput = (SurfaceInputs)0;;
	            
	            SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
	            return surf.PreviewOutput;
	        }
	        ENDCG
	    }
	}
}
