using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    private GameObject SoilTile, Plant, Bank;
    private GameObject[] AllPlants;
    private ulong Ballance;
    private ulong Time, Multi;

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
        SoilTile = GameObject.FindGameObjectWithTag("MovedSoil");
        AllPlants = SoilTile.GetComponent<PlantCreator>().plants;

        Bank = GameObject.FindGameObjectWithTag("Bank");
        Ballance = Bank.GetComponent<MoneyManager>().MoneyBallance;

        // Taking Price from Planted Object
        if (SoilTile.GetComponent<PlantCreator>().HavePlant == true)
        {
            Plant = SoilTile.transform.Find("Plant").gameObject;

           UpgradePlantPriceTxt[Plant.GetComponent<ObjectPrice>().MyId].text = Plant.GetComponent<ObjectPrice>().UpgradeCost.ToString();
           UpgradeManagerPriceTxt[Plant.GetComponent<ObjectPrice>().MyId].text = Plant.GetComponent<ObjectPrice>().ManagerUpgradeCost.ToString();
        }
        else
        {
            // Taking Price From Prefab Objects
            for (int PlantId = 0; PlantId < AllPlants.Length; PlantId++)
            {
                BuyPlantPriceTxt[PlantId].text = AllPlants[PlantId].GetComponent<ObjectPrice>().MyPrice.ToString();
                UpgradePlantPriceTxt[PlantId].text = AllPlants[PlantId].GetComponent<ObjectPrice>().UpgradeCost.ToString();
                BuyManagerPriceTxt[PlantId].text = AllPlants[PlantId].GetComponent<ObjectPrice>().MyManagerCost.ToString();
                UpgradeManagerPriceTxt[PlantId].text = AllPlants[PlantId].GetComponent<ObjectPrice>().ManagerUpgradeCost.ToString();
            }
        }

    }

    // Function To set time of fertilizer
    public void SetTime(int time)
    {
        Time = (ulong)time;
    }

    // Function to set multiplication for fertilizer
    public void SetMultiplicator(int multi)
    {
        Multi = (ulong)multi;
    }

    // Function to buy Fertilizer To increase profit
    public void BuyFertilizer()
    {
        if (SoilTile.GetComponent<PlantCreator>().HavePlant == true)
        {

            Plant.GetComponent<Fertilizer>().Fertilise(Time,Multi);

        }
    }



    //Buying Plant Growing Manager 
    public void GrowWithPlantManager()
    {

        if (SoilTile.GetComponent<PlantCreator>().HavePlant == true && Plant.GetComponent<ObjectPrice>().MyManagerCost <= Ballance && Plant.GetComponent<ManagerLogic>().HaveManager == false)
        {
           Bank.GetComponent<MoneyManager>().DecrementBallance(Plant.GetComponent<ObjectPrice>().MyManagerCost);
           Plant.GetComponent<ManagerLogic>().StartGrowing();
        }

    }

    //Buying Upgrade Plant Growing  Manager
    public void UpgradeGrowWithPlantManager()
    {
        if(SoilTile.GetComponent<PlantCreator>().HavePlant == true && Plant.GetComponent<ObjectPrice>().ManagerUpgradeCost <= Ballance && Plant.GetComponent<ManagerLogic>().HaveManager == true)
        {
            Bank.GetComponent<MoneyManager>().DecrementBallance(Plant.GetComponent<ObjectPrice>().ManagerUpgradeCost);
            Plant.GetComponent<ObjectPrice>().ChangeManagerUpgradePrice();
            Plant.GetComponent<ManagerLogic>().UpgradeManager();
        }
        
    }


}
