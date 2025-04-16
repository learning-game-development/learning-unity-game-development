using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCamera : MonoBehaviour
{
	public Transform cameraTarget;
	
	void Update () {
		transform.LookAt(cameraTarget);
	}
}
