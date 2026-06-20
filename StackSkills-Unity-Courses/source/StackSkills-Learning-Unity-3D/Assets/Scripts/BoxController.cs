using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float speed = 0;
    public float strafe_speed = 0;

    /*
    'BoxController.rigidbody' hides inherited member 'Component.rigidbody'. 
    Use the new keyword if hiding was intended. */
    // private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float controlled_walk_speed = Input.GetAxis("Horizontal") * speed;
        float controlled_strafe_speed = Input.GetAxis("Vertical") * strafe_speed;
        
        GetComponent<Rigidbody>().AddForce(controlled_walk_speed, 0, controlled_strafe_speed);
    }
}
