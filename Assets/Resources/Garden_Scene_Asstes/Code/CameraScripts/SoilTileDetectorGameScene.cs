using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoilTileDetectorGameScene : MonoBehaviour
{
    private GameObject soilTile;
    public CameraAndTileManager cameraTileManager;
    public GrowPlant Grower;
    SaveSystem saveManager;


    private void Awake()
    {
        saveManager = GameObject.FindObjectOfType<SaveSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        soilTile = GameObject.FindGameObjectWithTag("MovedSoil");

        //Counting number of touch and growing plant times number of touch 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
          Grower.Grow(Input.touchCount); 
        }

        // Determining whether hit transform is of Bad Bird type, if so destroing it
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            UnityEngine.Vector3 touchPos = t.position;

            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "BadBird")
                {
                    hit.transform.gameObject.GetComponent<BadBirdFly>().Kill(); ;
                }
            }
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
        soilTile.GetComponent<PlantCreator>().Generate_Plant(PlantId,false);

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
        soilTile.GetComponent<PlaceObject>().CreateObject();
       
    }

    // function to start hydration process
    public void BuyHydration(float hydrationTime)
    {
        soilTile.GetComponent<HydrationLogic>().StartHydration((ulong)hydrationTime);
        saveManager.SaveSoil();
        saveManager.SaveMoneyBalance();
    }

    // function to generate flying decoration object
    public void BuyFlyingDecoration(int decoration)
    {
        soilTile.GetComponent<CreateFlyDecoration>().CreateFlyingCreature(decoration);
        saveManager.SaveFlyingDecoration();
        saveManager.SaveMoneyBalance();
    }

    //Function to return from single tile view to whole garden view
    public void GoBackToGarden()
    {
        cameraTileManager.ChangeToCameraOne(soilTile);
    }

}
