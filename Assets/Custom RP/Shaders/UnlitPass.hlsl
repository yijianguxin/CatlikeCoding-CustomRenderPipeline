#ifndef CUSTOM_UNLIT_PASS_INCLUDED
#define CUSTOM_UNLIT_PASS_INCLUDED

#include "../ShaderLibrary/Common.hlsl"

float4 UnlitPassVertex(float3 positionOS : POSITION) : SV_POSITION
{
    float3 positionWS = TransformWorldToHClip(positionOS.xyz);
    return float4(positionWS, 1.0);
} 

float4 UnlitPassFragment() : SV_TARGET
{
    return 0.0;
}

#endif