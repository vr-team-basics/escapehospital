using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLighter : MonoBehaviour
{
    public bool lit;
    public GameObject thisLight;
    public GameObject thisSwitch;

    // Start is called before the first frame update
    void Start()
    {
        lit = false;
        thisLight = this.transform.GetChild(0).GetChild(0).GetChild(3).gameObject;
        thisSwitch = this.transform.GetChild(0).GetChild(0).GetChild(2).gameObject;
        thisLight.SetActive(lit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "hand")
        {
            //check for the button being pressed indicating that the player is using the flashlight
            if (Input.GetKey(KeyCode.F))
            {
                lit = !lit;
                thisLight.SetActive(lit);
                if (lit)
                {
                    thisSwitch.transform.localEulerAngles = new Vector3(10.0f, thisSwitch.transform.localEulerAngles.y, thisSwitch.transform.localEulerAngles.z);
                }
                else
                {
                    thisSwitch.transform.localEulerAngles = new Vector3(-10.0f, thisSwitch.transform.localEulerAngles.y, thisSwitch.transform.localEulerAngles.z);
                }
            }
        }

    }
}
