using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Numerics;

public class MoneyManager : MonoBehaviour
{

    public class MoneyBalance
    {

        public BigInteger moneyBalance = 15;

        public MoneyBalance(BigInteger value)
        {
            moneyBalance = value;
        }

        //Decrement Money amount after purchase
        public void DecrementBalance(BigInteger amount)
        {
            moneyBalance -= amount;
            //Debug.Log(moneyToDisplay);
        }
        //Increment Money amount after purchase
        public void IncrementBalance(BigInteger amount)
        {
           
            moneyBalance += amount;
            //  Debug.Log(moneyToDisplay);
        }
    }

    public TextMeshProUGUI balanceDisplay;
    public MoneyBalance  myBalance;

    public MoneyManager()
    {
        myBalance = new MoneyBalance(15);
    }


    // Update is called once per frame
    void Update()
    {

        DisplayMoneyValue(myBalance.moneyBalance, balanceDisplay);

    }

    //Loading previously saved MoneyBalance
    public void LoadData(MoneyBalance dataToLoad)
    {
        myBalance = dataToLoad;
    }

    // Displaying money amonut with proper prefix
    public void DisplayMoneyValue(BigInteger moneyToDisplay, TextMeshProUGUI displayingText)
    {
        if (moneyToDisplay < 1000)
        {
            displayingText.text = moneyToDisplay.ToString() + "$";
        }
        else if (moneyToDisplay >= 1000 && moneyToDisplay < 1000000)
        {
            double moneyDecimal = (double)(moneyToDisplay / 100) / 10.0;
            displayingText.text = moneyDecimal.ToString() + " Thousand $";
        }
        else if (moneyToDisplay >= 1000000 && moneyToDisplay < 1000000000)
        {
            double moneyDecimal = (double)(moneyToDisplay / 100000) / 10.0;
            displayingText.text = moneyDecimal.ToString() + " Milion $";
        }
        else if (moneyToDisplay >= 1000000000 && moneyToDisplay < 1000000000000)
        {
            double moneyDecimal = (double)(moneyToDisplay / 10000000) / 10.0;
            displayingText.text = moneyDecimal.ToString() + " Billion $";
        }
        else if (moneyToDisplay >= 1000000000000 && moneyToDisplay < 1000000000000000)
        {
            double moneyDecimal = (double)(moneyToDisplay / 100000000000) / 10.0;
            displayingText.text = moneyDecimal.ToString() + " Trillion	$";
        }
        else if (moneyToDisplay >= 1000000000000000 && moneyToDisplay < 1000000000000000000)
        {
            double moneyDecimal = (double)(moneyToDisplay / 100000000000000) / 10.0;
            displayingText.text = moneyDecimal.ToString() + " Quadrillion $";
        }
        else if (moneyToDisplay >= 1000000000000000000 && moneyToDisplay < BigInteger.Parse("1000000000000000000000")) 
        {
            double moneyDecimal = (double)(moneyToDisplay / 100000000000000000) / 10.0;
            displayingText.text = moneyDecimal.ToString() + " Quintillion $";
        }
        else if (moneyToDisplay >= BigInteger.Parse("1000000000000000000000") && moneyToDisplay < BigInteger.Parse("1000000000000000000000000"))
        {
            double moneyDecimal = (double)(moneyToDisplay / BigInteger.Parse("100000000000000000000"))/10.0;
            displayingText.text = moneyDecimal.ToString() + " Sextillion $";
        }
        else if (moneyToDisplay >= BigInteger.Parse(" 1000000000000000000000000") && moneyToDisplay < BigInteger.Parse("1000000000000000000000000000"))
        {
            double moneyDecimal = (double)(moneyToDisplay / BigInteger.Parse("100000000000000000000000"))/10.0;
            displayingText.text = moneyDecimal.ToString() + " Septillion $";
        }
        else if (moneyToDisplay >= BigInteger.Parse("1000000000000000000000000000") && moneyToDisplay < BigInteger.Parse("1000000000000000000000000000000"))
        {
            double moneyDecimal = (double)(moneyToDisplay / BigInteger.Parse("100000000000000000000000000")) / 10.0;
            displayingText.text = moneyDecimal.ToString() + " Octillion $";
        }
        else if (moneyToDisplay >= BigInteger.Parse("1000000000000000000000000000000") && moneyToDisplay < BigInteger.Parse("1000000000000000000000000000000000"))
        {
            double moneyDecimal = (double)(moneyToDisplay / BigInteger.Parse("100000000000000000000000000000")) / 10.0;
            displayingText.text = moneyDecimal.ToString() + " Nonillion $";
        }
    }

   
}
