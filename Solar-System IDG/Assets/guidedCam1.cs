using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guidedCam1 : MonoBehaviour
{

    public List<GameObject> planets = new List<GameObject>();
    public List<Vector3> planetMovement = new List<Vector3>();
    public Vector3 offset;
    public float movementSpeed = 1.0f;
    int timeInPlanet = 5;
    int timer = 0;
    int currentPlanet = 0;

    private void Start()
    {
        for (int i = 0; i < planets.Count; i++)
        {   
            planetMovement.Add(planets[i].GetComponent<Movement1>().movementPerFrame);
        }
    }
    void LateUpdate()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            planetMovement[i]=(planets[i].GetComponent<Movement1>().movementPerFrame);
        }
        //for (int i = 0; i < planetMovement.Length; i++)
        //{
        //    planetMovement[i] = planets[i].GetComponent<Movement1>().movementPerFrame;
        //}
        //
        //if (timer <= (int)Time.time - timeInPlanet)
        //{
        //    timer = (int)Time.time;
        //    currentPlanet++;
        //    currentPlanet %= planets.Count;
        //}
        //
        //transform.position += planetMovement[currentPlanet];
        //
        //transform.position = Vector3.Lerp(transform.position,planets[currentPlanet].transform.position+offset, movementSpeed * Time.deltaTime);

    }

}
