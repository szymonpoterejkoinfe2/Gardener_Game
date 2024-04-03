using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class FertilizerManager : MonoBehaviour
{
    DateTime currentDateTime;

    Dictionary<string, TileFertilizer> allTilesFertilizerInfo = new Dictionary<string, TileFertilizer>() {
        {"fa3adff6-e94d-48b3-8949-3aef8e95648d",new TileFertilizer()},
        {"a53d2b2c-1f0e-46fd-9e27-515392a216a8", new TileFertilizer()},
        {"03e1367b-8ff7-4a9c-850d-4e70fee54dd7", new TileFertilizer()},
        {"87a104a1-ba4f-4bbb-aab7-0f9bd9a9d0c2", new TileFertilizer()},
        {"075dac5f-7b59-4726-88ce-f70cdfb78fc4", new TileFertilizer()},
        {"b55c35e5-4c9a-4b7c-bbd7-1f7fd203472c", new TileFertilizer()},
        {"c62d4046-19c1-4b85-b58b-42c65dbcd5d6", new TileFertilizer()},
        {"e4617f46-424d-4259-9646-1ccc639b00c9", new TileFertilizer()},
        {"c7395c05-8ba4-460e-ae25-b996482b4d31", new TileFertilizer()},
        {"4e91b18a-9e00-41a1-a842-b3a6cb83132f", new TileFertilizer()},
        {"83681f27-ed86-45a3-a038-64cd0106be0a", new TileFertilizer()},
        {"467ba58c-90bb-4e78-a350-be3524ee8fda", new TileFertilizer()},
        {"419da0ad-013c-496c-a379-5afbd168331f", new TileFertilizer()},
        {"cb30ca1b-b57f-46be-87e1-d0069d3c6e14", new TileFertilizer()},
        {"6acf0408-251a-46fc-970b-61fe64140326", new TileFertilizer()},
        {"bc0a7142-784e-4af9-9436-be411e880e72", new TileFertilizer()},
        {"977d91d1-db8a-46f6-8cc2-6f853b8ec7bf", new TileFertilizer()},
        {"2ceb45ca-38b9-49ab-a561-385355be2040", new TileFertilizer()},
        {"98bfd6de-a82a-40ba-9749-1b8ceab809df", new TileFertilizer()},
        {"442a3cc9-5c7f-4b9a-8185-358240e2731f", new TileFertilizer()},
        {"6b209725-3687-4013-9162-f01a55879a07", new TileFertilizer()},
        {"e011b5d2-d29c-43f9-8bf5-6f68254bb16e", new TileFertilizer()},
        {"ea84ef5b-dec1-4f2c-b4e3-037066b98e13", new TileFertilizer()},
        {"37b40047-ff1b-48e4-96f1-580f5f2198ee", new TileFertilizer()},
        {"f04cfc30-94cf-4a24-8e8f-1f71a9f4b4f7", new TileFertilizer()},
        {"663abdb0-1057-4609-ab6c-8441da7aed46", new TileFertilizer()},
        {"7226b3c0-3883-470b-a0bb-864091b74e0f", new TileFertilizer()},
        {"45e5044e-a636-4c28-819e-4951ec6df760", new TileFertilizer()},
        {"e5d8cb58-1723-4b73-8e84-cfd5801d4c5c", new TileFertilizer()},
        {"c7e4bff0-3b3d-496f-8619-4a54e2cd6674", new TileFertilizer()},
        {"55506652-892a-436e-b545-a23cfc32a9b6", new TileFertilizer()},
        {"3c7f39af-431b-4ab2-8ab8-de0df10ae3e1", new TileFertilizer()},
        {"e04b9eb9-b71d-4724-947b-c6653b8ab003", new TileFertilizer()},
        {"db5125bf-60d8-43a6-adf0-782900cd4b6e", new TileFertilizer()},
        {"cb60cba2-7ee2-4250-9f77-7ba19f7af121", new TileFertilizer()},
        {"f2012218-9483-4eec-b615-4b8c5debf581", new TileFertilizer()}
    };

    bool showTimers = false;

    [SerializeField]
    TextMeshProUGUI multiplyFertilizerText;


    private void Update()
    {
        
    }


    #region TimerFunctions

    private string GetTimerText(DateTime currentTime, DateTime foodEndTime)
    {
        TimeSpan foodTimeSpan = foodEndTime - currentDateTime;
        int minutes = foodTimeSpan.Minutes;
        int seconds = foodTimeSpan.Seconds;

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ShowTimers()
    {
        showTimers = true;
    }

    public void HideTimers()
    {
        showTimers = false;
    }

    #endregion


    #region ShopFunctions

    public void StartIncomeMultiplyFertilizer(float minutes)
    {
        double foodTime = minutes;
        string tileID = GetSoilID();

        allTilesFertilizerInfo[tileID].incomeMultipyFertilizer.SetFertilizerUntil(foodTime, 0);
        allTilesFertilizerInfo[tileID].incomeMultipyFertilizer.SetFertilizerBool(true);
    }


    private string GetSoilID()
    {
        return GameObject.FindGameObjectWithTag("MovedSoil").GetComponent<ObjectCharacteristics>().uniqueId; ;
    }

    #endregion
}


