using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public GameObject Player;
    public void LevelOpener(int level)
    {
        SceneManager.LoadScene(level);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
      PlayerPrefs.DeleteKey("spawnX");
      PlayerPrefs.SetInt("coins",Player.GetComponent<heroBehavior>().GetCoins());
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }

}
