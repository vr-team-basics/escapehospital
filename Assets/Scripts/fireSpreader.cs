using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSpreader : MonoBehaviour
{
    private int rndBox = 0;  //To wall or not to wall.
    private int rndFire = 0;

    public GameObject fireBoxInst;
    public GameObject fireInst;

    //private int isOnFire = 0;
    private Vector3 clonePos;

    public List<GameObject> fireBoxes = new List<GameObject>();
    public List<GameObject> fires = new List<GameObject>();

    private int grid = 5;
    public int size = 80;

    // Start is called before the first frame update
    void Start()
    {
        roomFiller();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            roomFiller();
        }
    }

    void roomFiller()
    {
        //Destroy old bits.
        for (int i = 0; i < fireBoxes.Count; i++)
        {
            Destroy(fireBoxes[i]);
        }
        for (int i = 0; i < fires.Count; i++)
        {
            Destroy(fires[i]);
        }
        fireBoxes = new List<GameObject>(0);
        fires = new List<GameObject>(0);

        //Make new bits.
        for (int x = (-size / 2); x <= (size / 2); x += grid)
        {
            rndBox = Random.Range(0, 3);
            if ((rndBox == 1) && x % 35.0 == 0.0)// || x == size / 2) && !(x == (-size / 2) + grid || x == (size / 2) - grid))
            {
                clonePos = new Vector3(x, 12.5f, 45.0f);
                fireBoxes.Add(Instantiate(fireBoxInst, clonePos, fireBoxInst.transform.rotation));
            }
            for (int z = (-size / 2) + (grid / 2); z <= (size / 2) - (grid / 2); z += grid)
            {
                rndFire = Random.Range(0, 3);
                
                if ((rndFire == 1))// && !(x == (-size / 2) + grid || x == (size / 2) - grid))
                {
                    clonePos = new Vector3(x, 0.0f, z);
                    fires.Add(Instantiate(fireInst, clonePos, fireInst.transform.rotation));
                }
            }

        }
    }
}
