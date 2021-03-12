using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OxygenTest : MonoBehaviour
{
    // Our total oxygen at the start. Will need to tweak later on
    [SerializeField]
    private float Oxygen;

    // Base oxygen increase rate. Try to simulate inhales (I guess)
    [SerializeField]
    private float BaseIncreaseRate;

    // Base oxygen decrease rate. Actual oxygen decrease rate varies based on fires.
    [SerializeField]
    private float BaseDecreaseRate;

    // Weight of one fire on decrease rate
    [SerializeField]
    private float FireWeight;

    // How often should we calcualte oxygen levels (seconds)
    private float Seconds = 1;

    // Radius of OverlapSphere
    [SerializeField]
    private float Radius;

    // Amount of fires
    private uint NumOfFire;

    public Text uiText;

    // Calculate amount of oxygen every n seconds
    private void CalculateOxygen()
    {
        float DecreaseRate = BaseDecreaseRate + (BaseDecreaseRate * FireWeight * NumOfFire);
        DecreaseRate *= -1;
        Oxygen += DecreaseRate + BaseIncreaseRate;

        if(Oxygen < 0)
        {
            // Some signal to alert other systems that we dead
            Oxygen = 0;
        }

        // LOGs
        uiText.text = "Current Oxygen: " + Oxygen + " Number of fires: " + NumOfFire;
    }

    // Start is called before the first frame update
    void Start()
    {
        NumOfFire = 0;

        uiText = GameObject.FindGameObjectsWithTag("uiText")[0].GetComponent<Text>();

        // Call calculation method.
        InvokeRepeating("CalculateOxygen", 2.0f, Seconds);
    }

    // Update is called once per frame
    void Update()
    {
        NumOfFire = 0;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if(hitColliders[i].gameObject.tag.Equals("fire"))
            {
                NumOfFire++;
            }
        }
    }
}
