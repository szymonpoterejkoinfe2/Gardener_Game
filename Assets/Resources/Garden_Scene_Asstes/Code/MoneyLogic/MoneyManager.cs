using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public ulong MoneyBallance = 15;
    public TextMeshProUGUI BallanceDisplay;



    // Update is called once per frame
    void Update()
    {
        BallanceDisplay.text = MoneyBallance.ToString() + "$";
       
    }

    //Decrement Money amount after purchase
    public void DecrementBallance(ulong amount)
    {
        MoneyBallance = MoneyBallance - amount;
        //Debug.Log(MoneyBallance);
    }
    //Increment Money amount after purchase
    public void IncrementBallance(ulong amount)
    {
        MoneyBallance = MoneyBallance + amount;
      //  Debug.Log(MoneyBallance);
    }
}
