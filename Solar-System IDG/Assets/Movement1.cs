﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    public float distASol;
    private float angulo = 90;
    public float velocidad;
    public Transform solTans;
    private Vector3 newPos;
    public Vector3 movementPerFrame;
    public float radius;
    public float rotationSpeed = 10;
    public Vector3 rotationVector;
    Vector3 AuxB = Vector3.zero;
    Vector3 AuxA;


    private void Start()
    {
        distASol = transform.position.z;
        transform.localScale = new Vector3(radius, radius, radius);
    }
    void Update()
    {
        angulo += Time.deltaTime * velocidad;

        newPos.x = solTans.position.x + distASol * Mathf.Cos(angulo * Mathf.Deg2Rad);
        newPos.z = solTans.position.z + distASol * Mathf.Sin(angulo * Mathf.Deg2Rad);
        
        transform.position = newPos;

        transform.Rotate(rotationVector * Time.deltaTime * rotationSpeed);
        
        AuxA = AuxB;
        AuxB = transform.position;
        movementPerFrame = new Vector3(AuxB.x - AuxA.x, AuxB.y - AuxA.y, AuxB.z - AuxA.z);
    }
}