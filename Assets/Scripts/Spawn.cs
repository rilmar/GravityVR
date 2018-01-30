using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{

    public GameObject planet;
    public int maxPlanets;
    public int spawnRadius = 500;
    public Material mat01, mat02, mat03, mat04;

    private bool firstClick = true;
    private int numPlanets;
    private GameObject newPlanet;
    private LineRenderer LR;

    void Start()
    {
        numPlanets = 0;
        LR = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (firstClick)
                createPlanet();
            else if (!firstClick)
                launchPlanet();
        }
        if (!firstClick)
        {
            LR.SetPosition(0, newPlanet.transform.position);
            LR.SetPosition(1, mouseLocation());
        } else
        {
            LR.SetPosition(0, Vector3.zero);
            LR.SetPosition(1, Vector3.zero);
        }

    }

    private void createPlanet()
    {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        // create a plane at 0,0,0 whose normal points to +Y:
        Plane hPlane = new Plane(Vector3.up, Vector3.zero);
        // Plane.Raycast stores the distance from ray.origin to the hit point in this variable:
        float distance = 0;
        // if the ray hits the plane...
        if (hPlane.Raycast(ray, out distance))
        {
            // get the hit point:
            Vector3 location = ray.GetPoint(distance);
            newPlanet = (GameObject)Instantiate(planet, Vector3.ClampMagnitude(location, spawnRadius), transform.rotation);
            firstClick = false;
            //generate value to assign a material randomly
            int matGen = Random.Range(0, 4) + 1;
            switch (matGen)
            {
                case 1:
                    newPlanet.GetComponent<Renderer>().material = mat01;
                    break;
                case 2:
                    newPlanet.GetComponent<Renderer>().material = mat02;
                    break;
                case 3:
                    newPlanet.GetComponent<Renderer>().material = mat03;
                    break;
                case 4:
                    newPlanet.GetComponent<Renderer>().material = mat04;
                    break;
            }

        }

    }
    private void launchPlanet()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        // create a plane at 0,0,0 whose normal points to +Y:
        Plane hPlane = new Plane(Vector3.up, Vector3.zero);
        // Plane.Raycast stores the distance from ray.origin to the hit point in this variable:
        float distance = 0;
        // if the ray hits the plane...
        if (hPlane.Raycast(ray, out distance))
        {
            // get the hit point:
            Vector3 location = ray.GetPoint(distance);
            Vector3 launchForce = (location - newPlanet.transform.position) * 10;
            newPlanet.GetComponent<Rigidbody>().AddForce(launchForce);
        }
        newPlanet.tag = "planet";


        firstClick = true;

    }
    private Vector3 mouseLocation()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        // create a plane at 0,0,0 whose normal points to +Y:
        Plane hPlane = new Plane(Vector3.up, Vector3.zero);
        // Plane.Raycast stores the distance from ray.origin to the hit point in this variable:
        float distance = 0;
        // if the ray hits the plane...
        if (hPlane.Raycast(ray, out distance))
        {
            // get the hit point:
            Vector3 location = ray.GetPoint(distance);
            return location;
        }
        return Vector3.zero;
    }

    public void destroyedPlanet()
    {
        numPlanets--;
    }
    public void clearPlanets()
    {
        numPlanets = 0;
    }



}
