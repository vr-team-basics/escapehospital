using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorRaiser : MonoBehaviour
{
    public GameObject wheel;
    public float wheelRotation;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        wheelRotation = wheel.transform.localEulerAngles.z;
        this.transform.position = new Vector3(this.transform.position.x, (5.3f - (wheel.transform.localEulerAngles.z / 90.0f)), this.transform.position.z);
    }
}
