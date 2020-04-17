using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public guidedCam1 cam;

    public Movement1 planetPrefab;

    public GameObject atmosphere;

    public List<Material> planetMaterials;

    public List<Movement1> generatedPlanets = new List<Movement1>();

    public GameObject metheor;

    public int metheorAmount;

    public int planetAmount;
    
    int randAux;

    float timer = 0.0f;
    private void Awake()
    {
        randAux = (int)Random.Range(0.0f, planetAmount - 1);
        for (int i = 0; i < planetAmount; i++)
        {
            GameObject go = Instantiate(planetPrefab, new Vector3(0, 0, 20.0f + i * 10.0f), Quaternion.identity).gameObject;

            Movement1 p = go.GetComponent<Movement1>();

            go.GetComponent<MeshRenderer>().material = planetMaterials[Random.Range(0, planetMaterials.Count)];

            p.radius = Random.Range(2, 6);

            p.solTans = gameObject.transform;

            p.velocidad = Random.Range(2, 40);

            p.rotationVector = new Vector3((int)Random.Range(0.01f, 1.99f), (int)Random.Range(0.01f, 1.99f), (int)Random.Range(0.01f, 1.99f));

            p.rotationSpeed = Random.Range(5, 10);

            if (i == randAux)
            {
                atmosphere.SetActive(true);
                atmosphere.transform.position = go.transform.position;
                atmosphere.transform.localScale = go.transform.localScale * 1.5f;
                atmosphere.transform.parent = go.transform;
            }

            generatedPlanets.Add(p);
            cam.planets.Add(go);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 8.0f)
        {
            MetheorRain();
            timer = 0.0f;
        }

    }
    void MetheorRain()
    {
        for (int i = 0; i < metheorAmount; i++)
        {
            Instantiate(metheor, new Vector3(Random.Range(-50, 50), 80.0f, Random.Range(-50, 50)), Quaternion.Euler(Vector3.zero));
        }
    }
}
