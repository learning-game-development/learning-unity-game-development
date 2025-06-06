using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Something has collided with me!");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something has Trigger me!");
    }
}
