Shader "Custom/Wireframe_SinglePassInstanced"
{
    Properties
    {
        _Color ("Line Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma target 4.0
            #pragma vertex vert
            #pragma geometry geom
            #pragma fragment frag
            #pragma multi_compile_instancing

            #include "UnityCG.cginc"
            float4 _Color;

            struct WireVert
            {
                float4 vertex : POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2g
            {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            v2g vert(WireVert v)
            {
                UNITY_SETUP_INSTANCE_ID(v);

                v2g o;
                UNITY_INITIALIZE_OUTPUT(v2g, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            [maxvertexcount(6)]
            void geom(triangle v2g input[3], inout LineStream<v2g> stream)
            {
                for (int i = 0; i < 3; i++)
                {
                    stream.Append(input[i]);
                    stream.Append(input[(i+1)%3]);
                    stream.RestartStrip();
                }
            }

            fixed4 frag(v2g i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }
    }
    FallBack Off
}
