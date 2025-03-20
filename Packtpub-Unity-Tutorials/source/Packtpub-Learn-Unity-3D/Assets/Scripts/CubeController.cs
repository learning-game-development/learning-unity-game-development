using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject cubePrefab;
    public int cubeAmount = 10;

    void Start()
    {
        for (int i = 0; i < cubeAmount; i++)
        {
            GameObject cubeObject = Instantiate(cubePrefab);
            cubeObject.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        }
    }

    void Update()
    {
        
    }
}
