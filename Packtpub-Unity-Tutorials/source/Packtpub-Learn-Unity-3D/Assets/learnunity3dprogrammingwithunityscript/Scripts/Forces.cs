using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forces : MonoBehaviour
{
	public float aForce = 5;
	
	private Rigidbody rb;
	
	public void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	public void FixedUpdate () {
		//rb.AddForce (Vector3.right * aForce);
		//rb.AddTorque (Vector3.right * aForce );
	}
	
	public void OnMouseDown () 
	{
		rb.AddForce (Vector3.forward * aForce);
		//rb.AddTorque (Vector3.right * aForce);
	}
}
