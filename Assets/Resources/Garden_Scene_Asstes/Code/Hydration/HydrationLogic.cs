using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HydrationLogic : MonoBehaviour
{
    public bool hydrated, haveWell = false;
    [SerializeField] private float hydratedTime;
    private bool timerStart;
    public ulong timeLeft = 0;
    Dictionary<string, HydrationInfo> plantsHydration;

    //Function to start Timer of fertilization
    public void StartHydration(ulong SecondsToWait)
    {
        hydratedTime = SecondsToWait;
        timerStart = true;
        hydrated = true;
    }

    public void HydrationWell()
    {
        hydrated = true;
        haveWell = true;
    }

    // Couting down time
    void Update()
    {
        TextMeshProUGUI timeLeftText;
        plantsHydration = FindObjectOfType<PlantsHydration>().plantsHydration;

        if (timerStart && !haveWell)
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

                plantsHydration[GetComponent<ObjectCharacteristics>().uniqueId].timeLeft = timeLeft;
            }

            if (time < 0)
            {
                timerStart = false;
                hydrated = false;
                timeLeft = 0;
                plantsHydration[GetComponent<ObjectCharacteristics>().uniqueId].timeLeft = timeLeft;
            }

        }
        else if (haveWell)
        {  
            if (gameObject.tag == "MovedSoil")
            {
                timeLeftText = GameObject.FindGameObjectWithTag("HydrationText").GetComponent<TextMeshProUGUI>();
                string textTime = "\u221E";
                timeLeftText.text = textTime;
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
