using UnityEditor;
using UnityEngine;

public class CreateVirtualRealityConsole
{
    [MenuItem("GameObject/VR Debug Package/Virtual Reality Console", false, 10)]
    static void CreateMyObject(MenuCommand menuCommand)
    {
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(
            "Packages/com.alex-stavrin.vr-debug-package/Prefabs/Canvas.prefab"
        );
        if (prefab == null)
        {
            Debug.LogError("Couldn’t find prefab at that path.");
            return;
        }
        var instance = (GameObject)PrefabUtility.InstantiatePrefab(
            prefab
        );
        GameObjectUtility.SetParentAndAlign(instance, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(instance, "Create VirtualRealityConsole");
        Selection.activeObject = instance;
    }
}
