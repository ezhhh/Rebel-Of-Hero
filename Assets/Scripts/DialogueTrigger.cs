using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
      FindObjectOfType<DialogueManager>().startDialogue(dialogue);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.tag == "Player")
      {
        TriggerDialogue();
        gameObject.SetActive(false);
      }
    }
}
