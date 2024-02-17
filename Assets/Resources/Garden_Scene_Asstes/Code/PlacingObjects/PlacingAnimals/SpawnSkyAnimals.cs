using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkyAnimals : MonoBehaviour
{
    private Dictionary<string, GameObject> animals;
    SaveSystem saveManager;


    private void Awake()
    {
        saveManager = FindObjectOfType<SaveSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animals = FindObjectOfType<AnimalsHolder>().allAnimals;
    }

    //Function to Instantiate new "animalID" sky animal object
    public void SpawnAnimal(string animalID)
    {
        GameObject soilParent = GameObject.FindGameObjectWithTag("MovedSoil");
        GameObject newSkyAnimal = Instantiate(animals[animalID], new Vector3(0, 0, 0), UnityEngine.Quaternion.identity, soilParent.transform);

        newSkyAnimal.transform.localScale = animals[animalID].GetComponent<AnimalAttributes>().myLocalScale;
        newSkyAnimal.transform.localPosition = new Vector3(0, 2, 0);

        saveManager.SaveFlyingDecoration();
        saveManager.SaveMoneyBalance();
    }

}

