using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapOnTileDetector : MonoBehaviour
{
    public Rotation rotation;
    public SoilRotation soilRotation;
    public GameObject CameraOne;
    public GameObject CameraTwo;
    private GameObject Tile;
    Vector3 PositionMemory;
    private GameObject Bank,Cover;
    ulong Ballance, Price;


    // Start is called before the first frame update

    private void Awake()
    {
        CameraTwo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Bank = GameObject.FindGameObjectWithTag("Bank");
        Ballance = Bank.GetComponent<MoneyManager>().MoneyBallance;

        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            Vector3 touchPos = t.position;
           
            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "BadRockCover")
                {
                    Cover = hit.transform.gameObject;
                    Price = Cover.GetComponent<ObjectPrice>().MyPrice;

                    if (Ballance >= Price)
                    {
                        Destroy(Cover);
                        Bank.GetComponent<MoneyManager>().DecrementBallance(Price);
                    }
                }
                else if (hit.transform.name == "Soil")
                {
                    Tile = hit.transform.gameObject;


                        rotation.speed = 0;

                        // Reseting Groung Rotation
                        rotation.ResetState();

                        // Changing Soil Tile position to scene of clickig gameplay
                        RepositionTile(Tile);

                        // Swithcing to secound camera
                        ChangeToCameraTwo();

                    

                }
            }

        }

    }

    // function to switch to camera two
    private void ChangeToCameraTwo()
    {
        CameraOne.SetActive(false);
        CameraTwo.SetActive(true);
    }

    // function to switch to camera one
    private void ChangeToCameraOne()
    {
        CameraOne.SetActive(true);
        CameraTwo.SetActive(false);
        rotation.speed = 2;
        ResetSoilTile(Tile);
    }

    // fuinction to Change Soil Tile position to scene of clickig gameplay
    private void RepositionTile(GameObject Soil)
    {
        PositionMemory = Tile.transform.position;
        Tile.transform.position = new Vector3(-60, PositionMemory.y, 20);
        Tile.tag = "MovedSoil";
        
        StartRotationOfSoil(Tile);
    }

    // Begining rotation of secound tile
    private void StartRotationOfSoil(GameObject Soil)
    {
        Soil.GetComponent<SoilRotation>().Should_Rotate = true;
    }

    // stop of soil tile rotation and returning it to it's previous position
    private void ResetSoilTile(GameObject Soil)
    {
        Soil.transform.position = new Vector3(PositionMemory.x, PositionMemory.y, PositionMemory.z);
        Soil.GetComponent<SoilRotation>().Should_Rotate = false;
        Soil.GetComponent<SoilRotation>().ResetState();
        Tile.tag = "SoilTile";
    }

  

}
