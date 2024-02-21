using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilTiles : MonoBehaviour
{
    [SerializeField]
    NewDictionary soilTiles;

    public Dictionary<string, GameObject> allSoilTiles;

    private void Awake()
    {
        allSoilTiles = soilTiles.ToDictionary();
    }

}
