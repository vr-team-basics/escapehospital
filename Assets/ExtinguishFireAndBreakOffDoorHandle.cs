using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishFireAndBreakOffDoorHandle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //check for a button press indicating that the player is using the fire extinquisher
            //If the button is pressed, enable and start the particle system
                //Should out a raycastall to get a list of the colliders
                    //Loop over the colliders checking to see if they have the tag, "Fire"
            //once the player let's go of the button, disable the and stop the particle system
    }
}
