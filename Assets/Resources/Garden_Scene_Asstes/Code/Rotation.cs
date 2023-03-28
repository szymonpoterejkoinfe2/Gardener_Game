using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector3 rotation, ResetPos;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }

    public void ResetState()
    {
        ResetPos = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(ResetPos);
      
   
    }
}



