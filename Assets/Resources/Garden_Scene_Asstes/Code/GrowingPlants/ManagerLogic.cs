using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLogic : MonoBehaviour
{

    GameObject cameraObject;
    float timer = 0f;
    public float growTime = 10f;
    public bool haveManager = false;

    private GameObject bank;

    // Beginning of Scailing Coroutine
    public void StartGrowing()
    {
        haveManager = true;
        StartCoroutine(GrowWithManager());
        
    }

    // Changing UpgradeTime
    public void UpgradeManager()
    {
        growTime = (growTime * 0.95f);
    }


    // Scaling plant object with time
    private IEnumerator GrowWithManager()
    {
        cameraObject = GameObject.Find("Camera");
        Vector3 StartScale = new Vector3(0f, 0f, 0f);
        Vector3 MaxScale = new Vector3((gameObject.GetComponent<ObjectCharacteristics>().valueTarget[0]), (gameObject.GetComponent<ObjectCharacteristics>().valueTarget[1]), (gameObject.GetComponent<ObjectCharacteristics>().valueTarget[2]));
        bank = GameObject.FindGameObjectWithTag("Bank");

        while (haveManager)
        {
            while (timer <= growTime)
            {
                transform.localScale = Vector3.Lerp(StartScale, MaxScale, timer / growTime);
                timer += Time.deltaTime;
                yield return null;
            }
            bank.GetComponent<MoneyManager>().myBalance.IncrementBalance(bank.GetComponent<PricingSystemPlants>().objectGrownIncome[gameObject.GetComponent<ObjectCharacteristics>().myId] * gameObject.GetComponent<Fertilizer>().Multiplicator);

            timer = 0;

        }
    }
}
