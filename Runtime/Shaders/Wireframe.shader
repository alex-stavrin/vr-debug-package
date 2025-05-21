Shader "Custom/Wireframe" {
  Properties { _Color ("Line Color", Color) = (1,1,1,1) }
  SubShader {
    Tags { "RenderType"="Opaque" }
    Pass {
      CGPROGRAM
      #pragma vertex vert
      #pragma geometry geom
      #pragma fragment frag
      #include "UnityCG.cginc"

      float4 _Color;

      struct v2g { float4 pos : SV_POSITION; };

      v2g vert(appdata_full v) {
        v2g o; o.pos = UnityObjectToClipPos(v.vertex); return o;
      }

      [maxvertexcount(6)]
      void geom(triangle v2g input[3], inout LineStream<v2g> stream) {
        // output each triangle edge as a line
        for (int i = 0; i < 3; i++) {
          v2g a = input[i];
          v2g b = input[(i+1)%3];
          stream.Append(a);
          stream.Append(b);
          stream.RestartStrip();
        }
      }

      fixed4 frag(v2g i) : SV_Target {
        return _Color;
      }
      ENDCG
    }
  }
  FallBack Off
}
