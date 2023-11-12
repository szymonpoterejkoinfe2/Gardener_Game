using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSave : MonoBehaviour
{
    private IDataService DataService = new JasonDataService();
    public SaveSystem saveSystem;

    // Class with invormation abaut application quit time
    public class ExitTime
    {
        public System.DateTime extTime;

        //Constructors
        public ExitTime() {}
        public ExitTime(System.DateTime time) { extTime = time; }

        //Setting current device time
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

    // Function to save exit time to json file
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

    // Function to load back data with quit time and to calculate proper reward from all active managers
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

            // calculating proper reward 
            if (managerLogic.haveManager)
            {
                int finishedCycles = System.Convert.ToInt32(System.Math.Round(logOutTime / managerLogic.growTime));

                moneyManager.myBalance.IncrementBalance(pricingSystem.plantPrices.GetObjGrownIncome(plant.GetComponent<ObjectCharacteristics>().myId) * finishedCycles);
                Debug.Log("Finished cycles: " + finishedCycles);
            }

        }

        // Saving just added reward
        saveSystem.SaveMoneyBalance();

    }
}
