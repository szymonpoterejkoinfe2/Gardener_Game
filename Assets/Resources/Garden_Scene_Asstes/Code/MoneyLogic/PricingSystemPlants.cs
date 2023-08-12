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

    // Declaring ObjectPricing
    private void Awake()
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
    }


    //Changing money reward from fully grown plant
    public void UpdateIncomeValue(int objectId)
    {
        //Updating Profit from growing Plant
        BigInteger IncreaseUpdate, IncreaseIncome;
        IncreaseIncome = (objectPrice[objectId] / 10);
        objectPrice[objectId] += (BigInteger)(objectPrice[objectId] * IncreaseIncome);

        //Updating Cost of Upgrade
        IncreaseUpdate = ((objectUpgradeCost[objectId] / 10) * 2);
        objectUpgradeCost[objectId] += (BigInteger)(objectUpgradeCost[objectId] * IncreaseUpdate);
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
