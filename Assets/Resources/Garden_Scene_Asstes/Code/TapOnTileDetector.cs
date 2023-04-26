using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapOnTileDetector : MonoBehaviour
{
    public Rotation rotation;
    private GameObject Tile;
    private GameObject Bank,Cover;
    ulong Ballance, Price;
    public CameraAndTileManager CameraTileManager;

    // Start is called before the first frame update

   

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

                    //Debug.Log("Function1");
                    // Changing Soil Tile position to scene of clickig gameplay
                    CameraTileManager.RepositionTile(Tile);

                    //Debug.Log("Function2");
                    // Swithcing to secound camera
                    CameraTileManager.ChangeToCameraTwo();

                   

                }
            }

        }

    }

}
