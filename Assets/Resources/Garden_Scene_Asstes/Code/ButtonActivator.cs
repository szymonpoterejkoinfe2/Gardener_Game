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
    PricingSystemPlants pricingSystemPlants;

    [SerializeField]
    MoneyManager moneyManager;


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


        if (plantPrices.objectMenagerCost[id] > moneyBalance.moneyBalance)
        {
            buyButton.interactable = false;
        }
        else {
            buyButton.interactable = true;
        }

        if (plantPrices.objectMenagerUpgradeCost[id] > moneyBalance.moneyBalance)
        {
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeButton.interactable = true;
        }

    }



}
