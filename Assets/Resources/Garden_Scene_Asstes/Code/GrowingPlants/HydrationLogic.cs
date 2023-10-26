using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HydrationLogic : MonoBehaviour
{
    public bool hydrated;
    //private Slider slider;
    [SerializeField] private float hydratedTime;
    private bool timerStart;
    public ulong timeLeft = 0;


    //Function to start Timer of fertilization
    public void StartHydration(ulong SecondsToWait)
    {
        //slider = GameObject.FindGameObjectWithTag("Hydration").GetComponent<Slider>();
        hydratedTime = (float)SecondsToWait;
        //slider.maxValue = hydratedTime;
        //slider.value = hydratedTime;
        timerStart = true;
        hydrated = true;
    }

    // Couting down time
    void Update()
    {
        TextMeshProUGUI timeLeftText;

        if (timerStart)
        {

            float time = (hydratedTime -= Time.deltaTime);
            timeLeft = (ulong)time;

            if (gameObject.tag == "MovedSoil")
            {
                timeLeftText = GameObject.FindGameObjectWithTag("HydrationText").GetComponent<TextMeshProUGUI>();
                int minutes = Mathf.FloorToInt(time / 60);
                int secounds = Mathf.FloorToInt(time - minutes * 60f);

                string textTime = string.Format("{0:0}:{1:00}", minutes, secounds);
                timeLeftText.text = textTime;
            }

            if (time < 0)
            {
                //slider = GameObject.FindGameObjectWithTag("Hydration").GetComponent<Slider>();
                //slider.value = time;
                timerStart = false;
                hydrated = false;
                timeLeft = 0;

            }



        }
        else {

            if (gameObject.tag == "MovedSoil")
            {
                timeLeftText = GameObject.FindGameObjectWithTag("HydrationText").GetComponent<TextMeshProUGUI>();
                string textTime = string.Format("{0:0}:{1:00}", 0, 0);
                timeLeftText.text = textTime;
            }
        }
    
        
    }

}
