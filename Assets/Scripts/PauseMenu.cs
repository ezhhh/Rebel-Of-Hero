using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Pause()
    {
      Time.timeScale = 0;
    }

    public void Menu()
    {
      SceneManager.LoadScene(0);
      Time.timeScale = 1;
    }

    public void Back()
    {
      Time.timeScale = 1;
    }
}
