using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float distASol;
    private float angulo = 90;
    public float velocidad;
    public Transform solTans;
    private Vector3 newPos;

    // Update is called once per frame

    private void Start()
    {
        distASol = transform.position.z;
    }
    void Update()
    {
        angulo += Time.deltaTime * velocidad;

        newPos = Vector3.zero;

        newPos.x = solTans.position.x + distASol * Mathf.Cos(angulo * Mathf.Deg2Rad);
        newPos.z = solTans.position.z + distASol * Mathf.Sin(angulo * Mathf.Deg2Rad);

        transform.position = newPos;
    }
}
