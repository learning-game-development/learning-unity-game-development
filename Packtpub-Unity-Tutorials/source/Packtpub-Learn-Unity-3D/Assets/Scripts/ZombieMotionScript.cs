using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMotionScript : MonoBehaviour
{
	public float WalkX = 0;
	public float WalkZ = 0;
	
	// Callback for processing animation movements for modifying root motion.
	protected void OnAnimatorMove()
	{
		Animator animator = GetComponent<Animator>();
		if (animator)
		{
			Vector3 newPosition = transform.position;
			newPosition.x += WalkX * Time.deltaTime;
			newPosition.z += WalkZ * Time.deltaTime;
			transform.position = newPosition;
		}
	}
}
