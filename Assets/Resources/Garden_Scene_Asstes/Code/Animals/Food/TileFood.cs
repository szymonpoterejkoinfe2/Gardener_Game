using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileFood : MonoBehaviour
{
    public FoodInfo farmFood = new FoodInfo();
    public FoodInfo forestFood = new FoodInfo();
    public FoodInfo jungleFood = new FoodInfo();
    public FoodInfo arcticFood = new FoodInfo();
    public FoodInfo skyFood = new FoodInfo();
}


public class FoodInfo
{
    public bool haveFood = false;
    public DateTime foodUntil = DateTime.Now;

    public void SetFoodBool(bool hFood)
    {
        haveFood = hFood;
    }

    public void SetFoodUntil(double minutes, double seconds)
    {
        DateTime toAdd = DateTime.Now;
        foodUntil = toAdd.AddMinutes(minutes).AddSeconds(seconds);
    }
}