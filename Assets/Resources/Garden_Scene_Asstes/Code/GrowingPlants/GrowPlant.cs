using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class GrowPlant : MonoBehaviour
{
    GameObject plant, soil, bank;
    ParticleSystem leafs;
    UnityEngine.Vector3 scaleValue, targetScale;
    public float multiplyer = 1;
    MoneyManager moneyManager;
    private SaveSystem saveManager;
    PricingSystemPlants pricingSystem;

    // Start is called before the first frame update
    void Start()
    {
        scaleValue = new UnityEngine.Vector3(0.0002f, 0.001f, 0.0002f);
        bank = GameObject.FindGameObjectWithTag("Bank"); 
        moneyManager = bank.GetComponent<MoneyManager>();
        saveManager = GameObject.FindObjectOfType<SaveSystem>();
    }
    void Update()
    {
        soil = GameObject.FindGameObjectWithTag("MovedSoil");
        pricingSystem = bank.GetComponent<PricingSystemPlants>();
    }

    // Function Scale Plant GameObject to imitate Growth;
    public void Grow(int TouchCount)
    {
        if (soil.GetComponent<PlantCreator>().havePlant == true && soil.GetComponent<HydrationLogic>().hydrated == true)
        {
            plant = soil.transform.Find("Plant").gameObject;

            targetScale = new UnityEngine.Vector3(plant.GetComponent<ObjectCharacteristics>().valueTarget[0], plant.GetComponent<ObjectCharacteristics>().valueTarget[1], plant.GetComponent<ObjectCharacteristics>().valueTarget[2]);
            if (plant.GetComponent<ManagerLogic>().haveManager == false)
            {
                plant.transform.localScale += TouchCount * (scaleValue * multiplyer);
            }
        }
    }

    // Upgrading Plant to earn more on every sold flower.
    public void UpgradePlant()
    {
  
  

        if (soil.GetComponent<PlantCreator>().havePlant == true)
        {
            plant = soil.transform.Find("Plant").gameObject;
            ObjectCharacteristics objectCharacteristics = plant.GetComponent<ObjectCharacteristics>();
            pricingSystem.plantPrices.UpdateIncomeValue(objectCharacteristics.myId);
            saveManager.SaveMoneyBalance();
            saveManager.SavePlantPricing();
        }
    }

}
