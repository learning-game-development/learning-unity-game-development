using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBehaviour : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float z = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(x, y, z));
    }
}
