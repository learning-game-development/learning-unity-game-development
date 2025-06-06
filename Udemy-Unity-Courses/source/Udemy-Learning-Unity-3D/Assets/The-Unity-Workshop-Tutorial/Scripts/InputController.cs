using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    float fireRate = 1f;
    float nextFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > nextFire)
            {
                Debug.Log("Fire1!");
                nextFire = Time.time + fireRate;
            }
        }
    }
}
