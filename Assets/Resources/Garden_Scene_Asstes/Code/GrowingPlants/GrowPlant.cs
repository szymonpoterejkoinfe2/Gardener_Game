using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlant : MonoBehaviour
{
    GameObject plant, soil, bank;
    ParticleSystem leafs;
    Vector3 scaleValue, targetScale;
    public float multiplyer = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        
        scaleValue = new Vector3(0.002f, 0.01f, 0.002f);

    }
    void Update()
    {
        soil = GameObject.FindGameObjectWithTag("MovedSoil");
        bank = GameObject.FindGameObjectWithTag("Bank");
    }

    // Function Scale Plant GameObject to imitate Growth;
    public void Grow(int TouchCount)
    {
        if (soil.GetComponent<PlantCreator>().havePlant == true && soil.GetComponent<HydrationLogic>().hydrated == true)
        {
            plant = soil.transform.Find("Plant").gameObject;

            targetScale = new Vector3(plant.GetComponent<ObjectCharacteristics>().valueTarget[0], plant.GetComponent<ObjectCharacteristics>().valueTarget[1], plant.GetComponent<ObjectCharacteristics>().valueTarget[2]);
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
            if (bank.GetComponent<MoneyManager>().myBalance.moneyBalance >= bank.GetComponent<PricingSystemPlants>().objectPrice[plant.GetComponent<ObjectCharacteristics>().myId])
            {
                bank.GetComponent<MoneyManager>().myBalance.DecrementBalance(bank.GetComponent<PricingSystemPlants>().objectPrice[plant.GetComponent<ObjectCharacteristics>().myId]);

                bank.GetComponent<PricingSystemPlants>().UpdateIncomeValue(plant.GetComponent<ObjectCharacteristics>().myId);
            }
        }
    }

}
