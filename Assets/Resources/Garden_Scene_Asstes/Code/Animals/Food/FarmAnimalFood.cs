using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAnimalFood : MonoBehaviour
{

    public bool haveFood;
    [SerializeField] private float foodTime;
    private bool timerStart;
    public ulong timeLeft = 0;


    //Function to start Timer of fertilization
    public void StartFood(ulong SecondsToWait)
    {
        foodTime = SecondsToWait;
        timerStart = true;
        haveFood = true;
    }

    // Couting down time
    void Update()
    {

        if (timerStart)
        {
            float time = (foodTime -= Time.deltaTime);
            timeLeft = (ulong)time;

            if (gameObject.tag == "MovedSoil")
            {
                int minutes = Mathf.FloorToInt(time / 60);
                int secounds = Mathf.FloorToInt(time - minutes * 60f);

                string textTime = string.Format("{0:0}:{1:00}", minutes, secounds);
            }

            if (time < 0)
            {
                timerStart = false;
                haveFood = false;
                timeLeft = 0;
            }

        }

    }

}
