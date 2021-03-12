using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    //this is a reference to the VRplayer
    public GameObject Door;
    private bool isdoorHandleOnStill;
    //do not need to know player exists


    void Start()
    {
        isdoorHandleOnStill = true;
        
    }
    // Update is called once per frame
    void Update()
    {
        //each door handle's initial rotaiton will be (0, 0, 0)
        //check to see how much THIS has been rotated. Once it reaches the right point, rotate door to open
        if (this.gameObject.transform.rotation.x <= -90 && isdoorHandleOnStill)
        {
            //rotate the door automatically -90 in the y direction
            //think about adding somewhat of a delay...
            Door.transform.rotation = Quaternion.Euler(new Vector3(Door.transform.rotation.x, -90, Door.transform.rotation.z));
        }
    }

    //Detect the collision with the fireextinquisher
    void OnCollisionEnter(Collision collision)
    {
        //checking for collision with the fire extinquisher
        if (collision.gameObject.name == "fireExtinguisher")
        {
            //some random number (make it super small to make sure it works
            if (collision.rigidbody.velocity.magnitude >= .1)
            {
                //get the rigidbody of this component
                Rigidbody rb = GetComponent<Rigidbody>();
                //turn the gravity on, allowing the handle to fall to the floor
                rb.useGravity = true;
                isdoorHandleOnStill = false;
            }
        }
    }
}
