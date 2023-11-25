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
    public TextMeshProUGUI PriceTxt, prefix;
    SaveSystem saveManager;

    // Start is called before the first frame update
    private void Awake()
    {
        ConfirmationWindow.SetActive(false);
        NotAsking = true;
        saveManager = GameObject.FindObjectOfType<SaveSystem>();
    }


    // Update is called once per frame
    void Update()
    {
        bank = GameObject.FindGameObjectWithTag("Bank");
 
        balance = bank.GetComponent<MoneyManager>().myBalance.moneyBalance;


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
                    price = bank.GetComponent<BadRockCoverPriceing>().myCoverPrices.ReturnMyPrice(cover.GetComponent<ObjectCharacteristics>().myId);

                    ConfirmationWindow.SetActive(true);
                    NotAsking = false;

                    bank.GetComponent<MoneyManager>().DisplayMoneyValue(price, PriceTxt,prefix);
                }
                else if (hit.transform.name == "Soil" && NotAsking == true)
                {
                    tile = hit.transform.gameObject;

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
            GameObject.FindGameObjectWithTag("CoverDestroyer").GetComponent<CoverDestroyer>().myDestroyedCovers.addToDestroyed(cover.GetComponent<ObjectCharacteristics>().uniqueId);
            Destroy(cover);
            bank.GetComponent<MoneyManager>().myBalance.DecrementBalance(price);
            CloseQuestionWindow();
            saveManager.SaveBadRockCovers();
        }
    }

    //Making Delay
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        NotAsking = true;
    }

}
