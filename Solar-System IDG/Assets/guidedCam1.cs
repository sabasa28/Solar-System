using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guidedCam1 : MonoBehaviour
{

    public List<GameObject> planets = new List<GameObject>();
    public List<Vector3> planetMovement = new List<Vector3>();
    public Vector3 offset;
    public float movementSpeed = 1.0f;
    public GameObject ship;
    int currentPlanet = -1;
    int shipIndex;
    Vector3 originalPos;
    Vector3 targetedPos;

    private void Start()
    {
        for (int i = 0; i < planets.Count; i++)
        {   
            planetMovement.Add(planets[i].GetComponent<Movement1>().movementPerFrame);
        }
        planetMovement.Add(ship.GetComponent<Ship>().movementPerFrame);
        shipIndex = planetMovement.Count-1;
        targetedPos= originalPos = transform.position;
    }
    void LateUpdate()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            planetMovement[i]=planets[i].GetComponent<Movement1>().movementPerFrame;
        }
        planetMovement[shipIndex] =ship.GetComponent<Ship>().movementPerFrame;

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            currentPlanet = -1;
            targetedPos = originalPos;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            if (planets[0]) currentPlanet = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (planets[1]) currentPlanet = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (planets[2]) currentPlanet = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (planets[3]) currentPlanet = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (planets[4]) currentPlanet = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (planets[5]) currentPlanet = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (planets[6]) currentPlanet = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (planets[7]) currentPlanet = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            currentPlanet = -2;
        }

        if (currentPlanet > -1)
        {
            transform.position += planetMovement[currentPlanet];
            targetedPos = planets[currentPlanet].transform.position + offset;
        }
        else if (currentPlanet == -2)
        {
            transform.position += planetMovement[shipIndex];
            targetedPos = ship.transform.position + offset;
        }

        transform.position = Vector3.Lerp(transform.position, targetedPos, movementSpeed * Time.deltaTime);

    }

}
