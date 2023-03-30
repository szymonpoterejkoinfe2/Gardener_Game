using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCreator : MonoBehaviour
{
    public GameObject plants;
    public bool HavePlant = false;

   

    public void Generate_Plant()
    {
        if (HavePlant == false)
        {
            GameObject new_plant = Instantiate(plants, new Vector3(0, 0, 0), Quaternion.identity, transform);
            new_plant.name = "Plant";
            new_plant.tag = "Plant";
            new_plant.transform.localPosition = new Vector3(0, 1, 0);
            HavePlant = true;
        }
    }
    public void PrintMessage()
    {
        Debug.Log("Found");
    }
}
