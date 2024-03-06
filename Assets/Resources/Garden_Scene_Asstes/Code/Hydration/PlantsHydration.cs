using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsHydration : MonoBehaviour
{
    [SerializeField]
    PlantsHydrationHolder plantsHydrationHolder;

    [SerializeField]
    SoilTiles soilTiles;

    public Dictionary<string, HydrationInfo> plantsHydration;

    private void Awake()
    {
        plantsHydration = plantsHydrationHolder.ToDictionary();
    }

    public void LoadHydration(Dictionary<string, HydrationInfo> savedPlantsHydration)
    {
        plantsHydration = savedPlantsHydration;

        foreach (var plantHydration in savedPlantsHydration)
        {
            HydrationLogic hydrationLogic = soilTiles.allSoilTiles[plantHydration.Key].GetComponent<HydrationLogic>();

            if (plantHydration.Value.haveWell)
            {
                hydrationLogic.HydrationWell();
            }
            else if (plantHydration.Value.timeLeft > 0)
            {
                hydrationLogic.StartHydration(plantHydration.Value.timeLeft);
            }
        }

    }

}

[Serializable]
class PlantsHydrationHolder
{
    [SerializeField]
    HydrationElenent[] dictionaryItems;

    public Dictionary<string, HydrationInfo> ToDictionary()
    {
        Dictionary<string, HydrationInfo> newDict = new Dictionary<string, HydrationInfo>();

        foreach (var item in dictionaryItems)
        {
            newDict.Add(item.soilID, item.hydrationInfo);
        }

        return newDict;
    }
}


[Serializable]
public class HydrationElenent
{
    [SerializeField]
    public string soilID;
    public HydrationInfo hydrationInfo;
}

[Serializable]
public class HydrationInfo
{
    public bool haveWell = false;
    public ulong timeLeft = 0;

}