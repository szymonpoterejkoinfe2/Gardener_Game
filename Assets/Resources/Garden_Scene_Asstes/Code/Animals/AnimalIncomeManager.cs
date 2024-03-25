using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalIncomeManager : MonoBehaviour
{
    MoneyManager moneyManager;
    AnimalAttributes[] animals;

    private void Start()
    {
        moneyManager = GetComponent<MoneyManager>();

        StartCoroutine(collectIncome(60f));
    }

    private AnimalAttributes[] FindAnimals()
    {
        return FindObjectsOfType<AnimalAttributes>();
    }

    private IEnumerator collectIncome(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            animals = FindAnimals();
            if (animals.Length > 0)
            {
                BigInteger incomeFromAnimals = 0;
                foreach (AnimalAttributes animal in animals)
                {
                    incomeFromAnimals += animal.myIncome;
                }
                //Debug.Log("Animal income added: " + incomeFromAnimals.ToString());
                moneyManager.myBalance.IncrementBalance(incomeFromAnimals);
            }
        }
    }
}
