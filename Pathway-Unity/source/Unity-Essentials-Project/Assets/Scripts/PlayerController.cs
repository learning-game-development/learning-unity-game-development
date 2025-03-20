using UnityEngine;

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour
{
	public float speed = 5.0f; // Set player's movement speed.
	public float rotationSpeed = 120.0f; // Set player's rotation speed.
	public float jumpForce = 5.0f;

	private Rigidbody rb; // Reference to player's Rigidbody.

	// Start is called before the first frame update
	private void Start()
	{
		rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
		
		// Lock the X and Z rotation axes, keeping only Y rotation
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Jump")) {
			rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
		}
	}


	// Handle physics-based movement and rotation.
	private void FixedUpdate()
	{
		// Keep the player's rotation locked to the Y-axis only
		Vector3 currentRotation = rb.rotation.eulerAngles;
		currentRotation.x = 0f; // Lock rotation around X-axis
		currentRotation.z = 0f; // Lock rotation around Z-axis
		rb.rotation = Quaternion.Euler(currentRotation); // Apply the modified rotation
		
		// Move player based on vertical input.
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + movement);

		// Rotate player based on horizontal input.
		float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
		Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
		rb.MoveRotation(rb.rotation * turnRotation);
		
	}
}