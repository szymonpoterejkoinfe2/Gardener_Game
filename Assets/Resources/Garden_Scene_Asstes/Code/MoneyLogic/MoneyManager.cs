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
        BallanceDisplay.text = MoneyBallance.ToString() + "$";

        // Reward From Grown Plant
        Plants = GameObject.FindGameObjectsWithTag("Plant");

        BeginScale = new Vector3(0.003f, 0.003f, 0.003f);

        // Checking if any plant is fully grown if so incrementing money ballance
        foreach (GameObject plant in Plants)
        {
            TargetScale = new Vector3(plant.GetComponent<ObjectPrice>().ValueTarget[0], plant.GetComponent<ObjectPrice>().ValueTarget[1], plant.GetComponent<ObjectPrice>().ValueTarget[2]);
            float Local = plant.transform.localScale.magnitude;
            Local = Mathf.Round(Local * 1000.0f) * 0.001f;

            float Target = TargetScale.magnitude;
            Target = Mathf.Round(Target * 1000.0f) * 0.001f;

            if (Local >= Target)
            {
                MoneyBallance += plant.GetComponent<ObjectPrice>().GrownIncome;
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
