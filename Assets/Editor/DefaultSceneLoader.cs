#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

[InitializeOnLoad]
public class DefaultSceneLoader
{
    static DefaultSceneLoader()
    {
        // Unity起動時の処理が落ち着いたタイミングで実行
        EditorApplication.delayCall += () =>
        {
            // まだシーンが開かれていない（Untitled/空の状態）場合のみ自動で開く
            if (string.IsNullOrEmpty(EditorSceneManager.GetActiveScene().path))
            {
                string targetScenePath = "Assets/TestScene.unity";
                
                if (File.Exists(targetScenePath))
                {
                    EditorSceneManager.OpenScene(targetScenePath);
                    UnityEngine.Debug.Log("[AutoLoader] TestSceneを自動ロードしました。");
                }
            }
        };
    }
}
#endif