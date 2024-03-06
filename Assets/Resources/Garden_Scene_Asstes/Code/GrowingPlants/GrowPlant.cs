using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class GrowPlant : MonoBehaviour
{
    GameObject bank;
    UnityEngine.Vector3 scaleValue;
    float multiplyer;
    private SaveSystem saveManager;
    PricingSystemPlants pricingSystem;

    // Start is called before the first frame update
    void Start()
    {
        scaleValue = new UnityEngine.Vector3(0.00002f, 0.0001f, 0.00002f);
        bank = GameObject.FindGameObjectWithTag("Bank"); 
        saveManager = FindObjectOfType<SaveSystem>();
    }

    // Function Scale Plant GameObject to imitate Growth;
    public void Grow(int TouchCount)
    {
        GameObject soil = GameObject.FindGameObjectWithTag("MovedSoil");

        if (soil.GetComponent<SoilTileInformation>().havePlant == true && soil.GetComponent<HydrationLogic>().hydrated == true)
        {
            GameObject plant = soil.transform.Find("Plant").gameObject;
            ObjectCharacteristics plantCharacteristics = plant.GetComponent<ObjectCharacteristics>();
            multiplyer = plantCharacteristics.growMultiplyer;

            if (plant.GetComponent<ManagerLogic>().haveManager == false)
            {
                plant.transform.localScale += TouchCount * (scaleValue * multiplyer);
            }
        }
    }

    // Upgrading Plant to earn more on every sold flower.
    public void UpgradePlant()
    {
        pricingSystem = bank.GetComponent<PricingSystemPlants>();

        GameObject soil = GameObject.FindGameObjectWithTag("MovedSoil");

        if (soil.GetComponent<SoilTileInformation>().havePlant == true)
        {
            GameObject plant = soil.transform.Find("Plant").gameObject;
            ObjectCharacteristics objectCharacteristics = plant.GetComponent<ObjectCharacteristics>();
            pricingSystem.plantPrices.UpdateIncomeValue(objectCharacteristics.myId);
            saveManager.SaveMoneyBalance();
            saveManager.SavePlantPricing();
        }
    }

}
