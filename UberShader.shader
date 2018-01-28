Shader "hidden/preview"
{
	Properties
	{
				Float_7E56653D("Seed", Float) = 1
				Color_F55EE251("Color", Color) = (0.6451919,1,0.531,0)
	}
	CGINCLUDE
	#include "UnityCG.cginc"
			void Unity_Sine_float(float In, out float Out)
			{
			    Out = sin(In);
			}
			void Unity_Multiply_float(float A, float B, out float Out)
			{
			    Out = A * B;
			}
			void Unity_Remap_float(float In, float2 InMinMax, float2 OutMinMax, out float Out)
			{
			    Out = OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
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
			float Float_800A9918;
			float Float_7E56653D;
			float4 Color_F55EE251;
			float4 Color_BA4E583C;
			float4 _Remap_392641D4_InMinMax;
			float4 _Remap_392641D4_OutMinMax;
			float _Remap_47B2AFA4_In;
			float4 _Remap_47B2AFA4_InMinMax;
			float4 _Remap_47B2AFA4_OutMinMax;
			GraphVertexInput PopulateVertexData(GraphVertexInput v){
				return v;
			}
			SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
				SurfaceDescription surface = (SurfaceDescription)0;
				float _Property_DC180A9C_Out = Float_7E56653D;
				float _Sine_90C1BD81_Out;
				Unity_Sine_float(_Property_DC180A9C_Out, _Sine_90C1BD81_Out);
				if (Float_800A9918 == 0) { surface.PreviewOutput = half4(_Sine_90C1BD81_Out, _Sine_90C1BD81_Out, _Sine_90C1BD81_Out, 1.0); return surface; }
				float _Multiply_43137AB_Out;
				Unity_Multiply_float(_Time.y, _Sine_90C1BD81_Out, _Multiply_43137AB_Out);
				if (Float_800A9918 == 1) { surface.PreviewOutput = half4(_Multiply_43137AB_Out, _Multiply_43137AB_Out, _Multiply_43137AB_Out, 1.0); return surface; }
				float _Sine_EFF6A6FE_Out;
				Unity_Sine_float(_Multiply_43137AB_Out, _Sine_EFF6A6FE_Out);
				if (Float_800A9918 == 2) { surface.PreviewOutput = half4(_Sine_EFF6A6FE_Out, _Sine_EFF6A6FE_Out, _Sine_EFF6A6FE_Out, 1.0); return surface; }
				float _Remap_392641D4_Out;
				Unity_Remap_float(_Sine_EFF6A6FE_Out, _Remap_392641D4_InMinMax, _Remap_392641D4_OutMinMax, _Remap_392641D4_Out);
				if (Float_800A9918 == 3) { surface.PreviewOutput = half4(_Remap_392641D4_Out, _Remap_392641D4_Out, _Remap_392641D4_Out, 1.0); return surface; }
				float _Remap_47B2AFA4_Out;
				Unity_Remap_float(_Remap_47B2AFA4_In, _Remap_47B2AFA4_InMinMax, _Remap_47B2AFA4_OutMinMax, _Remap_47B2AFA4_Out);
				if (Float_800A9918 == 4) { surface.PreviewOutput = half4(_Remap_47B2AFA4_Out, _Remap_47B2AFA4_Out, _Remap_47B2AFA4_Out, 1.0); return surface; }
				float4 _Property_98614D15_Out = Color_F55EE251;
				float4 _Multiply_7A79087_Out;
				Unity_Multiply_float((_Remap_392641D4_Out.xxxx), _Property_98614D15_Out, _Multiply_7A79087_Out);
				if (Float_800A9918 == 5) { surface.PreviewOutput = half4(_Multiply_7A79087_Out.x, _Multiply_7A79087_Out.y, _Multiply_7A79087_Out.z, 1.0); return surface; }
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
