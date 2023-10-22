using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class PricingSystemPlants : MonoBehaviour
{
    public BigInteger[] objectPrice = {0,0,0,0,0};
    public BigInteger[] objectDestructionReturn = { 0, 0, 0, 0, 0 };
    public BigInteger[] objectGrownIncome = { 0, 0, 0, 0, 0 };
    public BigInteger[] objectUpgradeCost = { 0, 0, 0, 0, 0 };
    public BigInteger[] objectMenagerCost = { 0, 0, 0, 0, 0 };
    public BigInteger[] objectMenagerUpgradeCost = { 0, 0, 0, 0, 0 };
    public MoneyManager moneyManager;

    // Declaring ObjectPricing
    private void Start()
    {
       

        // #1 Plant
        objectPrice[0] = 15;
        objectDestructionReturn[0] = 5;
        objectGrownIncome[0] = 7;
        objectUpgradeCost[0] = 25;
        objectMenagerCost[0] = 150;
        objectMenagerUpgradeCost[0] = 180;

        // #2 Plant
        objectPrice[1] = 80;
        objectDestructionReturn[1] = 55;
        objectGrownIncome[1] = 30;
        objectUpgradeCost[1] = 60;
        objectMenagerCost[1] = 450;
        objectMenagerUpgradeCost[1] = 400;

        // #3 Plant
        objectPrice[2] = 250;
        objectDestructionReturn[2] = 55;
        objectGrownIncome[2] = 70;
        objectUpgradeCost[2] = 160;
        objectMenagerCost[2] = 1050;
        objectMenagerUpgradeCost[2] = 700;

    }


    //Changing money reward from fully grown plant
    public void UpdateIncomeValue(int objectId)
    {
        moneyManager = GameObject.FindGameObjectWithTag("Bank").GetComponent<MoneyManager>();
        if (moneyManager.myBalance.moneyBalance >= objectUpgradeCost[objectId])
        {

            //Updating Profit from growing Plant
            BigInteger IncreaseUpdate, IncreaseIncome;
            IncreaseIncome = (objectPrice[objectId] / 8);
            objectGrownIncome[objectId] += IncreaseIncome;

            moneyManager.myBalance.DecrementBalance(objectUpgradeCost[objectId]);

            //Updating Cost of Upgrade
            IncreaseUpdate = ((objectUpgradeCost[objectId] / 3));
            objectUpgradeCost[objectId] += IncreaseUpdate;

        }

        
    }

    // Changing Price of upgrade for manager
    public void UpdateManagerCost(int objectId)
    {
        //updating price of manager after upgrade 
        BigInteger IncreaseUpdate;
        IncreaseUpdate = ((objectMenagerUpgradeCost[objectId] / 10) * 3);
        objectMenagerUpgradeCost[objectId] += (BigInteger)(objectMenagerUpgradeCost[objectId] * IncreaseUpdate);
    }

}
