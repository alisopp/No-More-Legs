Shader "Custom/Trail Shader"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _ColorTint ("Tint", Color) = (1,1,1,1)
        _Color1in ("Color 1 In", Color) = (0,0,0,1) //this selects all color that are black right?
        _Color1out ("Color 1 Out", Color) = (1,1,1,1) //and this changes the selected black color to
        _Thickness ("Thickness", float) = 0.4
    }
    SubShader
    {
        Tags { 
        "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True" }
        Cull Off
        Lighting Off
        ZWrite Off
        Fog { Mode Off }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
            };
            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                half2 texcoord  : TEXCOORD0;
            };

            sampler2D _MainTex;
            fixed4 _ColorTint;
            fixed4 _Color1in;
            fixed4 _Color1out;
            float _Thickness;

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;          
                OUT.color = IN.color * _ColorTint;
                return OUT;
            }
            
         
            fixed4 frag(v2f IN) : COLOR
            {
             // Texcoord distance from the center of the quad.
                float2 fromCenter = abs(IN.texcoord - 0.5f);
                // Signed distance from the horizontal & vertical edges.
                float2 fromEdge = fromCenter - 0.5f;
                
                // Use screenspace derivatives to convert to pixel distances.
                fromEdge.x /= length(float2(ddx(IN.texcoord.x), ddy(IN.texcoord.x)));
                fromEdge.y /= length(float2(ddx(IN.texcoord.y), ddy(IN.texcoord.y)));
                
                float distance = abs(min(max(fromEdge.x,fromEdge.y), 0.0f) + length(max(fromEdge, 0.0f)));

                float4 texColor = tex2D( _MainTex, IN.texcoord );
                
                texColor.a *= step(max(fromCenter.x, fromCenter.y), 0.5f);
                //texColor = any(texColor == _Color1in) ? _Color1out : texColor;
                texColor = lerp(texColor, _Color1in, saturate(_Thickness - distance));
                return texColor * IN.color;
            }
            ENDCG
        }
    }
}
