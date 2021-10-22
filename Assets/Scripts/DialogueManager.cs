using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text Name;
    public Text Dialogue;
    public Animator animator;
    public GameObject PlayerUI;
    public GameObject Player;


    void Start()
    {
      sentences = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue)
    {
      Name.text = dialogue.Name;
      sentences.Clear();
      foreach(string sentence in dialogue.sentences)
      {
        sentences.Enqueue(sentence);
      }
      animator.SetBool("isOpen",true);
      DisplayNextSentence();
      PlayerUI.SetActive(false);
      Player.GetComponent<heroBehavior>().Move(0);
    }

    public void DisplayNextSentence()
    {
      if(sentences.Count == 0)
      {
        EndDialogue();
        return;
      }
      string sentence = sentences.Dequeue();
      StopAllCoroutines();
      StartCoroutine(PrintSentence(sentence));
    }

    IEnumerator PrintSentence(string sentence)
    {
      Dialogue.text = "";
      foreach (char letter in sentence.ToCharArray())
      {
        Dialogue.text += letter;
        yield return null;
      }

    }


    public void EndDialogue()
    {
        animator.SetBool("isOpen",false);
        PlayerUI.SetActive(true);
    }
}
