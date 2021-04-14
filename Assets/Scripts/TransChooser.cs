using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransChooser : MonoBehaviour
{
    public float[] trans = new float[0];
    Material thisMaterial;

    public void SetTrans(float index)
    {
        if (index < 0 || index >= trans.Length)
        {
            return;
        }
        thisMaterial.color = new Color(thisMaterial.color.r, thisMaterial.color.g, thisMaterial.color.b, trans[(int)index]);
    }

    // Start is called before the first frame update
    void Start()
    {
        thisMaterial = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
