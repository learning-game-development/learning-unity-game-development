using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
  [SerializeField]
  private bool isMusicOn = true;

  public void Start()
  {
    DontDestroyOnLoad(this.gameObject);
    if (PlayerPrefs.HasKey("MusicEnabled"))
    {
      if (PlayerPrefs.GetString("MusicEnabled") == "true")
      {
        isMusicOn = true;
      }
      else if (PlayerPrefs.GetString("MusicEnabled") == "false")
      {
        isMusicOn = false;
      }
    }

    SceneManager.activeSceneChanged += ChangeActiveScene;
    PlayMusic();
  }

  // Runs everytime the scene change
  public void ChangeActiveScene(Scene currentScene, Scene nextScene)
  {
    if (nextScene.name == "MainMenu")
    {
      Destroy(this.gameObject);
    }
  }

  public void PlayMusic()
  {
    if (isMusicOn)
    {
      GetComponent<AudioSource>().Play();
    }
    else
    {
      GetComponent<AudioSource>().Stop();
    }
  }

  public void ToggleMusic()
  {
    if (isMusicOn)
    {
      isMusicOn = false;
      PlayerPrefs.SetString("MusicEnabled", "false");
    }
    else
    {
      isMusicOn = true;
      PlayerPrefs.SetString("MusicEnabled", "true");
    }

    PlayMusic();
  }
}
