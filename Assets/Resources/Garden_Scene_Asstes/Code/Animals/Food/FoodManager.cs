using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class FoodManager : MonoBehaviour
{

    DateTime currentDateTime;
    Dictionary<string, TileFood> allTilesFoodInfo = new Dictionary<string, TileFood>() {
        {"fa3adff6-e94d-48b3-8949-3aef8e95648d",new TileFood()},
        {"a53d2b2c-1f0e-46fd-9e27-515392a216a8", new TileFood()},
        {"03e1367b-8ff7-4a9c-850d-4e70fee54dd7", new TileFood()},
        {"87a104a1-ba4f-4bbb-aab7-0f9bd9a9d0c2", new TileFood()},
        {"075dac5f-7b59-4726-88ce-f70cdfb78fc4", new TileFood()},
        {"b55c35e5-4c9a-4b7c-bbd7-1f7fd203472c", new TileFood()},
        {"c62d4046-19c1-4b85-b58b-42c65dbcd5d6", new TileFood()},
        {"e4617f46-424d-4259-9646-1ccc639b00c9", new TileFood()},
        {"c7395c05-8ba4-460e-ae25-b996482b4d31", new TileFood()},
        {"4e91b18a-9e00-41a1-a842-b3a6cb83132f", new TileFood()},
        {"83681f27-ed86-45a3-a038-64cd0106be0a", new TileFood()},
        {"467ba58c-90bb-4e78-a350-be3524ee8fda", new TileFood()},
        {"419da0ad-013c-496c-a379-5afbd168331f", new TileFood()},
        {"cb30ca1b-b57f-46be-87e1-d0069d3c6e14", new TileFood()},
        {"6acf0408-251a-46fc-970b-61fe64140326", new TileFood()},
        {"bc0a7142-784e-4af9-9436-be411e880e72", new TileFood()},
        {"977d91d1-db8a-46f6-8cc2-6f853b8ec7bf", new TileFood()},
        {"2ceb45ca-38b9-49ab-a561-385355be2040", new TileFood()},
        {"98bfd6de-a82a-40ba-9749-1b8ceab809df", new TileFood()},
        {"442a3cc9-5c7f-4b9a-8185-358240e2731f", new TileFood()},
        {"6b209725-3687-4013-9162-f01a55879a07", new TileFood()},
        {"e011b5d2-d29c-43f9-8bf5-6f68254bb16e", new TileFood()},
        {"ea84ef5b-dec1-4f2c-b4e3-037066b98e13", new TileFood()},
        {"37b40047-ff1b-48e4-96f1-580f5f2198ee", new TileFood()},
        {"f04cfc30-94cf-4a24-8e8f-1f71a9f4b4f7", new TileFood()},
        {"663abdb0-1057-4609-ab6c-8441da7aed46", new TileFood()},
        {"7226b3c0-3883-470b-a0bb-864091b74e0f", new TileFood()},
        {"45e5044e-a636-4c28-819e-4951ec6df760", new TileFood()},
        {"e5d8cb58-1723-4b73-8e84-cfd5801d4c5c", new TileFood()},
        {"c7e4bff0-3b3d-496f-8619-4a54e2cd6674", new TileFood()},
        {"55506652-892a-436e-b545-a23cfc32a9b6", new TileFood()},
        {"3c7f39af-431b-4ab2-8ab8-de0df10ae3e1", new TileFood()},
        {"e04b9eb9-b71d-4724-947b-c6653b8ab003", new TileFood()},
        {"db5125bf-60d8-43a6-adf0-782900cd4b6e", new TileFood()},
        {"cb60cba2-7ee2-4250-9f77-7ba19f7af121", new TileFood()},
        {"f2012218-9483-4eec-b615-4b8c5debf581", new TileFood()}
    };

    bool showTimers = false;

    [SerializeField]
    TextMeshProUGUI farmFoodText, forestFoodText, jungleFoodText, arcticFoodText, skyFoodText;


    // Counting down time
    void Update()
    {

        currentDateTime = DateTime.Now;

        if (Camera.main.name == "Camera" &&  showTimers)
        {

            foreach (var tileFoodInfo in allTilesFoodInfo)
            {
                if (currentDateTime >= tileFoodInfo.Value.farmFood.foodUntil || !tileFoodInfo.Value.farmFood.haveFood)
                {
                    tileFoodInfo.Value.farmFood.SetFoodBool(false);

                }
                else
                {
                    farmFoodText.text = GetTimerText(currentDateTime, tileFoodInfo.Value.farmFood.foodUntil);
                }


                if (currentDateTime >= tileFoodInfo.Value.forestFood.foodUntil || !tileFoodInfo.Value.forestFood.haveFood)
                {
                    tileFoodInfo.Value.forestFood.SetFoodBool(false);
                }
                else
                {
                    forestFoodText.text = GetTimerText(currentDateTime, tileFoodInfo.Value.forestFood.foodUntil);
                }

                if (currentDateTime >= tileFoodInfo.Value.jungleFood.foodUntil || !tileFoodInfo.Value.jungleFood.haveFood)
                {
                    tileFoodInfo.Value.jungleFood.SetFoodBool(false);
                }
                else
                {
                    jungleFoodText.text = GetTimerText(currentDateTime, tileFoodInfo.Value.jungleFood.foodUntil);
                }

                if (currentDateTime >= tileFoodInfo.Value.arcticFood.foodUntil || !tileFoodInfo.Value.arcticFood.haveFood)
                {
                    tileFoodInfo.Value.arcticFood.SetFoodBool(false);
                }
                else
                {
                    arcticFoodText.text = GetTimerText(currentDateTime, tileFoodInfo.Value.arcticFood.foodUntil);
                }

                if (currentDateTime >= tileFoodInfo.Value.skyFood.foodUntil || !tileFoodInfo.Value.skyFood.haveFood)
                {
                    tileFoodInfo.Value.skyFood.SetFoodBool(false);
                }
                else
                {
                    skyFoodText.text = GetTimerText(currentDateTime, tileFoodInfo.Value.skyFood.foodUntil);
                }

            }

        }
        

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

    #region FoodStatusFunctions

    public bool GetFoodStatus(string tileID, environment animalEnvironment)
    {

        if (animalEnvironment == environment.Farm)
        {
            return allTilesFoodInfo[tileID].farmFood.haveFood;
        }
        else if (animalEnvironment == environment.Forest)
        {
            return allTilesFoodInfo[tileID].forestFood.haveFood;
        }
        else if (animalEnvironment == environment.Jungle)
        {
            return allTilesFoodInfo[tileID].jungleFood.haveFood;
        }
        else if (animalEnvironment == environment.Arctic)
        {
            return allTilesFoodInfo[tileID].arcticFood.haveFood;
        }
        else if (animalEnvironment == environment.Sky)
        {
            return allTilesFoodInfo[tileID].skyFood.haveFood;
        }
        return false;
    }

    #endregion

    #region ShopFunctions
    public void StartFarmFood(float minutes)
    {
        double foodTime = (double)minutes;
        string tileID = GetSoilID();

        allTilesFoodInfo[tileID].farmFood.SetFoodUntil(foodTime, 0);
        allTilesFoodInfo[tileID].farmFood.SetFoodBool(true);

        ShowTimers();
    }

    public void StartForestFood(float minutes)
    {
        double foodTime = (double)minutes;
        string tileID = GetSoilID();

        allTilesFoodInfo[tileID].forestFood.SetFoodUntil(foodTime, 0);
        allTilesFoodInfo[tileID].forestFood.SetFoodBool(true);

        ShowTimers();
    }

    public void StartJungleFood(float minutes)
    {
        double foodTime = (double)minutes;
        string tileID = GetSoilID();

        allTilesFoodInfo[tileID].jungleFood.SetFoodUntil(foodTime, 0);
        allTilesFoodInfo[tileID].jungleFood.SetFoodBool(true);

        ShowTimers();
    }

    public void StartArcticFood(float minutes)
    {
        double foodTime = (double)minutes;
        string tileID = GetSoilID();

        allTilesFoodInfo[tileID].arcticFood.SetFoodUntil(foodTime, 0);
        allTilesFoodInfo[tileID].arcticFood.SetFoodBool(true);

        ShowTimers();
    }

    public void StartSkyFood(float minutes)
    {
        double foodTime = (double)minutes;
        string tileID = GetSoilID();

        allTilesFoodInfo[tileID].skyFood.SetFoodUntil(foodTime, 0);
        allTilesFoodInfo[tileID].skyFood.SetFoodBool(true);

        ShowTimers();
    }

    private string GetSoilID()
    {
        return GameObject.FindGameObjectWithTag("MovedSoil").GetComponent<ObjectCharacteristics>().uniqueId; ;
    }
    #endregion

}
