using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsHolder : MonoBehaviour
{

    [SerializeField]
    NewDictionary plants;

    [SerializeField]
    public Dictionary<string, GameObject> allPlants;

    private void Awake()
    {
        allPlants = plants.ToDictionary();
    }
}
