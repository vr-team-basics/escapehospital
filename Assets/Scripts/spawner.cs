using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] spawnables;
    public int randItem = 0;

    // Start is called before the first frame update
    void Start()
    {
        randItem = Random.Range(0,spawnables.Length);
        Instantiate(spawnables[randItem], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
