using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float flightSpeed;

    void Update()
    {
      transform.Translate(Vector2.up * flightSpeed * Time.deltaTime);

    }


    void OnCollisionStay2D(Collision2D col)
    {
      Destroy(gameObject);
    }
}
