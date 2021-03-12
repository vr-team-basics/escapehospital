using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] spawnables;
    public int randItem = 0;
    public GameObject spawned;

    // Start is called before the first frame update
    void Start()
    {
        randItem = Random.Range(0,spawnables.Length);
        Destroy(spawned);
        spawned = Instantiate(spawnables[randItem], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            randItem = Random.Range(0, spawnables.Length);
            Destroy(spawned);
            spawned = Instantiate(spawnables[randItem], transform.position, transform.rotation);
        }
        
    }
}
