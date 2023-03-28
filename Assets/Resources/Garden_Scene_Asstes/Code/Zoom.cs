using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    public float ZoomMin = 20;
    public float ZoomMax = 50;
    public float Speed = 1;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
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
        if (Input.touchCount > 0 && Input.touchCount < 2 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 Touch_pos = Input.GetTouch(0).deltaPosition;

            transform.Translate(-Touch_pos.x * Speed, -Touch_pos.y * Speed, 0);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -15f, 20f), Mathf.Clamp(transform.position.y, 20f, 80f), Mathf.Clamp(transform.position.z, -70f, -70f));

        }

    }


    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, ZoomMin,ZoomMax);
    }
}
