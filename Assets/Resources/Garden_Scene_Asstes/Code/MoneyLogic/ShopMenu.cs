using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;

public class ShopMenu : MonoBehaviour
{
    private GameObject soilTile, plant, bank;
    private Dictionary<string, GameObject> allPlants;
    private BigInteger balance;
    private ulong time, multi;
    private SaveSystem saveManager;
    [SerializeField]
    private ManagerHolder managerHolder;

    public GameObject PlantCategory, MenagerCategory, AnimalsCategory,GardenDecorationCategory,ToolCategory, managerUI;
    public TextMeshProUGUI[] BuyPlantPriceTxt;
    public TextMeshProUGUI[] UpgradePlantPriceTxt;
    public TextMeshProUGUI[] BuyManagerPriceTxt, UpgradeManagerPriceTxt;
    public TextMeshProUGUI[] BuyObjectPriceTxt;
    public TextMeshProUGUI[] buyPlantPricePrefix;
    public TextMeshProUGUI[] upgradePlantPricePrefix;
    public TextMeshProUGUI[] buyManagerPricePrefix;
    public TextMeshProUGUI[] upgradeManagerPricePrefix;

    private void Awake()
    {
        PlantCategory.SetActive(true);
        MenagerCategory.SetActive(false);
        GardenDecorationCategory.SetActive(false);
        AnimalsCategory.SetActive(false);
        ToolCategory.SetActive(false);
        saveManager = GameObject.FindObjectOfType<SaveSystem>();
    }


    //Activating Menager Shop Menu
    public void MenagerCategoryActivate()
    {
        PlantCategory.SetActive(false);
        MenagerCategory.SetActive(true);
        GardenDecorationCategory.SetActive(false);
        AnimalsCategory.SetActive(false);
        ToolCategory.SetActive(false);
        GardenDecorationCategory.SetActive(false);
    }

    //Activating GardenDecoration Shop Menu
    public void GardenDecorationCategoryActivate()
    {
        PlantCategory.SetActive(false);
        MenagerCategory.SetActive(false);
        GardenDecorationCategory.SetActive(true);
        AnimalsCategory.SetActive(false);
        ToolCategory.SetActive(false);
    }

    //Activating Plant Shop Menu
    public void PlantCategoryActivate()
    {
        PlantCategory.SetActive(true);
        MenagerCategory.SetActive(false);
        GardenDecorationCategory.SetActive(false);
        AnimalsCategory.SetActive(false);
        ToolCategory.SetActive(false);
    }

    //Activating Animals Shop Menu
    public void AnimalsCategoryActivate()
    {
        PlantCategory.SetActive(false);
        MenagerCategory.SetActive(false);
        GardenDecorationCategory.SetActive(false);
        AnimalsCategory.SetActive(true);
        ToolCategory.SetActive(false);
    }

