using UnityEngine;

public class Collectible : MonoBehaviour
{
	public GameObject onCollectEffect;
	
	public float rotationSpeed = 0.5f;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		transform.Rotate(0, rotationSpeed, 0); 
	}
    
	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			// Destroy the collectible
			Destroy(gameObject);
		
			// instantiate the particle effect
			Instantiate(onCollectEffect, transform.position, transform.rotation);
		}
	}
}
