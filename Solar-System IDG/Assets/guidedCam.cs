using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guidedCam : MonoBehaviour
{

    public GameObject[] planets;
    public Vector3[] planetMovement;
    public Vector3 offset;
    int timeInPlanet = 5;
    int timer = 0;
    int currentPlanet = 0;

    private void Start()
    {
        for (int i = 0; i < planetMovement.Length; i++)
        {
            planetMovement[i] = planets[i].GetComponent<Movement>().movementPerFrame;
        }
    }
    void LateUpdate()
    {
        for (int i = 0; i < planetMovement.Length; i++)
        {
            planetMovement[i] = planets[i].GetComponent<Movement>().movementPerFrame;
        }

        if (timer <= (int)Time.time - timeInPlanet)
        {
            timer = (int)Time.time;
            currentPlanet++;
            currentPlanet %= planets.Length;
        }

        transform.position += planetMovement[currentPlanet];

        transform.position = Vector3.Lerp(transform.position,planets[currentPlanet].transform.position+offset, Time.deltaTime);

    }

}
