using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileFertilizer
{
    public FertilizerInfo incomeMultipyFertilizer = new FertilizerInfo();

}

public class FertilizerInfo
{

    public bool haveFertilizer;
    public DateTime fertilizerUntil = DateTime.Now;


    public void SetFertilizerBool(bool hFood)
    {
        haveFertilizer = hFood;
    }

    public void SetFertilizerUntil(double minutes, double seconds)
    {
        DateTime toAdd = DateTime.Now;
        fertilizerUntil = toAdd.AddMinutes(minutes).AddSeconds(seconds);
    }

}