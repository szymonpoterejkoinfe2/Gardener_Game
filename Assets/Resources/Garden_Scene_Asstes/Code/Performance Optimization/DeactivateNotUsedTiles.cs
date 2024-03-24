using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateNotUsedTiles : MonoBehaviour
{
    [SerializeField]
    GameObject[] allSoilTiles;

    [SerializeField]
    SoilRotation soilRotation;

    //deactivating not vilible soil tiles
    public void DeactivateNotUsed()
    {
        foreach (GameObject soil in allSoilTiles)
        {
            if (soil.tag != "MovedSoil")
            {
                soil.SetActive(false);
            }
            if(soil.tag == "MovedSoil")
            {
                soilRotation.StartRotation(soil);
            }
        }
    }

    public void ActivateAll()
    {
        soilRotation.StopRotation();
        foreach (GameObject soil in allSoilTiles)
        {
            soil.SetActive(true);
        }
    }


}
