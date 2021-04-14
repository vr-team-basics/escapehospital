using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    public string SwapToScene;

    public string[] LoadScenes;
    public string[] UnloadScenes;

    [HideInInspector]
    public string MySceneName;
    
    private void Start()
    {
        MySceneName = gameObject.scene.name;
        SwapObjects();
    }

    public void SwapObjects()
    {
        if (MySceneName == SceneManager.GetActiveScene().name)
        {
            UpdateAdjacentScenes();
            AsyncOperation op = SceneManager.LoadSceneAsync(SwapToScene, LoadSceneMode.Additive);
            op.completed += Op_completed;

            void Op_completed(AsyncOperation obj)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(SwapToScene));
            }
        }
    }

    private void UpdateAdjacentScenes()
    {
        foreach (string s in LoadScenes)
        {
            Debug.Log("Loading: " + s);
            SceneManager.LoadSceneAsync(s, LoadSceneMode.Additive);
        }

        foreach (string s in UnloadScenes)
        {
            Debug.Log("Unloading: " + s);
            SceneManager.UnloadSceneAsync(s);
        }
    }
}