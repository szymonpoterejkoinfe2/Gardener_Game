using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    public float ZoomMin = 19;
    public float ZoomMax = 50;
    public float Speed = 1;
    public bool canMoveCamera;
    public Vector3 rangeMin;
    public Vector3 rangeMax;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2 && canMoveCamera)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroprev = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOneoprev = touchOne.position - touchOne.deltaPosition;

            float prevMag = (touchZeroprev - touchOneoprev).magnitude;
            float currentMag = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMag - prevMag;

            zoom(difference * 0.1f);
        }
        if (Input.touchCount > 0 && Input.touchCount < 2 && Input.GetTouch(0).phase == TouchPhase.Moved && canMoveCamera)
        {
            Vector2 Touch_pos = Input.GetTouch(0).deltaPosition;

            transform.Translate(-Touch_pos.x * Speed, -Touch_pos.y * Speed, 0);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, rangeMin.x, rangeMax.x), Mathf.Clamp(transform.position.y, rangeMin.y, rangeMax.y), Mathf.Clamp(transform.position.z, rangeMin.z, rangeMax.z));

        }

    }


    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, ZoomMin,ZoomMax);
    }

    public void cameraMovement()
    {

        if (canMoveCamera == true)
        {
            canMoveCamera = false;
        }
        else {
            canMoveCamera = true;
        }
       
    }
}
