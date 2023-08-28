using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilTileDetectorGameScene : MonoBehaviour
{
    private GameObject soilTile;
    public CameraAndTileManager cameraTileManager;
    public GrowPlant Grower;

    // Update is called once per frame
    void Update()
    {
        soilTile = GameObject.FindGameObjectWithTag("MovedSoil");

        //Counting number of touch and growing plant times number of touch 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

          Grower.Grow(Input.touchCount); 

        }
        
    }

    //Function To Activate Shopping Menu
    public void ShopMenuActivate()
    {
        cameraTileManager.ActivateShopMenu();
    }

    //Function to generate plant after clicking on button.
    public void PlacePlant(int PlantId)
    {
        soilTile.GetComponent<PlantCreator>().Generate_Plant(PlantId);
    }
    // Function to set Holder id
    public void SetHolderId(int id)
    {
        soilTile.GetComponent<PlaceObject>().SetHolderId(id);
    }

    // Function to set Object id
    public void SetObjectId(int id)
    {
        soilTile.GetComponent<PlaceObject>().SetObjectId(id);
    }
    
    //Function to generate object after clicking on button.
    public void PlaceObject()
    {
        cameraTileManager.DeActivateShopMenu();
        soilTile.GetComponent<SoilRotation>().Should_Rotate = false;
        soilTile.GetComponent<SoilRotation>().ResetState();
        soilTile.GetComponent<PlaceObject>().CreateObject();
    }

    //Function to return from single tile view to whole garden view
    public void GoBackToGarden()
    {
        cameraTileManager.ChangeToCameraOne(soilTile);
    }

}
