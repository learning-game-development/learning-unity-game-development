using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j")) {
            Jump();
        }
    }

    void Jump() {
        Rigidbody body = this.GetComponent<Rigidbody>();
        body.AddForce(new Vector3(0, jumpForce, 0));
    }
}
