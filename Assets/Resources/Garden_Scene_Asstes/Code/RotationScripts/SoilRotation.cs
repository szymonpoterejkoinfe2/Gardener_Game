using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilRotation : MonoBehaviour
{
    public Vector3 rotation, ResetPos;
    public float speed;
    public bool Should_Rotate = false;

    // Update is called once per frame
    void Update()
    {
        if (Should_Rotate)
        {
            transform.Rotate(rotation * speed * Time.deltaTime);
        }
    }

    public void ResetState()
    {
        ResetPos = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(ResetPos);
    }
}
