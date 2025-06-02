using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ScenesLoader
{
    private const string ScenesPath = "Assets/Sources/Scenes";
    
    [MenuItem("Scenes/GameScene")]
    private static void LoadGameScene()
    { 
        LoadScene($"{ScenesPath}/Game.unity");
    }

    private static void LoadScene(string scenePath)
    {
        if (AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath) == null)
        {
            Debug.LogError($"Scene not found at path: {scenePath}");
            return;
        }
        
        EditorSceneManager.OpenScene(scenePath);
        Debug.Log($"Loaded scene: {scenePath}");
    }
}
