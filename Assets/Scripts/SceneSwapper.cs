using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    public string SwapToScene;

    public string[] LoadScenes;
    public string[] UnloadScenes;

    [HideInInspector]
    public string MySceneName;

    #region Start
    private void Start()
    {
        MySceneName = gameObject.scene.name;
    }
    #endregion

    #region Object Swapping
    public void SwapObjects()
    {
        UpdateAdjacentScenes();
            try
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(SwapToScene));
            }
            catch
            {
                Debug.Log("Failed to swap scene..");
            }
            //AsyncOperation op = SceneManager.LoadSceneAsync(SwapToScene, LoadSceneMode.Additive);
            //op.completed += Op_completed;

            //void Op_completed(AsyncOperation obj)
            //{
            //}

    }
    #endregion
    private static bool IsLoaded(string name)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == name)
            {
                return true;
            }
        }
        return false;
    }
    private void UpdateAdjacentScenes()
    {
        try
        {

            foreach (string s in LoadScenes)
            {
                if (!IsLoaded(s))
                {
                    SceneManager.LoadSceneAsync(s, LoadSceneMode.Additive);
                }
            }

            foreach (string s in UnloadScenes)
            {
                if (IsLoaded(s))
                {
                    SceneManager.UnloadSceneAsync(s);
                }
            }
        }
        catch
        {
            Debug.Log("No scene to load or unload.");
        }
    }
}