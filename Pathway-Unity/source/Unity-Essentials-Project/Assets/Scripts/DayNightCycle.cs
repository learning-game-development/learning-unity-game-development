using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
	// The time in seconds for a full day to pass (editable in the Inspector)
	public float dayDuration = 60f;

	// The speed of rotation based on the dayDuration (calculated in the Update method)
	private float rotationSpeed;

	private void Start()
	{
		// Initialize the rotation speed based on the dayDuration
		rotationSpeed = 360f / dayDuration;  // 360 degrees per full day cycle
	}

	private void Update()
	{
		// Rotate the light around the X-axis to simulate the passing of the day
		transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
	}
}
