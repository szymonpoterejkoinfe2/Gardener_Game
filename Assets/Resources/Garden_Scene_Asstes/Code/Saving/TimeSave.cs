using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSave : MonoBehaviour
{
    private IDataService DataService = new JasonDataService();
    public SaveSystem saveSystem;

    public class ExitTime
    {
        public System.DateTime extTime;

        public ExitTime() {}
        public ExitTime(System.DateTime time) { extTime = time; }
        public void SetTime()
        {
            extTime = System.DateTime.UtcNow;
        }
    }

    public ExitTime eTime;

    TimeSave()
    {
        eTime = new ExitTime();
        eTime.SetTime();
    }

    private IEnumerator SetTime()
    {
        while (true) {

            yield return new WaitForSeconds(5);
            eTime.SetTime();

            if (DataService.SaveData("/ExitTime.json", eTime, true))
            {
                Debug.Log("Time saved");
            }

        }


    }

    void Start()
    {

        StartCoroutine(SetTime());
    }


    public void LoadTime(ExitTime time)
    {

        System.DateTime currentTime = System.DateTime.UtcNow;
        System.TimeSpan logOutInterval = currentTime - time.extTime;
        double logOutTime = logOutInterval.TotalSeconds;

        GameObject[] plants = GameObject.FindGameObjectsWithTag("Plant");
        ManagerLogic managerLogic;
        GameObject bank = GameObject.FindGameObjectWithTag("Bank");
        MoneyManager moneyManager = bank.GetComponent<MoneyManager>();
        PricingSystemPlants pricingSystem = bank.GetComponent<PricingSystemPlants>();

        foreach (GameObject plant in plants)
        {
            managerLogic = plant.GetComponent<ManagerLogic>();
            if (managerLogic.haveManager)
            {
                int finishedCycles = System.Convert.ToInt32(System.Math.Round(logOutTime / managerLogic.growTime));

                moneyManager.myBalance.IncrementBalance(pricingSystem.plantPrices.GetObjGrownIncome(plant.GetComponent<ObjectCharacteristics>().myId) * finishedCycles);
                Debug.Log("Finished cycles: " + finishedCycles);
            }

        }

        saveSystem.SaveMoneyBalance();

    }
}
