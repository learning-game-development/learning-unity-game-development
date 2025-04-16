using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWalk : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
	    animator.SetFloat("Speed", Input.GetAxis("Vertical"));
	    
	    animator.SetFloat("Direction", Input.GetAxis("Horizontal"));
	    float directionInputValue = Input.GetAxis("Horizontal");
	    Debug.Log(directionInputValue);
    }
}
