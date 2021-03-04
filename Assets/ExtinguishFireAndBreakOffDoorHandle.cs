using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishFireAndBreakOffDoorHandle : MonoBehaviour
{
    // Update is called once per frame
    //for now just make it an int
    //but how do i get a refernce to one of the buttons on the controller alias...
    private int buttonValue = 0;
    private RaycastHit[] hits;
    private ParticleSystem thisParticle;
    public GameObject capsuleref;

    void Update()
    {
        //check for the button being pressed indicating that the player is using the fire extinquisher
        if (buttonValue == 0)
        {
            //get a reference to the particle system attached to THIS game obejct 
            thisParticle = GetComponentInChildren<ParticleSystem>();

            //enable the particle system to start (foam is coming out)
            thisParticle.Play();

            //play around with the arguments here
            //Shoot out a raycastall to get a list of the colliders
            hits = Physics.RaycastAll(thisParticle.transform.position, capsuleref.transform.localScale, 100.0F);

            //Loop over the colliders checking to see if they have the tag, "Fire"
            foreach (RaycastHit hitObject in hits)
            {
                //If they do, then delete them from the scene. 
                if (hitObject.transform.tag == "fire")
                {
                    Destroy(hitObject.collider.gameObject);

                }
            }
        }
        //once the player let's go of the button, disable the and stop the particle system
        thisParticle.Stop();
    }
}
