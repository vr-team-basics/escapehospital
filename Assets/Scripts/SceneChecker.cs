using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChecker : MonoBehaviour
{

    public string[] SpawnerScene;
    public string[] IntroScene;

    public GameObject spawner;
    public GameObject intro;

    private void Start()
    {
        spawner = GameObject.Find("CanvasSpawner");
        intro = GameObject.Find("CanvasIntro");
    }
    void Update()
    {
        foreach (string s in SpawnerScene)
        {
            if (SceneManager.GetActiveScene().name == s)
            {
                spawner.SetActive(true);
                break;
            }
            else if(intro.activeInHierarchy)
            {
                spawner.SetActive(false);
            }

        }
        foreach (string s in IntroScene)
        {
            if (SceneManager.GetActiveScene().name == s)
            {
                intro.SetActive(true);
                break;
            }
            else if(spawner.activeInHierarchy)
            {
                intro.SetActive(false);
            }

        }
    }
}