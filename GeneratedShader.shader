Shader "PBR Master"
{
	Properties
	{
				Float_7E56653D("Seed", Float) = 1
				Color_F55EE251("Color", Color) = (0.6451919,1,0.531,0)
	}
	SubShader
	{
		Tags{ "RenderPipeline" = "LightweightPipeline"}
		Tags
		{
			"RenderType"="Opaque"
			"Queue"="Geometry"
		}
		Pass
		{
			Tags{"LightMode" = "LightweightForward"}
			
					Blend One Zero
					Cull Back
					ZTest LEqual
					ZWrite On
			
			CGPROGRAM
			#pragma target 3.0
			
		    #pragma multi_compile _ _MAIN_LIGHT_COOKIE
		    #pragma multi_compile _MAIN_DIRECTIONAL_LIGHT _MAIN_SPOT_LIGHT
		    #pragma multi_compile _ _ADDITIONAL_LIGHTS
		    #pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
		    #pragma multi_compile _ UNITY_SINGLE_PASS_STEREO STEREO_INSTANCING_ON STEREO_MULTIVIEW_ON
		    #pragma multi_compile _ LIGHTMAP_ON
		    #pragma multi_compile _ DIRLIGHTMAP_COMBINED
		    #pragma multi_compile _ _HARD_SHADOWS _SOFT_SHADOWS _HARD_SHADOWS_CASCADES _SOFT_SHADOWS_CASCADES
		    #pragma multi_compile _ _VERTEX_LIGHTS
		    #pragma multi_compile_fog
		    #pragma multi_compile_instancing
		    #pragma vertex vert
			#pragma fragment frag
			
			#pragma glsl
			#pragma debug
			
			
			#include "LightweightLighting.cginc"
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
								float4 texcoord1 : TEXCOORD1;
								UNITY_VERTEX_INPUT_INSTANCE_ID
							};
							struct SurfaceInputs{
							};
							struct SurfaceDescription{
								float3 Albedo;
								float3 Normal;
								float3 Emission;
								float Metallic;
								float Smoothness;
								float Occlusion;
								float Alpha;
							};
							float Float_7E56653D;
							float4 Color_F55EE251;
							float4 _Remap_392641D4_InMinMax;
							float4 _Remap_392641D4_OutMinMax;
							float4 _PBRMaster_96383EFE_Albedo;
							float4 _PBRMaster_96383EFE_Normal;
							float _PBRMaster_96383EFE_Metallic;
							float _PBRMaster_96383EFE_Smoothness;
							float _PBRMaster_96383EFE_Occlusion;
							float _PBRMaster_96383EFE_Alpha;
							GraphVertexInput PopulateVertexData(GraphVertexInput v){
								return v;
							}
							SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
								SurfaceDescription surface = (SurfaceDescription)0;
								float _Property_DC180A9C_Out = Float_7E56653D;
								float _Sine_90C1BD81_Out;
								Unity_Sine_float(_Property_DC180A9C_Out, _Sine_90C1BD81_Out);
								float _Multiply_43137AB_Out;
								Unity_Multiply_float(_Time.y, _Sine_90C1BD81_Out, _Multiply_43137AB_Out);
								float _Sine_EFF6A6FE_Out;
								Unity_Sine_float(_Multiply_43137AB_Out, _Sine_EFF6A6FE_Out);
								float _Remap_392641D4_Out;
								Unity_Remap_float(_Sine_EFF6A6FE_Out, _Remap_392641D4_InMinMax, _Remap_392641D4_OutMinMax, _Remap_392641D4_Out);
								float4 _Property_98614D15_Out = Color_F55EE251;
								float4 _Multiply_7A79087_Out;
								Unity_Multiply_float((_Remap_392641D4_Out.xxxx), _Property_98614D15_Out, _Multiply_7A79087_Out);
								surface.Albedo = _PBRMaster_96383EFE_Albedo;
								surface.Normal = _PBRMaster_96383EFE_Normal;
								surface.Emission = _Multiply_7A79087_Out;
								surface.Metallic = _PBRMaster_96383EFE_Metallic;
								surface.Smoothness = _PBRMaster_96383EFE_Smoothness;
								surface.Occlusion = _PBRMaster_96383EFE_Occlusion;
								surface.Alpha = _PBRMaster_96383EFE_Alpha;
								return surface;
							}
			
			struct GraphVertexOutput
		    {
		        float4 position : SV_POSITION;
		#ifdef LIGHTMAP_ON
		        float4 lightmapUV : TEXCOORD0;
		#else
				float4 vertexSH : TEXCOORD0;
		#endif
				half4 fogFactorAndVertexLight : TEXCOORD1; // x: fogFactor, yzw: vertex light
		        			float3 WorldSpaceNormal : TEXCOORD3;
					float3 WorldSpaceTangent : TEXCOORD4;
					float3 WorldSpaceBiTangent : TEXCOORD5;
					float3 WorldSpaceViewDirection : TEXCOORD6;
					float3 WorldSpacePosition : TEXCOORD7;
					half4 uv1 : TEXCOORD8;
				UNITY_VERTEX_OUTPUT_STEREO
		    };
			
		    GraphVertexOutput vert (GraphVertexInput v)
			{
			    v = PopulateVertexData(v);
				
				UNITY_SETUP_INSTANCE_ID(v);
		        GraphVertexOutput o = (GraphVertexOutput)0;
		        UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
		        			o.WorldSpaceNormal = mul(v.normal,(float3x3)unity_WorldToObject);
					o.WorldSpaceTangent = mul((float3x3)unity_ObjectToWorld,v.tangent);
					o.WorldSpaceBiTangent = normalize(cross(o.WorldSpaceNormal, o.WorldSpaceTangent.xyz) * v.tangent.w);
					o.WorldSpaceViewDirection = mul((float3x3)unity_ObjectToWorld,ObjSpaceViewDir(v.vertex));
					o.WorldSpacePosition = mul(unity_ObjectToWorld,v.vertex);
					o.uv1 = v.texcoord1;
				float3 lwWNormal = normalize(UnityObjectToWorldNormal(v.normal));
				float4 lwWorldPos = mul(unity_ObjectToWorld, v.vertex);
				float4 clipPos = mul(UNITY_MATRIX_VP, lwWorldPos);
		#ifdef LIGHTMAP_ON
				o.lightmapUV.zw = v.texcoord1 * unity_LightmapST.xy + unity_LightmapST.zw;
		#else
				o.vertexSH = half4(EvaluateSHPerVertex(lwWNormal), 0.0);
		#endif
				o.fogFactorAndVertexLight.yzw = VertexLighting(lwWorldPos.xyz, lwWNormal);
				o.fogFactorAndVertexLight.x = ComputeFogFactor(clipPos.z);
		        o.position = clipPos;
				return o;
			}
			fixed4 frag (GraphVertexOutput IN) : SV_Target
		    {
		    				float3 WorldSpaceNormal = normalize(IN.WorldSpaceNormal);
					float3 WorldSpaceTangent = IN.WorldSpaceTangent;
					float3 WorldSpaceBiTangent = IN.WorldSpaceBiTangent;
					float3 WorldSpaceViewDirection = normalize(IN.WorldSpaceViewDirection);
					float3 WorldSpacePosition = IN.WorldSpacePosition;
					float4 uv1  = IN.uv1;
		        SurfaceInputs surfaceInput = (SurfaceInputs)0;
		        
		        SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
				float3 Albedo = float3(0.5, 0.5, 0.5);
				float3 Specular = float3(0, 0, 0);
				float Metallic = 0;
				float3 Normal = float3(0, 0, 1);
				float3 Emission = 0;
				float Smoothness = 0.5;
				float Occlusion = 1;
				float Alpha = 1;
		        			Albedo = surf.Albedo;
					Normal = surf.Normal;
					Emission = surf.Emission;
					Metallic = surf.Metallic;
					Smoothness = surf.Smoothness;
					Occlusion = surf.Occlusion;
					Alpha = surf.Alpha;
		#if defined(UNITY_COLORSPACE_GAMMA) 
		       	Albedo = Albedo * Albedo;
		       	Emission = Emission * Emission;
		#endif
		#if _NORMALMAP
		    half3 normalWS = TangentToWorldNormal(Normal, WorldSpaceTangent, WorldSpaceBiTangent, WorldSpaceNormal);
		#else
		    half3 normalWS = normalize(WorldSpaceNormal);
		#endif
		#if LIGHTMAP_ON
			half3 indirectDiffuse = SampleLightmap(IN.lightmapUV.zw, normalWS);
		#else
			half3 indirectDiffuse = EvaluateSHPerPixel(normalWS, IN.vertexSH);
		#endif
			half4 color = LightweightFragmentPBR(
					WorldSpacePosition,
					normalWS,
					WorldSpaceViewDirection,
					indirectDiffuse,
					IN.fogFactorAndVertexLight.yzw, 
					Albedo,
					Metallic,
					Specular,
					Smoothness,
					Occlusion,
					Emission,
					Alpha);
			// Computes fog factor per-vertex
		    ApplyFog(color.rgb, IN.fogFactorAndVertexLight.x);
		#if _AlphaOut
				color.a = Alpha;
		#else
				color.a = 1;
		#endif
		#if _AlphaClip
				clip(Alpha - 0.01);
		#endif
				return color;
		    }
			ENDCG
		}
		Pass
		{
		    Tags{"LightMode" = "ShadowCaster"}
		    ZWrite On ZTest LEqual
		    CGPROGRAM
		    #pragma target 2.0
		    #pragma vertex ShadowPassVertex
		    #pragma fragment ShadowPassFragment
		    #include "UnityCG.cginc"
		    #include "LightweightPassShadow.cginc"
		    ENDCG
		}
		Pass
		{
		    Tags{"LightMode" = "DepthOnly"}
		    ZWrite On
		    ColorMask 0
		    CGPROGRAM
		    #pragma target 2.0
		    #pragma vertex vert
		    #pragma fragment frag
		    #include "UnityCG.cginc"
		    float4 vert(float4 pos : POSITION) : SV_POSITION
		    {
		        return UnityObjectToClipPos(pos);
		    }
		    half4 frag() : SV_TARGET
		    {
		        return 0;
		    }
		    ENDCG
		}
	}
}
