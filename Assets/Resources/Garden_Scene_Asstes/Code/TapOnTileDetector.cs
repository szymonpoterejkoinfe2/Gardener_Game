using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TapOnTileDetector : MonoBehaviour
{
    public Rotation rotation;
    public GameObject ConfirmationWindow;
    private GameObject Tile;
    private GameObject Bank,Cover;
    ulong Ballance, Price;
    public CameraAndTileManager CameraTileManager;
    private bool NotAsking;
    public TextMeshProUGUI PriceTxt;
    // Start is called before the first frame update
    private void Awake()
    {
        ConfirmationWindow.SetActive(false);
        NotAsking = true;
    }


    // Update is called once per frame
    void Update()
    {
        Bank = GameObject.FindGameObjectWithTag("Bank");
 
        Ballance = Bank.GetComponent<MoneyManager>().MoneyBallance;

        if (Input.touchCount == 1 && NotAsking == true)
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

                    ConfirmationWindow.SetActive(true);
                    NotAsking = false;
                    PriceTxt.text = Cover.GetComponent<ObjectPrice>().MyPrice.ToString();
  
                }
                else if (hit.transform.name == "Soil" && NotAsking == true)
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

    //Closing QuestionWindow
    public void CloseQuestionWindow()
    {
        ConfirmationWindow.SetActive(false);
        StartCoroutine(Delay());

    }

    //Closing QuestionWindow with expansion
    public void WantToExpand()
    {
        if (Ballance >= Price)
        {
            Destroy(Cover);
            Bank.GetComponent<MoneyManager>().DecrementBallance(Price);
            CloseQuestionWindow();
        }
    }

    //Making Delay
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        NotAsking = true;
    }

}
