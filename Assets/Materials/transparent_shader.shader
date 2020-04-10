Shader "Custom/transparent_shader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _TimeVal ("Time", Range(0,1)) = 0.0
        _DissolveStart ("DissolveStart", Vector) = (0, 0, 0)
        _DissolveEnd ("DissolveEnd", Vector) = (0, 1, 0)
        _DissolveBand ("DissolveBand", Vector) = (0, 1, 0)
        _DissolveScale ("DissolveScale", Vector) = (0, 1, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        half _TimeVal;

        float3 _DissolveStart;
        float3 _DissolveEnd;
        float3 _DissolveBand;
        float3 _DissolveScale;

        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        //Precompute dissolve direction.
        static float3 dDir = normalize(_DissolveEnd - _DissolveStart);

        //Precompute gradient start position.
        static float3 dissolveStartConverted = _DissolveStart - _DissolveBand * dDir;

        //Precompute reciprocal of band size.
        static float dBandFactor = 1.0f / _DissolveBand;

        void vert(inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input,o);
            float3 dPoint = lerp(dissolveStartConverted, _DissolveEnd, _DissolveScale);
            o.dGeometry = dot(v.vertex - dPoint, dDir) * dBandFactor;
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = float3(sin(_Time.y), sin(_Time.y), sin(_Time.y));
            //o.Albedo = float3(0.5, 0.5, 0.5);
            // if(IN.uv_MainTex.y < 0.3){
            //     clip(-1);
            // }
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;//0;//IN.uv_MainTex.y;//c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
