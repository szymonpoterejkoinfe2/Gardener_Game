using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilTileDetectorGameScene : MonoBehaviour
{
    private GameObject SoilTile, Plant;
    public CameraAndTileManager CameraTileManager;
    public GrowPlant Grower;

    private void Start()
    {
        SoilTile = GameObject.FindGameObjectWithTag("MovedSoil");
    }

    // Update is called once per frame
    void Update()
    {
        SoilTile = GameObject.FindGameObjectWithTag("MovedSoil");

        //Counting number of touch and growing plant times number of touch 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

          Grower.Grow(Input.touchCount); 

        }
        
    }

    public void ShopMenuActivate()
    {
        CameraTileManager.ActivateShopMenu();
    }

    //Function to generate plant after clicking on button.
    public void PlacePlant(int PlantId)
    {
        SoilTile.GetComponent<PlantCreator>().Generate_Plant(PlantId);
    }

    //Function to return from single tile view to whole garden view
    public void GoBackToGarden()
    {
        CameraTileManager.ChangeToCameraOne(SoilTile);
    }

}
