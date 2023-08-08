using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public ulong MoneyBallance = 15;
    public TextMeshProUGUI BallanceDisplay;
    private GameObject[] Plants;
    private Vector3 TargetScale, BeginScale;

    // Update is called once per frame
    void Update()
    {

        if (MoneyBallance < 1000)
        {
            BallanceDisplay.text = MoneyBallance.ToString() + "$";
        }
        else if (MoneyBallance >= 1000 && MoneyBallance < 1000000)
        {
            double moneyDecimal = MoneyBallance / 1000.00;
            BallanceDisplay.text = moneyDecimal.ToString() + " Thousand $";
        }
        else if (MoneyBallance >= 1000000 && MoneyBallance < 1000000000)
        {
            double moneyDecimal = MoneyBallance / 1000000.00;
            BallanceDisplay.text = moneyDecimal.ToString() + " Milion $";
        }
        else if (MoneyBallance >= 1000000000 && MoneyBallance < 1000000000000)
        {
            double moneyDecimal = MoneyBallance / 1000000000.00;
            BallanceDisplay.text = moneyDecimal.ToString() + " Billion $";
        }
        else if (MoneyBallance >= 1000000000000 && MoneyBallance < 1000000000000000) 
        {
            double moneyDecimal = MoneyBallance / 1000000000000.00;
            BallanceDisplay.text = moneyDecimal.ToString() + " Trillion	$";
        }
        else if (MoneyBallance >= 1000000000000000 && MoneyBallance < 1000000000000000000)
        {
            double moneyDecimal = MoneyBallance / 1000000000000000.00;
            BallanceDisplay.text = moneyDecimal.ToString() + " Quadrillion $";
        }
        else if (MoneyBallance >= 1000000000000000000 && MoneyBallance < 1000000000000000000000)
        {
            double moneyDecimal = MoneyBallance / 1000000000000000000.00;
            BallanceDisplay.text = moneyDecimal.ToString() + " Quintillion $";
        }
        else if (MoneyBallance >= 1000000000000000000000 && MoneyBallance < 1000000000000000000000000)
        {
            double moneyDecimal = MoneyBallance / 1000000000000000000000.00;
            BallanceDisplay.text = moneyDecimal.ToString() + " Sextillion $";
        }
        else if (MoneyBallance >= 1000000000000000000000000 && MoneyBallance < 1000000000000000000000000000)
        {
            double moneyDecimal = MoneyBallance / 1000000000000000000000000.00;
            BallanceDisplay.text = moneyDecimal.ToString() + " Septillion $";
        }
        else if (MoneyBallance >= 1000000000000000000000000000 && MoneyBallance < 1000000000000000000000000000000)
        {
            double moneyDecimal = MoneyBallance / 1000000000000000000000000000.00;
            BallanceDisplay.text = moneyDecimal.ToString() + " Octillion $";
        }
        else if (MoneyBallance >= 1000000000000000000000000000000 && MoneyBallance < 1000000000000000000000000000000000)
        {
            double moneyDecimal = MoneyBallance / 1000000000000000000000000000000.00;
            BallanceDisplay.text = moneyDecimal.ToString() + " Nonillion $";
        }

        // Reward From Grown Plant
        Plants = GameObject.FindGameObjectsWithTag("Plant");

        BeginScale = new Vector3(0.003f, 0.003f, 0.003f);


        // Checking if any plant is fully grown if so incrementing money ballance
        foreach (GameObject plant in Plants)
        {

            TargetScale = new Vector3(plant.GetComponent<ObjectPrice>().ValueTarget[0] , plant.GetComponent<ObjectPrice>().ValueTarget[1], plant.GetComponent<ObjectPrice>().ValueTarget[2]);
            float Local = plant.transform.localScale.x;
            Local = Mathf.Round(Local * 100.0f) * 0.01f;

            float Target = TargetScale.x;
            //Target = Mathf.Round(Target * 1000.0f) * 0.001f;

            Debug.Log(Local.ToString() + " " + Target.ToString());

            if (Local >= Target && plant.GetComponent<ManagerLogic>().HaveManager == false)
            {
                
                IncrementBallance(plant.GetComponent<ObjectPrice>().GrownIncome * plant.GetComponent<Fertilizer>().Multiplicator);

                plant.transform.parent.transform.Find("Leafs").gameObject.GetComponent<ParticleSystem>().Play();

                plant.transform.localScale = BeginScale;

            }
            
        }

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
