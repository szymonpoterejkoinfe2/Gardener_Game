using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateNotUsedTiles : MonoBehaviour
{
    [SerializeField]
    GameObject[] allSoilTiles, allCoverTiles;

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
            if (soil.tag == "MovedSoil")
            {
                soilRotation.StartRotation(soil);
                string soilID = soil.GetComponent<ObjectCharacteristics>().uniqueId;
            }
        }
        TilesSetActive(allCoverTiles,false);
    }

    public void ActivateAll()
    {
        soilRotation.StopRotation();

        TilesSetActive(allSoilTiles,true);
        TilesSetActive(allCoverTiles,true);
    }


    private void TilesSetActive(GameObject[] tiles, bool action)
    {
        foreach (GameObject tile in tiles)
        {
            if (tile != null)
            {
                tile.SetActive(action);
            }
        }
    }


}
