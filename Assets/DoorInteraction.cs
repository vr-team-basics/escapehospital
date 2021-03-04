using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    //this is a reference to the VRplayer
    public GameObject Door;
    //do not need to know player exists
    
    // Update is called once per frame
    void Update()
    {
        //each door handle's initial rotaiton will be (0, 0, 0)
        //check to see how much THIS has been rotated. Once it reaches the right point, rotate door to open
        if (this.gameObject.transform.rotation.x <= -90)
        {
            //rotate the door automatically -90 in the y direction
            //think about adding somewhat of a delay...
            Door.transform.rotation = Quaternion.Euler(new Vector3(Door.transform.rotation.x, -90, Door.transform.rotation.z));
        }
    }
}
