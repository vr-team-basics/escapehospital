using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishFireAndBreakOffDoorHandle : MonoBehaviour
{
    // Update is called once per frame
    //for now just make it an int
    //but how do i get a refernce to one of the buttons on the controller alias...
    private RaycastHit[] hits;
    private ParticleSystem thisParticle;
    public GameObject goo;
    private void Start()
    {
        //get a reference to the particle system attached to THIS game obejct 
        thisParticle = GetComponentInChildren<ParticleSystem>();
        thisParticle.Stop();
    }

    void Update()
    {
        //once the player let's go of the button, disable the and stop the particle system
        //thisParticle.Stop();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "hand")
        {
            //check for the button being pressed indicating that the player is using the fire extinquisher
            if (Input.GetKey(KeyCode.E))
            {
                //enable the particle system to start (foam is coming out)
                thisParticle.Play();
                
                // Play sound effect
                this.GetComponent<AudioSource>().Play();

                //play around with the arguments here
                //Shoot out a raycastall to get a list of the colliders
                hits = Physics.RaycastAll(thisParticle.transform.position, thisParticle.transform.forward, 15.0F);

                //Loop over the colliders checking to see if they have the tag, "Fire"
                foreach (RaycastHit hitObject in hits)
                {
                    //If they do, then delete them from the scene. 
                    if (hitObject.transform.tag == "fire")
                    {
                        StartCoroutine(Wait(hitObject));
                    }
                }
            }
        }

    }

    private IEnumerator Wait(RaycastHit hitObject)
    {
        int waitIndex = 1;
        while (waitIndex < 5)
        {
            yield return new WaitForSeconds(.5f);
            waitIndex += 1;
        }
        Destroy(hitObject.collider.gameObject);

    }
}
