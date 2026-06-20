using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float acceleration = 50f;
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private SpriteRenderer sRenderer;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        if(inputX != 0)
        {
            Vector2 move = new Vector2(inputX * acceleration * Time.deltaTime, 0);

            rigidbody2d.AddForce(move);

            sRenderer.flipX = inputX > 0 ? false : true;
        }

        if(animator)
        {
            animator.SetFloat("InputX", Mathf.Abs(inputX));
        }
    }
}
