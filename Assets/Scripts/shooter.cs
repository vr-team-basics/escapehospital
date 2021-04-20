using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletInst;

    public GameObject barrelTip;

    public float speed;

    public int shotsFired;
    float resetTimer;

    // Start is called before the first frame update
    void Start()
    {
        shotsFired = 0;
        resetTimer = Time.time + 1;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "hand")
        {
            if (Input.GetKeyDown(KeyCode.E) && shotsFired < 2 && Time.timeScale == 1)
            {
                gameObject.GetComponent<MyAudioManager>().HitRandom();
                bulletInst = Instantiate(bullet, barrelTip.transform.position, gameObject.transform.rotation);
                bulletInst.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * speed * 3000);
                shotsFired++;
            }
            if (Time.time > resetTimer)
            {
                shotsFired = 0;
                resetTimer = Time.time + 1;
            }
        }
    }
}
