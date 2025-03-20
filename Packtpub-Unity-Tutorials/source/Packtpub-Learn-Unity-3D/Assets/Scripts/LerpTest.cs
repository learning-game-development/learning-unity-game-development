using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
	public float smoothing = 3f;
	private Vector3 originPosition = new Vector3(0, -3, 0);

    private void Update()
    {
        //move the cube back to the origin
        if(Input.GetKey(KeyCode.O))
        {
            transform.position = Vector3.Lerp(transform.position, originPosition, smoothing * Time.deltaTime);
        }
        
    }
}
