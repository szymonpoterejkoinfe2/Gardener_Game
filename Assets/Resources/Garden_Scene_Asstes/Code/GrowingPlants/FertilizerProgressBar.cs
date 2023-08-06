using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FertilizerProgressBar : MonoBehaviour
{
    public TextMeshProUGUI timeLeft;
    public Slider slider;
    public GameObject textToHide;

    [SerializeField] private float timeToWait;
    private bool timerStart;
   

    // Hiding Slider & text
    private void Awake()
    {
        textToHide.SetActive(false);
        gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    //Function to start Timer of fertilization
    public void StartTimer(ulong SecondsToWait)
    {
        
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        textToHide.SetActive(true);
        Debug.Log("Started Timer");
        timeToWait = (float)SecondsToWait;
        Debug.Log(timeToWait);
        slider.maxValue = timeToWait;
        slider.value = timeToWait;
        timerStart = true;
    }

    // Couting down time
    void Update()
    {
        if (timerStart)
        {
            Debug.Log("Liczê");
            float time = (timeToWait -= Time.deltaTime);
            Debug.Log(time);
            int minutes = Mathf.FloorToInt(time / 60);
            int secounds = Mathf.FloorToInt(time - minutes * 60f);

            string textTime = string.Format("{0:0}:{1:00}",minutes,secounds);

            if (time < 0)
            {
                timerStart = false;
                gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                textToHide.SetActive(false);
            }

            if (timerStart == true)
            {
                timeLeft.text = textTime;
                slider.value = time;
            }
        }
    }
}
