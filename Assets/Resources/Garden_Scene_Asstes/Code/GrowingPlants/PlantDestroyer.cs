using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class PlantDestroyer : MonoBehaviour
{
    public float holdDuration = 1f;
    float savedHoldDuration;
    private GameObject plant, bank, tile;
    public GameObject buttons;
    BigInteger ballance, refund;
    private SaveSystem saveManager;

    // Start is called before the first frame update
    void Start()
    {
        savedHoldDuration = holdDuration;
        buttons.SetActive(false);
        saveManager = GameObject.FindObjectOfType<SaveSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        bank = GameObject.FindGameObjectWithTag("Bank");
        ballance = bank.GetComponent<MoneyManager>().myBalance.moneyBalance;

        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            UnityEngine.Vector3 touchPos = t.position;

            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Plant" && t.phase == TouchPhase.Stationary)
                {
                    float remainingDuration = holdDuration -= Time.deltaTime;
                    plant = hit.transform.gameObject;
                    tile = plant.transform.parent.gameObject;
                    if (holdDuration <= 0 && (ballance >= 15))
                    {
                        buttons.SetActive(true);
                        refund = bank.GetComponent<PricingSystemPlants>().plantPrices.GetObjDstructionReturn(plant.GetComponent<ObjectCharacteristics>().myId);
                    }
                }
            }
        }
    }

    //Destroy Plant
    public void DestroyPlant()
    {
        Destroy(plant);
        tile.GetComponent<PlantCreator>().havePlant = false;
        HideButtons();
        bank.GetComponent<MoneyManager>().myBalance.IncrementBalance(refund);
        saveManager.SaveSoil();
        saveManager.SaveMoneyBalance();

    }

    //Deactivates buttons to destroy plant
    public void HideButtons()
    {
        buttons.SetActive(false);
        holdDuration = savedHoldDuration;
    }
}
