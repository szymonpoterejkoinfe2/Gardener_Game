using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilizer : MonoBehaviour
{
    public ulong Multiplicator = 1;
    private GameObject timerSlider;

    // Starting work of fertilizer 
    public void Fertilise(ulong SecondsToWait, ulong multiplicator)
    {
        timerSlider = GameObject.FindGameObjectWithTag("Fertilizer");

        Multiplicator = multiplicator;

        timerSlider.GetComponent<FertilizerProgressBar>().StartTimer(SecondsToWait);

        StartCoroutine(Fertilizing(SecondsToWait));

    }

    // Fertilization courutine
    IEnumerator Fertilizing(ulong SecondsToWait) 
    {
        yield return new WaitForSeconds(SecondsToWait);
        Multiplicator = 1;
    }

}
