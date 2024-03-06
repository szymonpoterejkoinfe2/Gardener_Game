using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerHolder : MonoBehaviour
{
    [SerializeField]
    ManagerDictionary managerDictionary;

    [SerializeField]
    SoilTiles soilTiles;

    public Dictionary<string, ManagerInfo> allManagers;

    private void Awake()
    {
        allManagers = managerDictionary.ToDictionary();
    }


    public void LoadManagers(Dictionary<string, ManagerInfo> managersToLoad)
    {

        foreach (var manager in managersToLoad)
        {
            ManagerLogic managerLogic;
            if (manager.Value.haveManager)
            {
                managerLogic =  soilTiles.allSoilTiles[manager.Key].transform.Find("Plant").GetComponent<ManagerLogic>();

                managerLogic.haveManager = manager.Value.haveManager;
                managerLogic.managerLevel = manager.Value.managerLevel;
                managerLogic.StartGrowing(manager.Value.managerTime);

            }

        }

    }

}

[Serializable]
public class ManagerDictionary
{
    [SerializeField]
    ManagerInfoHolder[] dictionaryItems;

    public Dictionary<string, ManagerInfo> ToDictionary()
    {
        Dictionary<string, ManagerInfo> newDict = new Dictionary<string, ManagerInfo>();

        foreach (var item in dictionaryItems)
        {
            newDict.Add(item.soilID, item.managerInfo);
        }

        return newDict;
    }

}

[Serializable]
public class ManagerInfoHolder
{
    [SerializeField]
    public string soilID;

    [SerializeField]
    public ManagerInfo managerInfo;
}

[Serializable]
public class ManagerInfo
{
    [SerializeField]
    public bool haveManager = false;
    [SerializeField]
    public int managerLevel = 1;
    [SerializeField]
    public float managerTime = 0;
}