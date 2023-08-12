using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;

public class ShopMenu : MonoBehaviour
{
    private GameObject soilTile, plant, bank;
    private GameObject[] allPlants;
    private BigInteger balance;
    private ulong time, multi;

    public GameObject PlantCategory, MenagerCategory, OtherUpgradesCategory;
    public TextMeshProUGUI[] BuyPlantPriceTxt;
    public TextMeshProUGUI[] UpgradePlantPriceTxt;
    public TextMeshProUGUI[] BuyManagerPriceTxt, UpgradeManagerPriceTxt;


    private void Awake()
    {
        PlantCategory.SetActive(true);
        MenagerCategory.SetActive(false);
        OtherUpgradesCategory.SetActive(false);
    }

    //Activating Menager Shop Menu
    public void MenagerCategoryActivate()
    {
        PlantCategory.SetActive(false);
        MenagerCategory.SetActive(true);
        OtherUpgradesCategory.SetActive(false);
    }

    //Activating OtherUpgrades Shop Menu
    public void OtherUpgradesCategoryActivate()
    {
        OtherUpgradesCategory.SetActive(true);
        MenagerCategory.SetActive(false);
        PlantCategory.SetActive(false);
    }

    //Activating Plant Shop Menu
    public void PlantCategoryActivate()
    {
        PlantCategory.SetActive(true);
        MenagerCategory.SetActive(false);
        OtherUpgradesCategory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        soilTile = GameObject.FindGameObjectWithTag("MovedSoil");
        allPlants = soilTile.GetComponent<PlantCreator>().plants;

        bank = GameObject.FindGameObjectWithTag("Bank");
        balance = bank.GetComponent<MoneyManager>().moneyBalance; 

        // Taking Price of Planted Object
        if (soilTile.GetComponent<PlantCreator>().havePlant == true)
        {
            plant = soilTile.transform.Find("Plant").gameObject;

            bank.GetComponent<MoneyManager>().DisplayMoneyValue(bank.GetComponent<PricingSystemPlants>().objectUpgradeCost[plant.GetComponent<ObjectCharacteristics>().myId], UpgradePlantPriceTxt[plant.GetComponent<ObjectCharacteristics>().myId]);
            bank.GetComponent<MoneyManager>().DisplayMoneyValue(bank.GetComponent<PricingSystemPlants>().objectMenagerUpgradeCost[plant.GetComponent<ObjectCharacteristics>().myId], UpgradeManagerPriceTxt[plant.GetComponent<ObjectCharacteristics>().myId]);

           //UpgradePlantPriceTxt[plant.GetComponent<ObjectCharacteristics>().myId].text = bank.GetComponent<PricingSystemPlants>().objectUpgradeCost[plant.GetComponent<ObjectCharacteristics>().myId].ToString();
           //UpgradeManagerPriceTxt[plant.GetComponent<ObjectCharacteristics>().myId].text = bank.GetComponent<PricingSystemPlants>().objectMenagerUpgradeCost[plant.GetComponent<ObjectCharacteristics>().myId].ToString();
        }
        else
        {
            // Taking Price Of Prefab Objects
            for (int PlantId = 0; PlantId < allPlants.Length; PlantId++)
            {
                bank.GetComponent<MoneyManager>().DisplayMoneyValue(bank.GetComponent<PricingSystemPlants>().objectPrice[allPlants[PlantId].GetComponent<ObjectCharacteristics>().myId], BuyPlantPriceTxt[PlantId]);
                bank.GetComponent<MoneyManager>().DisplayMoneyValue(bank.GetComponent<PricingSystemPlants>().objectUpgradeCost[allPlants[PlantId].GetComponent<ObjectCharacteristics>().myId], UpgradePlantPriceTxt[PlantId]);
                bank.GetComponent<MoneyManager>().DisplayMoneyValue(bank.GetComponent<PricingSystemPlants>().objectMenagerCost[allPlants[PlantId].GetComponent<ObjectCharacteristics>().myId], BuyManagerPriceTxt[PlantId]);
                bank.GetComponent<MoneyManager>().DisplayMoneyValue(bank.GetComponent<PricingSystemPlants>().objectMenagerUpgradeCost[allPlants[PlantId].GetComponent<ObjectCharacteristics>().myId], UpgradeManagerPriceTxt[PlantId]);
                
            }
        }

    }

    // Function To set time of fertilizer
    public void SetTime(int fertilizerTime)
    {
        time = (ulong)fertilizerTime;
    }

    // Function to set multiplication for fertilizer
    public void SetMultiplicator(int fertilizerMulti)
    {
        multi = (ulong)fertilizerMulti;
    }

    // Function to buy Fertilizer To increase profit
    public void BuyFertilizer()
    {
        if (soilTile.GetComponent<PlantCreator>().havePlant == true)
        {

            plant.GetComponent<Fertilizer>().Fertilise(time,multi);

        }
    }



    //Buying Plant Growing Manager 
    public void GrowWithPlantManager()
    {

        if (soilTile.GetComponent<PlantCreator>().havePlant == true &&  bank.GetComponent<PricingSystemPlants>().objectMenagerCost[plant.GetComponent<ObjectCharacteristics>().myId] <= balance && plant.GetComponent<ManagerLogic>().haveManager == false)
        {
           bank.GetComponent<MoneyManager>().DecrementBalance(bank.GetComponent<PricingSystemPlants>().objectMenagerCost[plant.GetComponent<ObjectCharacteristics>().myId]);
           plant.GetComponent<ManagerLogic>().StartGrowing();
        }

    }

    //Buying Upgrade Plant Growing  Manager
    public void UpgradeGrowWithPlantManager()
    {
        if(soilTile.GetComponent<PlantCreator>().havePlant == true && bank.GetComponent<PricingSystemPlants>().objectMenagerUpgradeCost[plant.GetComponent<ObjectCharacteristics>().myId] <= balance && plant.GetComponent<ManagerLogic>().haveManager == true)
        {
            bank.GetComponent<MoneyManager>().DecrementBalance(bank.GetComponent<PricingSystemPlants>().objectMenagerUpgradeCost[plant.GetComponent<ObjectCharacteristics>().myId]);
            bank.GetComponent<PricingSystemPlants>().UpdateManagerCost(plant.GetComponent<ObjectCharacteristics>().myId);
            plant.GetComponent<ManagerLogic>().UpgradeManager();
        }
        
    }


}
