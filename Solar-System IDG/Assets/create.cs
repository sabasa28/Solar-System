using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
	public guidedCam1 cam;

	public Movement1 planetPrefab;

	public List<Material> planetMaterials;

	public List<Movement1> generatedPlanets = new List<Movement1>();

	public int planetAmount;

	private float time = 0;

	private void Awake()
	{
		for (int i = 0; i < planetAmount; i++)
		{
			GameObject go = Instantiate(planetPrefab, new Vector3(0, 0, 20.0f + i * 10.0f), Quaternion.identity).gameObject;

			Movement1 p = go.GetComponent<Movement1>();
			
			go.GetComponent<MeshRenderer>().material = planetMaterials[Random.Range(0, planetMaterials.Count)];

			p.radius = Random.Range(1, 5);

			p.solTans = gameObject.transform;

			p.velocidad = Random.Range(2, 40);

			p.rotationVector = new Vector3 ((int)Random.Range(0.01f,1.99f), (int)Random.Range(0.01f, 1.99f), (int)Random.Range(0.01f, 1.99f));

			p.rotationSpeed = Random.Range(5, 10);

			generatedPlanets.Add(p);
			cam.planets.Add(go);
		}
	}

	void Update()
	{
		time += Time.deltaTime; //eliminar?
	}
}
