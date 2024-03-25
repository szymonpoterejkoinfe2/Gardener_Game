using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkyAnimals : MonoBehaviour
{
    private Dictionary<string, GameObject> animals;
    private Dictionary<string, GameObject> allSoilTiles;
    SaveSystem saveManager;

    [SerializeField]
    SkyAnimalInfoDictionary skyAnimalInfoDictionary;

    [SerializeField]
    public Dictionary<string, Dictionary<string, int>> instantiatedSkyAnimals;

    [SerializeField]
    SoilTiles soilTiles;

    private void Awake()
    {
        instantiatedSkyAnimals = skyAnimalInfoDictionary.ToDictionary();
    }

    // Start is called before the first frame update
    void Start()
    {
        saveManager = FindObjectOfType<SaveSystem>();
        animals = FindObjectOfType<AnimalsHolder>().allAnimals;
        allSoilTiles = soilTiles.allSoilTiles;
    }

    //Function to Instantiate new "animalID" sky animal object
    public void SpawnAnimal(string animalID)
    {
        GameObject soilParent = GameObject.FindGameObjectWithTag("MovedSoil");
        GameObject newSkyAnimal = Instantiate(animals[animalID], new Vector3(0, 0, 0), UnityEngine.Quaternion.identity, soilParent.transform);

        AnimalAttributes animalAttributes = newSkyAnimal.GetComponent<AnimalAttributes>();
        ObjectCharacteristics objectCharacteristics = soilParent.GetComponent<ObjectCharacteristics>();

        newSkyAnimal.transform.localScale = animalAttributes.myLocalScale;
        newSkyAnimal.transform.localPosition = new Vector3(0, 2, 0);

        animalAttributes.soilTileID = objectCharacteristics.uniqueId;

        instantiatedSkyAnimals[objectCharacteristics.uniqueId][animalID] += 1;

        saveManager.SaveSkyAnimals();
        saveManager.SaveMoneyBalance();
    }

    public void LoadSkyAnimals(Dictionary<string, Dictionary<string, int>> skyAnimalsToLoad)
    {
        instantiatedSkyAnimals = skyAnimalsToLoad;

        foreach (var soilTile in skyAnimalsToLoad)
        {
            foreach (var skyAnimal in soilTile.Value)
            {
                if (skyAnimal.Value > 0)
                {
                    for (int skyAnimalQuantity = 0; skyAnimalQuantity < skyAnimal.Value; skyAnimalQuantity++)
                    {
                        GameObject newSkyAnimal = Instantiate(animals[skyAnimal.Key], new Vector3(0, 0, 0), UnityEngine.Quaternion.identity, allSoilTiles[soilTile.Key].transform);

                        newSkyAnimal.transform.localScale = animals[skyAnimal.Key].GetComponent<AnimalAttributes>().myLocalScale;
                        newSkyAnimal.transform.localPosition = new Vector3(0, 2, 0);
                    
                        newSkyAnimal.GetComponent<AnimalAttributes>().soilTileID = soilTile.Key;
                    }

                }

            }

        }
    }
}

[Serializable]
public class SkyAnimalInfoDictionary
{
    [SerializeField]
    SkyAnimalInfo[] dictionaryItems;


    public Dictionary<string, Dictionary<string, int>> ToDictionary()
    {
        Dictionary<string, Dictionary<string, int>> newDict = new Dictionary<string, Dictionary<string, int>>();

        foreach (var item in dictionaryItems)
        {
            newDict.Add(item.soilTileID, item.skyAnimalQuantity);
        }

        return newDict;
    }

}

[Serializable]
public class SkyAnimalInfo
{
    [SerializeField]
    public string soilTileID;
    [SerializeField]
    public Dictionary<string, int> skyAnimalQuantity = new Dictionary<string, int> {
        {"ButterFlyBlue", 0},
        {"ButterFlyRed", 0},
        {"Dove", 0},
        {"Eagle", 0},
        {"Parrot", 0 },
        {"Seagul", 0},
        {"Tucan", 0},
        {"Vulture", 0}
    };

}