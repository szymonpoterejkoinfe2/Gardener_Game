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

    [SerializeField]
    GameObject plantSlider;

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
        SoilTileInformation soilTileInformation = soil.GetComponent<SoilTileInformation>();

        if (!soilTileInformation.havePlant)
        {
            GameObject new_plant = Instantiate(plants[plantID], new Vector3(0, 0, 0), Quaternion.identity, soil.transform);
            new_plant.name = "Plant";
            new_plant.tag = "Plant";
            new_plant.transform.localPosition = new Vector3(0, 0.5f, 0);
            new_plant.transform.localScale = new Vector3(0f, 0f, 0f);

            soilTileInformation.havePlant = true;
            plantSlider.SetActive(true);

            HydrationLogic hydration = soil.GetComponent<HydrationLogic>();

            if (!hydration.haveWell)
            {
                hydration.StartHydration(120);
            }

            placedPlants[soil.GetComponent<ObjectCharacteristics>().uniqueId] = plantID;
            saveSystem.SavePlants();

        }

    }

    //Function to Instantiate plant objects from save file
    public void LoadPlants(Dictionary<string,string> savedPlants)
    {
        placedPlants = savedPlants;

        foreach (var plant in savedPlants)
        {
            try
            {
                GameObject soil = allSoilTiles[plant.Key];
                SoilTileInformation soilTileInformation = soil.GetComponent<SoilTileInformation>();

                GameObject new_plant = Instantiate(plants[plant.Value], new Vector3(0, 0, 0), Quaternion.identity, soil.transform);
                new_plant.name = "Plant";
                new_plant.tag = "Plant";
                new_plant.transform.localPosition = new Vector3(0, 0.5f, 0);
                new_plant.transform.localScale = new Vector3(0f, 0f, 0f);

                soilTileInformation.havePlant = true;
            }
            catch
            {
               // Console.WriteLine("Something went wrong.");
            }
        }

    }

    //Function to remove plant from saved;
    public void RemoveFromDictionary(string soilID)
    {
        placedPlants[soilID] = "";
    }


}

[Serializable]
class PlacedPlantHolder
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