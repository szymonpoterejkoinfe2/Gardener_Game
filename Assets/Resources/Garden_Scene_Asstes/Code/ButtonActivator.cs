using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{
    [SerializeField]
    Button buyButton;

    [SerializeField]
    Button upgradeButton;

    [SerializeField]
    int id;

    [SerializeField]
    string plantId;

    [SerializeField]
    PricingSystemPlants pricingSystemPlants;

    [SerializeField]
    MoneyManager moneyManager;

    [SerializeField]
    Category category;

    GameObject soilTile;
     string plantName;
     bool haveManager;

    PricingSystemPlants.PlantPrices plantPrices;
    MoneyManager.MoneyBalance moneyBalance;



    // Start is called before the first frame update
    void Start()
    {
        buyButton.interactable = false;
        upgradeButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        plantPrices = pricingSystemPlants.plantPrices;
        moneyBalance = moneyManager.myBalance;

        if (category == Category.Manager)
        {
            
            if (plantPrices.objectMenagerCost[id] > moneyBalance.moneyBalance || soilTile.GetComponent<SoilTileInformation>().havePlant == false || plantName != plantId || haveManager == true)
            {
                Disable(buyButton);
            }
            else
            {
                Enable(buyButton);
            }

            if (plantPrices.objectMenagerUpgradeCost[id] > moneyBalance.moneyBalance || soilTile.GetComponent<SoilTileInformation>().havePlant == false || plantName != plantId)
            {
                Disable(upgradeButton);
            }
            else
            {
                Enable(upgradeButton);
            }
        }
        if (category == Category.Plant)
        {
           

            Enable(buyButton);

            if (plantPrices.objectPrice[id] > moneyBalance.moneyBalance || soilTile.GetComponent<SoilTileInformation>().havePlant == true)
            {
                Disable(buyButton);
            }
            else
            {
                Enable(buyButton);
            }

            if (plantPrices.objectUpgradeCost[id] > moneyBalance.moneyBalance || soilTile.GetComponent<SoilTileInformation>().havePlant == false || plantName != plantId)
            {
                Disable(upgradeButton);
            }
            else {
                Enable(upgradeButton);
            }
        }

    }

    private void Disable(Button button)
    {
        button.interactable = false;
    }

    private void Enable(Button button)
    {
        button.interactable = true;
    }

    private void OnEnable()
    {
       

        soilTile = GameObject.FindGameObjectWithTag("MovedSoil");

        if (soilTile.GetComponent<SoilTileInformation>().havePlant == true)
        {
            GameObject plant = soilTile.transform.Find("Plant").gameObject;
            plantName = plant.GetComponent<ObjectCharacteristics>().myName;
            haveManager = plant.GetComponent<ManagerLogic>().haveManager;
        }
        else {
            plantName = "None";
            haveManager = false;
        }

    }



}

enum Category
{
Manager,
Plant
}