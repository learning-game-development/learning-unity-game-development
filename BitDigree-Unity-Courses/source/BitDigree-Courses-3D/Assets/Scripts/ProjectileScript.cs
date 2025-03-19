using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speedX = 0.01f;
    public float speedY = 0.01f;

    public float amplitude = 10;

    public float initialAngle = 30; // in degrees
    public float degrees = 0;
    public float delta = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        degrees = initialAngle;
    }

    // Update is called once per frame
    void Update()
    {
        // Projectile update the horizontal and vertical position
        // Horizontal: linear equation
        // Vertical: cos()
        float deltaY = Mathf.Cos(degrees * Mathf.Deg2Rad);
        degrees -= delta;
        float positionY = transform.position.y + deltaY;

        transform.position = new Vector3(
            transform.position.x + speedX * Time.deltaTime, 
            positionY, 
            transform.position.z
        );
    }
}
