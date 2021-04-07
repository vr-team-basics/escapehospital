using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
public class temperature : MonoBehaviour
{

    private float[] heatCapacity;
    //private float heatCapacity;
    private Collider[] hitcolliders;
    public GameObject firePreFab;
    private Mesh mesh;
    private int verticeAmount;
    private int randomnumber;
    //vertices of the mesh
    private Vector3[] vertices;
    private int numberOfFires;
    private int maxNumFireForThisObject;
    private float threshold = 1000.0f;
    public GameObject firepropagatingPreFab;
    private bool done;

    
    // Start is called before the first frame update
    void Start()
    {
        //Set randomly at the beginning of the game
        //get the mesh this script is attached to and its vertices
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        done = false;
        numberOfFires = 0;
        maxNumFireForThisObject = 1;
        //get the number of vertices
        verticeAmount = mesh.vertexCount;
        //this.heatCapacity = 0;
        //heatCapacity indices correspond to the vertices indices! (tiee the vertices with their unique heatcapacity value!)
        
        heatCapacity = new float[verticeAmount];
        for (var i = 0; i < vertices.Length; i++)
        {
            //set initial values for each vertices
            heatCapacity[i] = 0;
        }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
public class temperature : MonoBehaviour
{


    private float[] heatCapacity;
    //private float heatCapacity;
    private Collider[] hitcolliders;
    public GameObject firePreFab;
    private Mesh mesh;
    private int verticeAmount;
    private int randomnumber;
    //vertices of the mesh
    private Vector3[] vertices;
    private int numberOfFires;
    private int maxNumFireForThisObject;
    private float threshold = 1000.0f;
    public GameObject firepropagatingPreFab;
    private bool done;

    
    // Start is called before the first frame update
    void Start()
    {
        //Set randomly at the beginning of the game
        //get the mesh this script is attached to and its vertices
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        done = false;
        numberOfFires = 0;
        maxNumFireForThisObject = 1;
        //get the number of vertices
        verticeAmount = mesh.vertexCount;
        //this.heatCapacity = 0;
        //heatCapacity indices correspond to the vertices indices! (tiee the vertices with their unique heatcapacity value!)
        
        heatCapacity = new float[verticeAmount];
        for (var i = 0; i < vertices.Length; i++)
        {
            //set initial values for each vertices
            heatCapacity[i] = 0;
        }
    }
    void GettingHotter(int verticeIndex)
    {
         heatCapacity[verticeIndex] += 40.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //the more fire around you, the higher the chance you go on fire
        //for each vertice, we want to look around for fire that is near IT
        if (numberOfFires <= maxNumFireForThisObject && !done)
        {
            hitcolliders = Physics.OverlapSphere(this.transform.position, 5f);
            for (var i = 0; i < vertices.Length / 2; i++)
            {
                //check for colliders around that vertice
                //may have to play around with the range
                //hitcolliders = Physics.OverlapSphere(vertices[i], 5f);
                foreach (Collider hitColide in hitcolliders)
                {
                    if (hitColide.tag == "fire")
                    {
                        GettingHotter(i);
                        //once heat amount has reached threshold, do it just once!
                        if (heatCapacity[i] == threshold && !done)
                        {
                            StartCoroutine(LetFireSpread(hitColide, vertices[i]));
                            //break out of the first for loop
                            done = true;
                            break;
                        }
                    }
                }
            }

        }
    }

    private IEnumerator LetFireSpread(Collider hitColide, Vector3 verticeIndex)
    {
        int value = 3;
        while (SpreadBetweenTwoPoints(hitColide.transform.position, this.transform.position, value))
        {
            value -= 1;
            yield return new WaitForSeconds(2f);
        }
        
        //just use normal fire prefab now!
        Instantiate(firepropagatingPreFab, this.transform.position, this.transform.rotation);

       // Instantiate(firepropagatingPreFab, verticeIndex, this.transform.rotation);

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

 
        if (value != 0)
        {
            //are they negative or positive
            incrementX = difference.x / value;
            incrementY = difference.y / value;
            incrementZ = difference.z / value;

            Instantiate(firepropagatingPreFab, new Vector3(initial.x + incrementX, initial.y + incrementY, initial.z + incrementZ), this.transform.rotation);
            return true;
        }
        return false;
    }
    
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

 
        if (value != 0)
        {
            //are they negative or positive
            incrementX = difference.x / value;
            incrementY = difference.y / value;
            incrementZ = difference.z / value;

            Instantiate(firepropagatingPreFab, new Vector3(initial.x + incrementX, initial.y + incrementY, initial.z + incrementZ), this.transform.rotation);
            return true;
        }
        return false;
    }
}
