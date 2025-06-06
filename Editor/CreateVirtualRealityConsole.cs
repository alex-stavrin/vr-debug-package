using UnityEditor;
using UnityEngine;

public class CreateVirtualRealityConsole
{
    [MenuItem("GameObject/VR Debug Package/Virtual Reality Console", false, 10)]
    static void CreateVRConsole(MenuCommand menuCommand)
    {
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(
            "Packages/com.alex-stavrin.vr-debug-package/Prefabs/Virtual Reality Console.prefab"
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
        Undo.RegisterCreatedObjectUndo(instance, "Create Virtual Reality Console");
        Selection.activeObject = instance;
    }

    [MenuItem("GameObject/VR Debug Package/Virtual Reality Stats", false, 10)]
    static void CreateVRStats(MenuCommand menuCommand)
    {
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(
    "Packages/com.alex-stavrin.vr-debug-package/Prefabs/Virtual Reality Stats.prefab"
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
        Undo.RegisterCreatedObjectUndo(instance, "Create Virtual Reality Stats");
        Selection.activeObject = instance;
    }
}
