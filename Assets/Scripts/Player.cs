using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float moveSpeed = 4f;
    public Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
      if(Input.GetAxis("Horizontal") > 0)
      {
        transform.localScale = new Vector3(0.35f,transform.localScale.y,transform.localScale.z);
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
      }

      else if(Input.GetAxis("Horizontal") < 0)
      {
        transform.localScale = new Vector3(-0.35f,transform.localScale.y,transform.localScale.z);
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
      }

      if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        rb.AddForce(new Vector2(0f,20f));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.tag == "trap")
        SceneManager.LoadScene(0);

    }

}
