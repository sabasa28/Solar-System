using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metheor : MonoBehaviour
{
    float speed = 10000.0f;
    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-2,2),-10,Random.Range(-2, 2))*Time.deltaTime*speed);
    }
    void Update()
    {
        if (transform.position.y < -150.0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Metheor")
        {
            Destroy(gameObject);
        }
    }
}
