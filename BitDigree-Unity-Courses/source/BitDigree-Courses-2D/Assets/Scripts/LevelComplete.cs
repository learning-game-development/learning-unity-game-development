using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
  [SerializeField]
  private string nextLevelSceneName = "Levelx";

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.CompareTag("Player"))
    {
      SceneManager.LoadScene(nextLevelSceneName);
    }
  }
}
