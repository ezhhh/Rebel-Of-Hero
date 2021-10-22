using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;

    const float speedMove = 30.0f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Vector3 posp = transform.position;
        Vector3 pos = transform.position;
        pos.y = posp.y;
        float direction = player.transform.position.x - transform.position.x;

        if (Mathf.Abs(direction) < 20)
        {
            pos.x += Mathf.Sign(direction) * speedMove * Time.deltaTime;
            transform.position = pos;
        }
    }
}