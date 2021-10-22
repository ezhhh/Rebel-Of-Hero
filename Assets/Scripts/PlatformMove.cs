using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    private bool moveUp = true;
    public Transform startMarker;
    public Transform endMarker;
    private float startTime;
    private float journeyLengthUp;
    private float journeyLengthDown;
    public float speed = 1f;

    void Start()
    {
        startTime = Time.time;
        journeyLengthUp = Vector3.Distance(startMarker.position, endMarker.position);
        journeyLengthDown = Vector3.Distance(endMarker.position, startMarker.position);
    }

    void Update()
    {

        if(moveUp)
        {
          transform.Translate(Vector2.up * speed * Time.deltaTime);
          if(transform.position.y >= endMarker.position.y)
            moveUp = false;
        }
        if(!moveUp)
        {
          transform.Translate(Vector2.down * speed * Time.deltaTime);
          if(transform.position.y <= startMarker.position.y)
            moveUp = true;
        }


    }
}
