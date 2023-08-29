using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrationSliderStatus : MonoBehaviour
{
    private void Awake()
    {
        gameObject.transform.localScale = new Vector3(0,0,0);
    }

    public void ShowSlider()
    {

        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    public void HideSlider()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
}
