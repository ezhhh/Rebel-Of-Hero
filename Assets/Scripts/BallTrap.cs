using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrap : MonoBehaviour
{
    public GameObject Ball;
    public int forcePowr;
    public Vector2 direction;
    Rigidbody2D rb;

    void Start()
    {
      rb = Ball.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.tag == "Player")
      {
        rb.AddForce(direction * forcePowr,ForceMode2D.Impulse);
        gameObject.SetActive(false);
      }

    }

}
