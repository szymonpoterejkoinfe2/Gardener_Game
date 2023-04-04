using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAndTileManager : MonoBehaviour
{

    public GameObject CameraOne;
    public GameObject CameraTwo;
    public GameObject Buttons;
    public Rotation rotation;
    public Vector3 PositionMemory;


    private void Awake()
    {
        CameraTwo.SetActive(false);
        Buttons.SetActive(false);
    }


    // function to switch to camera two
    public void ChangeToCameraTwo()
    {
        CameraOne.SetActive(false);
        CameraTwo.SetActive(true);
        Buttons.SetActive(true);
    }

    // function to switch to camera one
    public void ChangeToCameraOne(GameObject Soil)
    {
        CameraOne.SetActive(true);
        CameraTwo.SetActive(false);
        Buttons.SetActive(false);
        rotation.speed = 2;
        ResetSoilTile(Soil);
    }

    // fuinction to Change Soil Tile position to scene of clickig gameplay
    public void RepositionTile(GameObject Soil)
    {
        PositionMemory = Soil.transform.position;
        Soil.transform.position = new Vector3(-60, PositionMemory.y, 20);
        Soil.tag = "MovedSoil";

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
    }
}
