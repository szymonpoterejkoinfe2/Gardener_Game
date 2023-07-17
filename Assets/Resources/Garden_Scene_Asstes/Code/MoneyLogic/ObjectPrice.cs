using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPrice : MonoBehaviour
{
    public ulong MyPrice = 10;
    public ulong ReturnFromDestruction = 5;
    public ulong GrownIncome = 7;
    public ulong UpgradeCost = 25;
    public ulong MyManagerCost = 150;
    public ulong ManagerUpgradeCost = 180;
    public int MyId;
    public float[] ValueTarget;

    //Changing money rewart from fully grown plant
    public void ChangeGrowIncome()
    {
        float IncreaseUpdate, IncreaseIncome;

        //Updating Profit from growing Plant
        IncreaseIncome = Mathf.Round(GrownIncome * 0.1f);
        GrownIncome += (ulong)IncreaseIncome;
        

        //Updating Cost of Upgrade
        IncreaseUpdate = Mathf.Round(UpgradeCost * 0.2f);
        UpgradeCost += (ulong)IncreaseUpdate;

    }

    public void ChangeManagerUpgradePrice()
    {
        float IncreaseUpdate;
        IncreaseUpdate = Mathf.Round(ManagerUpgradeCost * 0.35f);
        ManagerUpgradeCost += (ulong)IncreaseUpdate;
    }

}

