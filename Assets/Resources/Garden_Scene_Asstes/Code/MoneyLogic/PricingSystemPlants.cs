using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class PricingSystemPlants : MonoBehaviour
{
   
    public class PlantPrices
    {
        //                                   0   1   2     3     4     5      6       7      8       9       10         11        12        13    14  14  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30  31  32  33
        public BigInteger[] objectPrice = { 15, 80, 250, 1000, 5000, 20000,100000, 250000,750000, 1500000, 5000000, 15000000, 30000000, 90000000, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12};
        public BigInteger[] objectDestructionReturn = { 5, 50, 120, 1, 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 };
        public BigInteger[] objectGrownIncome = { 2, 15, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0 };
        public BigInteger[] objectUpgradeCost = { 25, 60, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0 };
        public BigInteger[] objectMenagerCost = { 150, 450, 1050, 1000, 5000, 20000, 100000, 250000, 750000, 1500000, 5000000, 15000000, 30000000, 90000000, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12 };
        public BigInteger[] objectMenagerUpgradeCost = { 180, 300, 700, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0 };
        MoneyManager moneyManager;

        public PlantPrices() { }
        public PlantPrices(BigInteger[] objPrice, BigInteger[] objDestRet, BigInteger[] objInc, BigInteger[] objUpg, BigInteger[] mngCos, BigInteger[] mngUpg)
        {
            objectPrice = objPrice;
            objectDestructionReturn = objDestRet;
            objectGrownIncome = objInc;
            objectUpgradeCost = objUpg;
            objectMenagerCost = mngCos;
            objectMenagerUpgradeCost = mngUpg;
        }

        // Object price geter
        public BigInteger GetObjPrice(int id)
        {
            return objectPrice[id];
        }
        // Object destruction return geter
        public BigInteger GetObjDstructionReturn(int id)
        {
            return objectDestructionReturn[id];
        }
        // Object grown income geter
        public BigInteger GetObjGrownIncome(int id)
        {
            return objectGrownIncome[id];
        }
        // Object upgrade cost geter
        public BigInteger GetObjUpgradeCost(int id)
        {
            return objectUpgradeCost[id];
        }
        // Object menager income geter
        public BigInteger GetObjMenagerCost(int id)
        {
            return objectMenagerCost[id];
        }
        // Object menager upgrade cost
        public BigInteger GetObjMenagerUpgradeCost(int id)
        {
            return objectMenagerUpgradeCost[id];
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
            IncreaseUpdate = (objectMenagerUpgradeCost[objectId] / 3);
            objectMenagerUpgradeCost[objectId] += IncreaseUpdate;
        }
    }

    public PlantPrices plantPrices;

    public PricingSystemPlants()
    {
        plantPrices = new PlantPrices();
    }

    //Function to load saved prices
    public void LoadData(PlantPrices savedPrices)
    {
        plantPrices = savedPrices;
    }
}
