using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDistributor : MonoBehaviour
{

    public void StartFarmFood(float feedTime)
    {
        FarmAnimalFood farmAnimalFood = GameObject.FindGameObjectWithTag("MovedSoil").GetComponent<FarmAnimalFood>();

        farmAnimalFood.StartFood(feedTime);
    }

    public void StartForestFood(float feedTime)
    {
        ForestAnimalFood forestAnimalFood = GameObject.FindGameObjectWithTag("MovedSoil").GetComponent<ForestAnimalFood>();

        forestAnimalFood.StartFood(feedTime);
    }

    public void StartJungleFood(float feedTime)
    {
        JungleAnimalFood jungleAnimalFood = GameObject.FindGameObjectWithTag("MovedSoil").GetComponent<JungleAnimalFood>();

        jungleAnimalFood.StartFood(feedTime);
    }

    public void StartArcticFood(float feedTime)
    {
        ArcticAnimalFood arcticAnimalFood = GameObject.FindGameObjectWithTag("MovedSoil").GetComponent<ArcticAnimalFood>();

        arcticAnimalFood.StartFood(feedTime);
    }

    public void StartSkyFood(float feedTime)
    {
        SkyAnimalFood skyAnimalFood = GameObject.FindGameObjectWithTag("MovedSoil").GetComponent<SkyAnimalFood>();

        skyAnimalFood.StartFood(feedTime);
    }
}
