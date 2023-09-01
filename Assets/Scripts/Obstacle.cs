using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().TriggerObstacle();
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.AddForce(0, 15, -15, ForceMode.Impulse);
        }

    }
}
