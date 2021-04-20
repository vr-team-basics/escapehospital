using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class hitCount : MonoBehaviour
{
    public int count;
    public TMP_Text countValue;

    public void increment()
    {
        count++;
    }
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        countValue.text = count.ToString();
    }
}
