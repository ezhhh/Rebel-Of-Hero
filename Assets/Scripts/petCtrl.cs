using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petCtrl : MonoBehaviour
{
    public Transform target;
    public Transform pet;

    public float smoothSpeed = 0.02f;
    public Vector3 offset;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void FixedUpdate()
    {

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        if (target.position.x < pet.position.x)
        {
            transform.localScale *= 1;
        }
        else
        {
            transform.localScale *= 1;
        }


    }
}
