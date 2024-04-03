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

    [SerializeField]
    Category category;

    GameObject bank;
    MoneyManager moneyManager;
    HydrationPricing pricingHydration;
    DecorationPricing decorationPricing;
    MoneyManager.MoneyBalance moneyBalance;

    // Start is called before the first frame update
    void Start()
    {
       bank = GameObject.FindGameObjectWithTag("Bank");
    }

    // Update is called once per frame
    void Update()
    {
        moneyManager = bank.GetComponent<MoneyManager>();
        moneyBalance = moneyManager.myBalance;

        if (category == Category.Hydration)
        {
            pricingHydration = bank.GetComponent<HydrationPricing>();

            if (pricingHydration.prices[id] > moneyBalance.moneyBalance)
            {
                buyButton.interactable = false;
            }
            else
            {
                buyButton.interactable = true;
            }
        }

        else if (category == Category.Decoration)
        {
            decorationPricing = bank.GetComponent<DecorationPricing>();

            if (decorationPricing.prices[id] > moneyBalance.moneyBalance)
            {
                buyButton.interactable = false;
            }
            else
            {
                buyButton.interactable = true;
            }
        }
      

    }

    enum Category
    {
        Hydration,
        Decoration
    }
}

