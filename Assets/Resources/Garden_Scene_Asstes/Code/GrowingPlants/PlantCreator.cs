using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class PlantCreator : MonoBehaviour
{
    public GameObject[] plants;
    public bool havePlant = false;
    public float fixedScale = 0;
    //public GameObject parent;
    private GameObject bank, growPlant;
    BigInteger ballance, price;


    void Update()
    {
       bank = GameObject.FindGameObjectWithTag("Bank");
       ballance = bank.GetComponent<MoneyManager>().myBalance.moneyBalance;
       growPlant = GameObject.FindGameObjectWithTag("MainCamera");
        
    }

    // Function which Generates new plant game object based on plants prefabs.
    public void Generate_Plant(int PlantId)
    {
        price = bank.GetComponent<PricingSystemPlants>().objectPrice[plants[PlantId].GetComponent<ObjectCharacteristics>().myId];
        if (havePlant == false && ballance >= price)
        {
            bank.GetComponent<MoneyManager>().myBalance.DecrementBalance(price);
            gameObject.GetComponent<HydrationLogic>().StartHydration(120);
            GameObject new_plant = Instantiate(plants[PlantId], new UnityEngine.Vector3(0, 0, 0), UnityEngine.Quaternion.identity, transform);
            new_plant.name = "Plant";
            new_plant.tag = "Plant";
            new_plant.transform.localPosition = new UnityEngine.Vector3(0, 0.5f, 0);
            new_plant.transform.localScale = new UnityEngine.Vector3(0.001f, 0.001f, 0.001f);
            havePlant = true;
            
        }
    }
 
}
