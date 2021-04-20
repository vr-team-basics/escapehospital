using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorRaiser : MonoBehaviour
{
    public GameObject open;
    public GameObject close;
    public GameObject door;
    public float speed;
    public bool opened = false;

    public void opendoor()
    {
        opened = true;
    }
    public void closedoor()
    {
        opened = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (opened)
        {
            transform.position = Vector3.MoveTowards(transform.position, open.transform.position, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, close.transform.position, step);
        }
    }
}
