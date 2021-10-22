using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    public GameObject Base;
    private bool left = true;
    public float rotationSpeed;

    void Update()
    {
      if(left)
      {
        transform.RotateAround(Base.transform.position,new Vector3(0,0,gameObject.transform.position.z),rotationSpeed * Time.deltaTime);
        if(transform.localRotation.z > 45f)
          left = !left;
      }
      if(!left)
      {
        transform.RotateAround(Base.transform.position,new Vector3(0,0,gameObject.transform.position.z),-rotationSpeed * Time.deltaTime);
        if(transform.localRotation.z < -45)
          left = !left;
      }

    }
}
