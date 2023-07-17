using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDestroyer : MonoBehaviour
{
    public float holdDuration = 1f;
    float savedHoldDuration;
    private GameObject Plant;
    public GameObject Buttons;
    GameObject Tile;
    private GameObject Bank;
    ulong Ballance, Refund;

    // Start is called before the first frame update
    void Start()
    {
        savedHoldDuration = holdDuration;
        Buttons.SetActive(false);
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
                if (hit.transform.name == "Plant" && t.phase == TouchPhase.Stationary)
                {
                    float remainingDuration = holdDuration -= Time.deltaTime;
                    Plant = hit.transform.gameObject;
                    Tile = Plant.transform.parent.gameObject;
                    if (holdDuration <= 0 && (Ballance >= 15))
                    {
                        Buttons.SetActive(true);
                        Refund = Plant.GetComponent<ObjectPrice>().ReturnFromDestruction;
                    }
                }
            }
        }
    }

    //Destroy Plant
    public void DestroyPlant()
    {
        Destroy(Plant);
        Tile.GetComponent<PlantCreator>().HavePlant = false;
        HideButtons();
        Bank.GetComponent<MoneyManager>().IncrementBallance(Refund);
    }

    //Deactivates buttons to destroy plant
    public void HideButtons()
    {
        Buttons.SetActive(false);
        holdDuration = savedHoldDuration;
    }
}
