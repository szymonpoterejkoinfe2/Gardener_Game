using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlant : MonoBehaviour
{
    Dictionary<string, GameObject> plants, allSoilTiles;

    [SerializeField]
    public Dictionary<string, string> placedPlants;

    [SerializeField]
    PlacedPlantHolder placedPlantHolder;

    [SerializeField]
    SaveSystem saveSystem;

    [SerializeField]
    SoilTiles soilTiles;



    private void Awake()
    {
        placedPlants = placedPlantHolder.ToDictionary();
    }

    // Start is called before the first frame update
    void Start()
    {
        plants = GetComponent<PlantsHolder>().allPlants;
        allSoilTiles = soilTiles.allSoilTiles;
    }

    //Function to Instantiate plant object
    public void PlacePlantObject(string plantID)
    {
        GameObject soil = GameObject.FindGameObjectWithTag("MovedSoil");

        GameObject new_plant = Instantiate(plants[plantID], new UnityEngine.Vector3(0, 0, 0), UnityEngine.Quaternion.identity, soil.transform);
        new_plant.name = "Plant";
        new_plant.tag = "Plant";
        new_plant.transform.localPosition = new UnityEngine.Vector3(0, 0.5f, 0);
        new_plant.transform.localScale = new UnityEngine.Vector3(0f, 0f, 0f);

        placedPlants[soil.GetComponent<ObjectCharacteristics>().uniqueId] = plantID;

        saveSystem.SavePlants();
    }


    public void LoadPlants(Dictionary<string,string> savedPlants)
    {
        placedPlants = savedPlants;

        foreach (var plant in savedPlants)
        {
            GameObject soil = allSoilTiles[plant.Key];

            GameObject new_plant = Instantiate(plants[plant.Value], new UnityEngine.Vector3(0, 0, 0), UnityEngine.Quaternion.identity, soil.transform);
            new_plant.name = "Plant";
            new_plant.tag = "Plant";
            new_plant.transform.localPosition = new UnityEngine.Vector3(0, 0.5f, 0);
            new_plant.transform.localScale = new UnityEngine.Vector3(0f, 0f, 0f);

        }

    }

}

[Serializable]
public class PlacedPlantHolder
{
    [SerializeField]
    PlacedPlant[] dictionaryItems;

    public Dictionary<string, string> ToDictionary()
    {
        Dictionary<string, string> newDict = new Dictionary<string, string>();

        foreach (var item in dictionaryItems)
        {
            newDict.Add(item.soilID, item.plantID);
        }

        return newDict;
    }
}


[Serializable]
public class PlacedPlant
{
    [SerializeField]
    public string soilID;

    [SerializeField]
    public string plantID;

}