using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
public class temperature : MonoBehaviour
{


    private float heatCapacity;
    private Collider[] hitcolliders;
    public GameObject firePreFab;
    private Mesh mesh;
    private Vector3[] vertices;
    static private float threshold = 2000.0f;
    public GameObject firepropagatingPreFab;
    private int done;


    // Start is called before the first frame update
    void Start()
    {
        //Set randomly at the beginning of the game
        //get the mesh this script is attached to and its vertices
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        heatCapacity = 0;
        done = 0;
    }

    void GettingHotter()
    {
        this.heatCapacity += 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //the more fire around you, the higher the chance you go on fire
        if (done == 0)
        {
            //for each vertice, we want to look around for fire that is near IT
            for (var i = 0; i < vertices.Length; i++)
            {
                //check for colliders around that vertice
                //may have to play around with the range
                hitcolliders = Physics.OverlapSphere(vertices[i], 2f);
                foreach (Collider hitColide in hitcolliders)
                {
                    if (hitColide.tag == "Fire")
                    {
                        GettingHotter();
                        if (heatCapacity >= threshold && done == 0)
                        {
                            StartCoroutine(LetFireSpread(hitColide));
                            done = 1;
                            this.tag = "Fire";
                            break;
                        }
                    }
                }

            }
        }
    }

    private IEnumerator LetFireSpread(Collider hitColide)
    {
        int value = 3;
        while (SpreadBetweenTwoPoints(hitColide.transform.position, this.transform.position, value))
        {
            value -= 1;
            yield return new WaitForSeconds(.5f);
        }
        //just use normal fire prefab now!
        Instantiate(firepropagatingPreFab, this.transform.position, this.transform.rotation);

    }



    Vector3 DistanceBetweenTheTwoInEachAxis(Vector3 initial, Vector3 final)
    {
        //Get the distance between each x, y, z of the two vectors!
        Vector3 distance;
        distance.x = final.x - initial.x;
        distance.y = final.y - initial.y;
        distance.z = final.z - initial.z;
        return distance;
    }
    bool SpreadBetweenTwoPoints(Vector3 initial, Vector3 final, int value)
    {
        //the distance between any two fires will always be below 5.0f (BECAUSE OF THE RADIUS YOU HAVE NOW) THIS CAN BE CHANGED THOUGH SO BE CAREFUL!
        float incrementX = 0.0f;
        float incrementY = 0.0f;
        float incrementZ = 0.0f;

        //get the difference in each axis
        Vector3 difference = DistanceBetweenTheTwoInEachAxis(initial, final);

        //are they negative or positive
        incrementX = difference.x / value;
        incrementY = difference.y / value;
        incrementZ = difference.z / value;
        if (value != 0)
        {
            Instantiate(firepropagatingPreFab, new Vector3(initial.x + incrementX, initial.y + incrementY, initial.z + incrementZ), this.transform.rotation);
            return true;
        }
        return false;
    }

    //ORIGINAL COPY INCASE SOMETHING HAPPENS
    /*
    void GettingHotter()
    {
        this.heatCapacity += 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //the more fire around you, the higher the chance you go on fire
        if (done == 0)
        {
            hitcolliders = Physics.OverlapSphere(this.transform.position, 2f);
            foreach (Collider hitColide in hitcolliders)
            {
                if (hitColide.tag == "fire")
                {
                    GettingHotter();
                    if (heatCapacity >= threshold && done == 0)
                    {
                        StartCoroutine(LetFireSpread(hitColide));
                        done = 1;
                        this.tag = "fire";
                        break;
                    }
                }
            }
        }
    }

    private IEnumerator LetFireSpread(Collider hitColide)
    {
        int value = 3;
        while (SpreadBetweenTwoPoints(hitColide.transform.position, this.transform.position, value))
        {
            value -= 1;
            yield return new WaitForSeconds(.5f);
        }
        Instantiate(firePreFab, this.transform.position, this.transform.rotation);
        
    }



    Vector3 DistanceBetweenTheTwoInEachAxis(Vector3 initial, Vector3 final)
    {
        //Get the distance between each x, y, z of the two vectors!
        Vector3 distance;
        distance.x = final.x - initial.x;
        distance.y = final.y - initial.y;
        distance.z = final.z - initial.z;
        return distance;
    }
    bool SpreadBetweenTwoPoints(Vector3 initial, Vector3 final, int value)
    {
        //the distance between any two fires will always be below 5.0f (BECAUSE OF THE RADIUS YOU HAVE NOW) THIS CAN BE CHANGED THOUGH SO BE CAREFUL!
        float incrementX = 0.0f;
        float incrementY = 0.0f;
        float incrementZ = 0.0f;

        //get the difference in each axis
        Vector3 difference = DistanceBetweenTheTwoInEachAxis(initial, final);

        //are they negative or positive
        incrementX = difference.x / value;
        incrementY = difference.y / value;
        incrementZ = difference.z / value;
        if (value != 0)
        {
            Instantiate(firepropagatingPreFab, new Vector3(initial.x + incrementX, initial.y + incrementY, initial.z + incrementZ), this.transform.rotation);
            return true;
        }
        return false;
    }
    */
}
