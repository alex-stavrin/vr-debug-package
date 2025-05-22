using UnityEngine;

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

    public static void DrawSphere(Vector3 position, Quaternion rotation, float radius,  Color color)
    {
        DebugDrawVRSettings settings = DebugDrawVRSettings.Instance;
        if(settings == null) return;

        float diameter = radius * 2;
        Vector3 size = new Vector3(diameter, diameter, diameter);
        var matrix = Matrix4x4.TRS(position, rotation, size);
        var mpb = new MaterialPropertyBlock();
        mpb.SetColor("_Color", color);
        var rp = new RenderParams(settings.wireFrameMaterial);
        rp.matProps = mpb;
        var m = Matrix4x4.TRS(position, rotation, size);
        Graphics.RenderMesh(rp, settings.sphereMesh, 0, m);
    }

    public static void DrawCapsule(Vector3 position, Quaternion rotation, float radius, float height, Color color)
    {
        DebugDrawVRSettings settings = DebugDrawVRSettings.Instance;
        if (settings == null) return;

        float diameter = radius * 2;
        float sizeY = height / 2;
        Vector3 size = new Vector3(diameter, sizeY, diameter);
        var matrix = Matrix4x4.TRS(position, rotation, size);
        var mpb = new MaterialPropertyBlock();
        mpb.SetColor("_Color", color);
        var rp = new RenderParams(settings.wireFrameMaterial);
        rp.matProps = mpb;
        var m = Matrix4x4.TRS(position, rotation, size);
        Graphics.RenderMesh(rp, settings.capsuleMesh, 0, m);
    }
}