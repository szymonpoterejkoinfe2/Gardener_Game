using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLogic : MonoBehaviour
{

    float timer = 0f;
    public float growTime = 10f;
    public bool haveManager = false;
    public int managerLevel = 1;
    SaveSystem saveManager;
    private GameObject bank;

    private void Awake()
    {
        saveManager = FindObjectOfType<SaveSystem>();
    }

    // Beginning of Scailing Coroutine
    public void StartGrowing(float timeFertilization)
    {
        haveManager = true;
        growTime = timeFertilization;
        StartCoroutine(GrowWithManager());
    }

    // Changing UpgradeTime
    public void UpgradeManager()
    {
        growTime = (growTime * 0.95f);
        managerLevel++;
        saveManager.SavePlantPricing();
    }
    
    // Scaling plant object with time
    private IEnumerator GrowWithManager()
    {

        Vector3 StartScale = new Vector3(0f, 0f, 0f);
        Vector3 MaxScale = new Vector3((gameObject.GetComponent<ObjectCharacteristics>().valueTarget.x), (gameObject.GetComponent<ObjectCharacteristics>().valueTarget.y), (gameObject.GetComponent<ObjectCharacteristics>().valueTarget.z));
        bank = GameObject.FindGameObjectWithTag("Bank");

        // Looping when active manager
        while (haveManager)
        {
           // 
            {

                while (timer <= growTime)
                {
                    // Scaling plant only when hydrated
                    if (gameObject.transform.parent.GetComponent<HydrationLogic>().hydrated == true)
                    {
                        transform.localScale = Vector3.Lerp(StartScale, MaxScale, timer / growTime);
                        timer += Time.deltaTime;
                    }
                    
                    yield return null;
                }

                //Incrementing money balance for fully grown plant
                bank.GetComponent<MoneyManager>().myBalance.IncrementBalance(bank.GetComponent<PricingSystemPlants>().plantPrices.GetObjGrownIncome(gameObject.GetComponent<ObjectCharacteristics>().myId) * gameObject.GetComponent<Fertilizer>().Multiplicator);
                saveManager.SaveMoneyBalance();
                
                // Leafs particle effect
                if (growTime > 0.5f)
                {
                    gameObject.GetComponent<PlantGrown>().PlayParticle();
                }
                timer = 0;

            }
            

        }
    }
}
