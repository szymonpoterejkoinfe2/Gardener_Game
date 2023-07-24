using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilizer : MonoBehaviour
{
    public ulong Multiplicator = 1;

    public void Fertilise(ulong SecondsToWait, ulong multiplicator)
    {

        Multiplicator = multiplicator;
        StartCoroutine(Fertilizing(SecondsToWait));

    }


    IEnumerator Fertilizing(ulong SecondsToWait) 
    {
        yield return new WaitForSeconds(SecondsToWait);
        Multiplicator = 1;
    }

}
