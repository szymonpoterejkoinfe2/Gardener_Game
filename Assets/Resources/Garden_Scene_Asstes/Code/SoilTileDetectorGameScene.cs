using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilTileDetectorGameScene : MonoBehaviour
{
     GameObject SoilTile;

    
    // Update is called once per frame
    void Update()
    {
        SoilTile = GameObject.FindGameObjectWithTag("MovedSoil");

    }
    //Function to generate plant after clicking on button.
    public void PlacePlant(int PlantId)
    {
        SoilTile.GetComponent<PlantCreator>().Generate_Plant(PlantId);
    }
}
