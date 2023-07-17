using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCreator : MonoBehaviour
{
    public GameObject[] plants;
    public bool HavePlant = false;
    public float FixedScale = 0;
    //public GameObject parent;
    private GameObject Bank, GrowPlant;
    ulong Ballance, Price;


    void Update()
    {
       Bank = GameObject.FindGameObjectWithTag("Bank");
       Ballance = Bank.GetComponent<MoneyManager>().MoneyBallance;

        GrowPlant = GameObject.FindGameObjectWithTag("MainCamera");
        
    }

    // Function which Generates new plant game object based on plants prefabs.
    public void Generate_Plant(int PlantId)
    {
        Price = plants[PlantId].GetComponent<ObjectPrice>().MyPrice;
        if (HavePlant == false && Ballance >= Price)
        {
            Bank.GetComponent<MoneyManager>().DecrementBallance(Price);
            GameObject new_plant = Instantiate(plants[PlantId], new Vector3(0, 0, 0), Quaternion.identity, transform);
            new_plant.name = "Plant";
            new_plant.tag = "Plant";
            new_plant.transform.localPosition = new Vector3(0, 0.5f, 0);
            new_plant.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            HavePlant = true;
            
        }
    }
 
}
