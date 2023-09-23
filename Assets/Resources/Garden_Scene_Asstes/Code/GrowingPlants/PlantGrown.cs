using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrown : MonoBehaviour
{
    float xObjectScale, xTargetScale;
    GameObject bank;
    Vector3 beginScale;

    // Start is called before the first frame update
    void Start()
    {
        beginScale = new Vector3(0.003f, 0.003f, 0.003f);
        xTargetScale = gameObject.GetComponent<ObjectCharacteristics>().valueTarget[0];

        bank = GameObject.FindGameObjectWithTag("Bank");
    }

    // Update is called once per frame
    void Update()
    {

        xObjectScale = gameObject.transform.localScale.x;

        // Checking if plant is >= than targeted plant size
        if (xObjectScale >= xTargetScale && gameObject.GetComponent<ManagerLogic>().haveManager == false)
        {
            //Debug.Log("KONIEC KWIAT");

            bank.GetComponent<MoneyManager>().myBalance.IncrementBalance(bank.GetComponent<PricingSystemPlants>().objectGrownIncome[gameObject.GetComponent<ObjectCharacteristics>().myId] * gameObject.GetComponent<Fertilizer>().Multiplicator);

            gameObject.transform.parent.transform.Find("Leafs").gameObject.GetComponent<ParticleSystem>().Play();

            gameObject.transform.localScale = beginScale;
        }
    }
}
