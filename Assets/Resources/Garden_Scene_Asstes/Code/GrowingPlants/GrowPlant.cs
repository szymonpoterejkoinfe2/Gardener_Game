using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlant : MonoBehaviour
{
    GameObject Plant,Soil,Bank;
    ParticleSystem Leafs;
    Vector3 ScaleValue,TargetScale, BeginnScale;
    float Multiplyer = 1;


    public  float[]  ValueTarget;

    // Start is called before the first frame update
    void Start()
    {
        Bank = GameObject.FindGameObjectWithTag("Bank");
        TargetScale = new Vector3(ValueTarget[0], ValueTarget[1], ValueTarget[2]);
        ScaleValue = new Vector3(0.002f, 0.01f, 0.002f);
        BeginnScale = new Vector3(0.003f, 0.003f, 0.003f);

    }
    void Update()
    {
        Soil = GameObject.FindGameObjectWithTag("MovedSoil");
        
    }

    // Function Scale Plant GameObject to imitate Growth;
    public void Grow(int TouchCount)
    {
        if (Soil.GetComponent<PlantCreator>().HavePlant == true)
        {
            Plant = Soil.transform.Find("Plant").gameObject;

            if (Plant.GetComponent<ManagerLogic>().HaveManager == false)
            {

                Plant.transform.localScale += TouchCount * (ScaleValue * Multiplyer);
                Debug.Log("Growing");

                if (Plant.transform.localScale.magnitude >= TargetScale.magnitude)
                {
                    PlantFullyGrown();
                }
            }
        }

       
    }

    //Function to generate particle and incrrment ballance when plant is fully grown
    public void PlantFullyGrown()
    {
        Leafs = Soil.transform.Find("Leafs").gameObject.GetComponent<ParticleSystem>();

        Bank.GetComponent<MoneyManager>().IncrementBallance(Plant.GetComponent<ObjectPrice>().GrownIncome);

        Leafs.Play();

        Plant.transform.localScale = BeginnScale;
    }


    // Upgrading Plant to earn more on every sold flower.
    public void UpgradePlant()
    {
        if (Soil.GetComponent<PlantCreator>().HavePlant == true)
        {
            Plant = Soil.transform.Find("Plant").gameObject;
            if (Bank.GetComponent<MoneyManager>().MoneyBallance >= Plant.GetComponent<ObjectPrice>().UpgradeCost)
            {
                Bank.GetComponent<MoneyManager>().DecrementBallance(Plant.GetComponent<ObjectPrice>().UpgradeCost);
                Plant.GetComponent<ObjectPrice>().ChangeGrowIncome();
            }
        }
    }

}
