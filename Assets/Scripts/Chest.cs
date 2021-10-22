using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public int coinsCount;
    public GameObject interact;
    private GameObject Player;
    private bool canBeOpened;


    void Update()
    {
      if(canBeOpened)
        if(Input.GetKeyDown(KeyCode.E))
          Open();
    }

    public void Open()
    {
      Player.GetComponent<heroBehavior>().ChangeBalance(coinsCount);
      GetComponent<Chest>().enabled = false;
      Destroy(interact.gameObject);
    }



    void OnTriggerEnter2D(Collider2D col)
    {
      if (col.gameObject.tag == "Player")
      {
        interact.SetActive(true);
        Player = col.gameObject;
        canBeOpened = true;

      }

    }

    void OnTriggerExit2D(Collider2D col)
    {
      if (col.gameObject.tag == "Player")
      {
        interact.SetActive(false);
        canBeOpened = false;
      }
    }

    void OnMouseClick()
    {
      if(canBeOpened)
        Open();
    }
}