    //Activating Tool Shop Menu
    public void ToolCategoryActivate()
    {
        PlantCategory.SetActive(false);
        MenagerCategory.SetActive(false);
        GardenDecorationCategory.SetActive(false);
        AnimalsCategory.SetActive(false);
        ToolCategory.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        soilTile = GameObject.FindGameObjectWithTag("MovedSoil");
        allPlants = FindObjectOfType<PlantsHolder>().allPlants;

        bank = GameObject.FindGameObjectWithTag("Bank");
        balance = bank.GetComponent<MoneyManager>().myBalance.moneyBalance;

        if (soilTile.GetComponent<SoilTileInformation>().havePlant == true)
        {
            plant = soilTile.transform.Find("Plant").gameObject;
        }

            // Taking Price Of Prefab Objects
            foreach(var plant in allPlants)
            {
                bank.GetComponent<MoneyManager>().DisplayMoneyValue(bank.GetComponent<PricingSystemPlants>().plantPrices.GetObjPrice(allPlants[plant.Key].GetComponent<ObjectCharacteristics>().myId), BuyPlantPriceTxt[0], buyPlantPricePrefix[0]);
                bank.GetComponent<MoneyManager>().DisplayMoneyValue(bank.GetComponent<PricingSystemPlants>().plantPrices.GetObjUpgradeCost(allPlants[plant.Key].GetComponent<ObjectCharacteristics>().myId), UpgradePlantPriceTxt[0], upgradePlantPricePrefix[0]);
                bank.GetComponent<MoneyManager>().DisplayMoneyValue(bank.GetComponent<PricingSystemPlants>().plantPrices.GetObjMenagerCost(allPlants[plant.Key].GetComponent<ObjectCharacteristics>().myId), BuyManagerPriceTxt[0], buyManagerPricePrefix[0]);
                bank.GetComponent<MoneyManager>().DisplayMoneyValue(bank.GetComponent<PricingSystemPlants>().plantPrices.GetObjMenagerUpgradeCost(allPlants[plant.Key].GetComponent<ObjectCharacteristics>().myId), UpgradeManagerPriceTxt[0], upgradeManagerPricePrefix[0]);
               
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
        if (soilTile.GetComponent<SoilTileInformation>().havePlant == true)
        {

            plant.GetComponent<Fertilizer>().Fertilise(time,multi);

        }
    }



    //Buying Plant Growing Manager 
    public void GrowWithPlantManager(float time)
    {

        if (soilTile.GetComponent<SoilTileInformation>().havePlant == true &&  bank.GetComponent<PricingSystemPlants>().plantPrices.GetObjMenagerCost(plant.GetComponent<ObjectCharacteristics>().myId) <= balance && plant.GetComponent<ManagerLogic>().haveManager == false)
        {

           bank.GetComponent<MoneyManager>().myBalance.DecrementBalance(bank.GetComponent<PricingSystemPlants>().plantPrices.GetObjMenagerCost(plant.GetComponent<ObjectCharacteristics>().myId));
           plant.GetComponent<ManagerLogic>().StartGrowing(time);

            managerHolder.allManagers[soilTile.GetComponent<ObjectCharacteristics>().uniqueId].haveManager = true;
            managerHolder.allManagers[soilTile.GetComponent<ObjectCharacteristics>().uniqueId].managerLevel = 1;
            managerHolder.allManagers[soilTile.GetComponent<ObjectCharacteristics>().uniqueId].managerTime = time;

            managerUI.SetActive(true);

            saveManager.SaveManagers();

            saveManager.SavePlantPricing();
            saveManager.SaveMoneyBalance();
        }

    }

    //Buying Upgrade Plant Growing  Manager
    public void UpgradeGrowWithPlantManager()
    {
        if(soilTile.GetComponent<SoilTileInformation>().havePlant == true && bank.GetComponent<PricingSystemPlants>().plantPrices.GetObjMenagerUpgradeCost(plant.GetComponent<ObjectCharacteristics>().myId) <= balance && plant.GetComponent<ManagerLogic>().haveManager == true)
        {
            managerHolder.allManagers[soilTile.GetComponent<ObjectCharacteristics>().uniqueId].managerLevel++;

            bank.GetComponent<MoneyManager>().myBalance.DecrementBalance(bank.GetComponent<PricingSystemPlants>().plantPrices.GetObjMenagerUpgradeCost(plant.GetComponent<ObjectCharacteristics>().myId));
            bank.GetComponent<PricingSystemPlants>().plantPrices.UpdateManagerCost(plant.GetComponent<ObjectCharacteristics>().myId);
            plant.GetComponent<ManagerLogic>().UpgradeManager();

            managerHolder.allManagers[soilTile.GetComponent<ObjectCharacteristics>().uniqueId].managerTime = plant.GetComponent<ManagerLogic>().growTime;

            saveManager.SavePlantPricing();
            saveManager.SaveManagers();
        }
        
    }


}
