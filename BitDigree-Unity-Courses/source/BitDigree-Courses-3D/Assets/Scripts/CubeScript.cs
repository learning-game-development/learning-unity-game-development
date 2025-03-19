using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
  int myNumber = 8;
  int mySecondNumber = 3;
  float myFloatNumber = 0.5f;
  int theScore = 100;
  public string myString = "Skerwe";

  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("Cude Script Started");
    Debug.Log("[myNumber=" + myNumber
    + ", mySecondNumber=" + mySecondNumber
    + ", myFloatNumber=" +myFloatNumber
    + ", theScore=" + theScore + "]");
  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(mySecondNumber, 0, 0);
  }
}
