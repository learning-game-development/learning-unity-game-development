using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualCubeMove : MonoBehaviour
{
	public float rotationSpeed = 50;
	public float travelSpeed = 5;
	
    void Start()
    {
        
    }

    void Update()
    {
	    if(Input.GetKey(KeyCode.LeftArrow)) {
		    transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
	    }

	    if(Input.GetKey(KeyCode.RightArrow)) {
	    	transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
	    }
	    
	    if(Input.GetKey(KeyCode.UpArrow)) {
		    transform.Translate(Vector3.up * travelSpeed * Time.deltaTime);
	    }
	    
	    if(Input.GetKey(KeyCode.DownArrow)) {
		    transform.Translate(Vector3.down * travelSpeed * Time.deltaTime);
	    }
    }
}
