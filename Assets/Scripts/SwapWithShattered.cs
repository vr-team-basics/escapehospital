using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWithShattered : MonoBehaviour
{
    // Settings for shattering conditions
    [SerializeField]
    private GameObject ShatteredVariant;

    [SerializeField]
    private float MinMassThreshold;

    // Only spawn one shatteredvariant
    bool spawnedShattered;

    // Start is called before the first frame update
    void Start()
    {
        spawnedShattered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Get the other game object
        GameObject otherObject = collision.gameObject;

        // Check if other object has Rigidbody
        if(otherObject.GetComponent<Rigidbody>() != null)
        {
            // If other object is dense enough, spawn shattered variant. Only if it hasn't spawned one
            if (otherObject.GetComponent<Rigidbody>().mass >= MinMassThreshold && !spawnedShattered)
            {
                // Make sure to keep parent to have all scales applied
                GameObject newObject = Instantiate(ShatteredVariant, transform.position, transform.rotation, transform.parent);
                newObject.transform.localScale = transform.localScale;
                spawnedShattered = true;

                Destroy(gameObject);
            }
        }
    }
}
