using UnityEngine;

[CreateAssetMenu(fileName = "DebugDrawVRSettings", menuName = "Scriptable Objects/DebugDrawVRSettings")]
public class DebugDrawVRSettings : ScriptableObject
{
    public Material wireFrameMaterial;
    public Mesh cubeMesh;

    static DebugDrawVRSettings _instance;
    public static DebugDrawVRSettings Instance
    {
        get
        {
            if (_instance == null)
                _instance = Resources.Load<DebugDrawVRSettings>("DebugDrawVRSettings");
            return _instance;   
        }
    }
}
