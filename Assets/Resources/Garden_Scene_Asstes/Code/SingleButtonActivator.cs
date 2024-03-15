using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleButtonActivator : MonoBehaviour
{

    [SerializeField]
    Button buyButton;

    [SerializeField]
    int id;

    MoneyManager moneyManager;
    PricingSystemPlants pricingSystemPlants;
    MoneyManager.MoneyBalance moneyBalance;

    // Start is called before the first frame update
    void Start()
    {

        GameObject bank = GameObject.FindGameObjectWithTag("Bank");
        moneyManager = bank.GetComponent<MoneyManager>();
        pricingSystemPlants = bank.GetComponent<PricingSystemPlants>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyBalance = moneyManager.myBalance;

        Debug.Log(moneyBalance.moneyBalance);
    }

    void OnBecameInvisible()
    {
        Debug.Log("Object invisible");
    }

    void OnBecameVisible()
    {
        Debug.Log("Object visible");
    }

}
