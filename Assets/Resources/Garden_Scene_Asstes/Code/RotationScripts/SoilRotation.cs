using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilRotation : MonoBehaviour
{
    public Vector3 rotation, ResetPos;
    public float speed;
    private bool should_Rotate = false;
    public GameObject soil;

    // Update is called once per frame
    void Update()
    {
        if (should_Rotate)
        {
           soil.gameObject.transform.Rotate(rotation * speed * Time.deltaTime);
        }
    }

    public void ResetState()
    {
        ResetPos = new Vector3(0, 0, 0);
        soil.transform.rotation = Quaternion.Euler(ResetPos);
    }

    public void StartRotation(GameObject soilToRotate)
    {
        soil = soilToRotate;

        should_Rotate = true;
    }

    public void StartRotationKnownSoilTile()
    {
        should_Rotate = true;
    }

    public void StopRotation()
    {
        should_Rotate = false;
        ResetState();
    }
}
