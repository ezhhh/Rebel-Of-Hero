using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

  public void Play()
  {
    if(PlayerPrefs.HasKey("lastLvl"))
      SceneManager.LoadScene(PlayerPrefs.GetInt("lastLvl"));
    else SceneManager.LoadScene(1);
    PlayerPrefs.DeleteKey("spawnX");

  }



  public void Exit()
  {
    Application.Quit();
  }

}
