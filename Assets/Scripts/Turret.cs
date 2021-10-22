using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject Arrow;
    private GameObject instArrow;
    public float spawnRate = 3f;
    public bool left;
    public bool right;
    public bool down;
    public float spawnOffset = 0.5f;
    public float flightSpeed;

    void Start()
    {
      StartCoroutine(SpawnArr());
    }

    IEnumerator SpawnArr()
    {
      while(true)
      {

        if(left)
          instArrow = Instantiate(Arrow,(Vector2)gameObject.transform.position + new Vector2(-spawnOffset,0),Quaternion.Euler(0,0,90));

        if(right)
          instArrow = Instantiate(Arrow,(Vector2)gameObject.transform.position + new Vector2(spawnOffset,0),Quaternion.Euler(0,0,-90));

        if(down)
          instArrow = Instantiate(Arrow,(Vector2)gameObject.transform.position + new Vector2(0,-spawnOffset),Quaternion.Euler(0,0,180));

        instArrow.GetComponent<Arrow>().flightSpeed = flightSpeed;

        yield return new WaitForSeconds (spawnRate);

      }

    }

}
