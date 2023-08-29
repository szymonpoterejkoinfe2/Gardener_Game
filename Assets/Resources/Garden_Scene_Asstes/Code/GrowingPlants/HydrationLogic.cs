using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HydrationLogic : MonoBehaviour
{
    public bool hydrated;
    private Slider slider;
    [SerializeField] private float hydratedTime;
    private bool timerStart;

    //Function to start Timer of fertilization
    public void StartHydration(ulong SecondsToWait)
    {
        slider = GameObject.FindGameObjectWithTag("Hydration").GetComponent<Slider>();
        hydratedTime = (float)SecondsToWait;
        slider.maxValue = hydratedTime;
        slider.value = hydratedTime;
        timerStart = true;
        hydrated = true;
    }

    // Couting down time
    void Update()
    {
        if (timerStart)
        {

            float time = (hydratedTime -= Time.deltaTime);


            if (time < 0)
            {
                slider = GameObject.FindGameObjectWithTag("Hydration").GetComponent<Slider>();
                slider.value = time;
                timerStart = false;
                hydrated = false;
            }

            if (timerStart == true && gameObject.tag == "MovedSoil")
            {
                slider = GameObject.FindGameObjectWithTag("Hydration").GetComponent<Slider>();
                slider.value = time;
            }
        }
    }

}
