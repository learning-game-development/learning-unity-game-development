using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(0, 90 * Time.deltaTime, 0);
    // transform.position = new Vector3(transform.position.x, transform.position.y + (2f), transform.position.z);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.name == "Player")
    {
      other.GetComponent<PlayerScript>().points = other.GetComponent<PlayerScript>().points + 5;
      Destroy(gameObject);
    }
  }

}
