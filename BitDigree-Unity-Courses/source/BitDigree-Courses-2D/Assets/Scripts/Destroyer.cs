using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
  [SerializeField]
  private float timeToKill = 2f;

    void Start()
    {
      GetComponent<Text>().text = SceneManager.GetActiveScene().name;
      Destroy(this.gameObject, timeToKill);
    }
}
