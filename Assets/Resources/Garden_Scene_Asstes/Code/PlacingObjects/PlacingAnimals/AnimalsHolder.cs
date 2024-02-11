using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsHolder : MonoBehaviour
{

    [SerializeField]
    NewDictionary newDict;

    [SerializeField]
    public Dictionary<string, GameObject> allAnimals;

    private void Awake()
    {
        allAnimals = newDict.ToDictionary();
    }
};

[Serializable]
public class NewDictionary
{
    [SerializeField]
    NewDictionaryItem[] dictionaryItems;

    public Dictionary<string, GameObject> ToDictionary()
    {
        Dictionary<string, GameObject> newDict = new Dictionary<string, GameObject>();

        foreach (var item in dictionaryItems)
        {
            newDict.Add(item.key, item.element);
        }

        return newDict;
    }
}


[Serializable]
public class NewDictionaryItem
{
    [SerializeField]
    public string key;

    [SerializeField]
    public GameObject element;

}