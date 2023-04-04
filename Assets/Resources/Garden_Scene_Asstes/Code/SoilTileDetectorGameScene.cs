using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilTileDetectorGameScene : MonoBehaviour
{
    private GameObject SoilTile;
    private Vector2 StartPosition, EndPosition;
    public CameraAndTileManager CameraTileManager;
    float remainingDuration;
    public float SwipeDuration = 0.10f;
    public GrowPlant Grower;


    // Update is called once per frame
    void Update()
    {
        SoilTile = GameObject.FindGameObjectWithTag("MovedSoil");

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StartPosition = Input.GetTouch(0).position;
            
        }
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            remainingDuration = SwipeDuration -= Time.deltaTime;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            EndPosition = Input.GetTouch(0).position;

            if (EndPosition.x < StartPosition.x && remainingDuration <= 0 && (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
               // Debug.Log("Swiped");
                CameraTileManager.ChangeToCameraOne(SoilTile);
                remainingDuration = 0.1f;
                SwipeDuration = 0.1f;
            }
            else {
                remainingDuration = 0.1f;
                SwipeDuration = 0.1f;
                Grower.Grow(Input.touchCount);
            }
           
        }

        
    }
    //Function to generate plant after clicking on button.
    public void PlacePlant(int PlantId)
    {
        SoilTile.GetComponent<PlantCreator>().Generate_Plant(PlantId);
    }
}
