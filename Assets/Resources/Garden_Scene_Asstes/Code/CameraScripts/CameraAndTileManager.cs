using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAndTileManager : MonoBehaviour
{

    public GameObject CameraOne;
    public GameObject CameraTwo;
    public GameObject ShopMenu;
    public GameObject NavigationButtons;
    public GameObject[] Faders;
    public Rotation rotation;
    public Vector3 PositionMemory;
    public Animator CameraOneAnimator, CameraTwoAnimator;
    
    //Deactivating object on awake
    private void Awake()
    {
        CameraTwo.SetActive(false);
        ShopMenu.SetActive(false);
        NavigationButtons.SetActive(false);
    }


    // function to switch to camera two
    public void ChangeToCameraTwo()
    {
        Faders[1].SetActive(true);
        CameraOne.SetActive(false);
        CameraTwo.SetActive(true);
        CameraTwoAnimator.Play("CameraTwoFadeIn");
        NavigationButtons.SetActive(true);
       // GameObject.FindGameObjectWithTag("Hydration").GetComponent<HydrationSliderStatus>().ShowSlider();
    }

    // function to switch to camera one
    public void ChangeToCameraOne(GameObject Soil)
    {
        CameraOne.SetActive(true);
        Faders[0].SetActive(true);
        CameraOneAnimator.Play("CameraOneFadeIn");
        CameraTwo.SetActive(false);
        ShopMenu.SetActive(false);
        NavigationButtons.SetActive(false);
        rotation.speed = 2;
        ResetSoilTile(Soil);
        //GameObject.FindGameObjectWithTag("Hydration").GetComponent<HydrationSliderStatus>().HideSlider();
    }

    // fuinction to Change Soil Tile position to scene of clickig gameplay
    public void RepositionTile(GameObject Soil)
    {
        PositionMemory = Soil.transform.position;
        Soil.transform.position = new Vector3(-60, PositionMemory.y, 20);
        Soil.tag = "MovedSoil";
        Soil.GetComponent<MyObjectHolders>().ChangeTagToMoved();
        StartRotationOfSoil(Soil);
    }

    // Begining rotation of secound tile
    public void StartRotationOfSoil(GameObject Soil)
    {
        Soil.GetComponent<SoilRotation>().Should_Rotate = true;
    }

    // stop of soil tile rotation and returning it to it's previous position
    public void ResetSoilTile(GameObject Soil)
    {
        Soil.transform.position = new Vector3(PositionMemory.x, PositionMemory.y, PositionMemory.z);
        Soil.GetComponent<SoilRotation>().Should_Rotate = false;
        Soil.GetComponent<SoilRotation>().ResetState();
        Soil.tag = "SoilTile";
        Soil.GetComponent<MyObjectHolders>().UnchangeTag();
    }

    //Function to activate ShoppingMenu
    public void ActivateShopMenu()
    {
        ShopMenu.SetActive(true);
        NavigationButtons.SetActive(false);
    }

    //Function to deactivate ShoppingMenu
    public void DeActivateShopMenu()
    {
        
        ShopMenu.SetActive(false);
        NavigationButtons.SetActive(true);
    }
}
