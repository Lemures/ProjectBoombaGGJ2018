Shader "PBR Master"
{
	Properties
	{
				Float_639B7DA("Energy Level", Float) = 0.5
				Color_13786F36("Color Empty", Color) = (0.764151,0.2754091,0.2487095,0)
				Color_3E588C("Color Full", Color) = (0.4309678,0.6792453,0.3926038,0)
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
							float Float_639B7DA;
							float4 Color_13786F36;
							float4 Color_3E588C;
							float _Multiply_F055DB4E_B;
							float4 _Remap_AB38022_InMinMax;
							float4 _Remap_AB38022_OutMinMax;
							float _Add_F4B23BCA_B;
							float _Clamp_DBED94F0_Min;
							float _Clamp_DBED94F0_Max;
							float4 _PBRMaster_55A0710_Albedo;
							float4 _PBRMaster_55A0710_Normal;
							float _PBRMaster_55A0710_Metallic;
							float _PBRMaster_55A0710_Smoothness;
							float _PBRMaster_55A0710_Occlusion;
							float _PBRMaster_55A0710_Alpha;
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
								float _Multiply_F055DB4E_Out;
								Unity_Multiply_float(_Property_9F4F0D47_Out, _Multiply_F055DB4E_B, _Multiply_F055DB4E_Out);
								float _Multiply_2A2BA189_Out;
								Unity_Multiply_float(_Time.y, _Multiply_F055DB4E_Out, _Multiply_2A2BA189_Out);
								float _Sine_5EE8126F_Out;
								Unity_Sine_float(_Multiply_2A2BA189_Out, _Sine_5EE8126F_Out);
								float _Remap_AB38022_Out;
								Unity_Remap_float(_Sine_5EE8126F_Out, _Remap_AB38022_InMinMax, _Remap_AB38022_OutMinMax, _Remap_AB38022_Out);
								float _Add_F4B23BCA_Out;
								Unity_Add_float(_Remap_AB38022_Out, _Add_F4B23BCA_B, _Add_F4B23BCA_Out);
								float _Clamp_DBED94F0_Out;
								Unity_Clamp_float(_Add_F4B23BCA_Out, _Clamp_DBED94F0_Min, _Clamp_DBED94F0_Max, _Clamp_DBED94F0_Out);
								float4 _Multiply_DD8DDE6B_Out;
								Unity_Multiply_float(_Lerp_F60D4D8C_Out, (_Clamp_DBED94F0_Out.xxxx), _Multiply_DD8DDE6B_Out);
								surface.Albedo = _PBRMaster_55A0710_Albedo;
								surface.Normal = _PBRMaster_55A0710_Normal;
								surface.Emission = _Multiply_DD8DDE6B_Out;
								surface.Metallic = _PBRMaster_55A0710_Metallic;
								surface.Smoothness = _PBRMaster_55A0710_Smoothness;
								surface.Occlusion = _PBRMaster_55A0710_Occlusion;
								surface.Alpha = _PBRMaster_55A0710_Alpha;
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
