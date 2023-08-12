using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;

public class TapOnTileDetector : MonoBehaviour
{
    public Rotation rotation;
    public GameObject ConfirmationWindow;
    private GameObject tile, bank,cover;
    BigInteger balance, price;
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
        bank = GameObject.FindGameObjectWithTag("Bank");
 
        balance = bank.GetComponent<MoneyManager>().moneyBalance;


        if (Input.touchCount == 1 && NotAsking == true)
        {
            Touch t = Input.GetTouch(0);
            UnityEngine.Vector3 touchPos = t.position;
           
            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "BadRockCover")
                {
                    cover = hit.transform.gameObject;
                    price = bank.GetComponent<BadRockCoverPriceing>().ReturnMyPrice(cover.GetComponent<ObjectCharacteristics>().myId);

                    ConfirmationWindow.SetActive(true);
                    NotAsking = false;

                    bank.GetComponent<MoneyManager>().DisplayMoneyValue(price, PriceTxt);
                }
                else if (hit.transform.name == "Soil" && NotAsking == true)
                {
                    tile= hit.transform.gameObject;

                    rotation.speed = 0;

                    // Reseting Groung Rotation
                    rotation.ResetState();

                    //Debug.Log("Function1");
                    // Changing Soil tileposition to scene of clickig gameplay
                    CameraTileManager.RepositionTile(tile);

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
        if (balance >= price)
        {
            Destroy(cover);
            bank.GetComponent<MoneyManager>().DecrementBalance(price);
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
