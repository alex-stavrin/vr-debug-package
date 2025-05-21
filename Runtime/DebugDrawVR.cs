using UnityEngine;
using static UnityEditor.PlayerSettings;

public static class DebugDrawVR
{
    public static void DrawCube(Vector3 position, Quaternion rotation, Vector3 size, Color color)
    {
        DebugDrawVRSettings settings = DebugDrawVRSettings.Instance;
        if (settings == null) return;

        var matrix = Matrix4x4.TRS(position, rotation, size);
        var mpb = new MaterialPropertyBlock();
        mpb.SetColor("_Color", color);
        var rp = new RenderParams(settings.wireFrameMaterial);
        rp.matProps = mpb;
        var m = Matrix4x4.TRS(position, rotation, size);
        Graphics.RenderMesh(rp, settings.cubeMesh, 0, m);
    }
}