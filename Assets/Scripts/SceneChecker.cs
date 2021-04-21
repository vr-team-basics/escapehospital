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

    public bool hud;

    private void Start()
    {
        spawner = GameObject.Find("CanvasSpawner");
        intro = GameObject.Find("CanvasIntro");
        hud = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            hud = !hud;
        }


        foreach (string s in SpawnerScene)
        {
            if (SceneManager.GetActiveScene().name == s)
            {
                spawner.SetActive(hud);
                break;
            }
            else if(intro.activeInHierarchy)
            {
                spawner.SetActive(!hud);
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