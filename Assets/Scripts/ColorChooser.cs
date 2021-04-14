using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChooser : MonoBehaviour
{
    public Color[] colors = new Color[0];
    Material thisMaterial;

    public void SetColor(float index)
    {
        if (index < 0 || index >= colors.Length)
        {
            return;
        }
        thisMaterial.color = colors[(int)index];
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
