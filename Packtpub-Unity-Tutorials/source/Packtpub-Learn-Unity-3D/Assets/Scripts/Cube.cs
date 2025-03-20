using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float sizeModifier = 0.5f;
    public string newName = "Cubey1337";
    public bool isRotated = false;

    void Start()
    {
        Debug.Log("Hello world!");

        if (isRotated)
        {
            transform.localEulerAngles = Vector3.one * 45;
        }
    }

    void Update()
    {
        transform.localScale = Vector3.one * sizeModifier;
    }
}
