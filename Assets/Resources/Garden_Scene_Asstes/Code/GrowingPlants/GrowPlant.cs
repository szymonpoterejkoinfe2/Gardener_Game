using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlant : MonoBehaviour
{
    GameObject Plant, Soil, Bank;
    ParticleSystem Leafs;
    Vector3 ScaleValue,TargetScale;
    float Multiplyer = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        
        ScaleValue = new Vector3(0.002f, 0.01f, 0.002f);

    }
    void Update()
    {
        Soil = GameObject.FindGameObjectWithTag("MovedSoil");
        Bank = GameObject.FindGameObjectWithTag("Bank");
    }

    // Function Scale Plant GameObject to imitate Growth;
    public void Grow(int TouchCount)
    {
        if (Soil.GetComponent<PlantCreator>().HavePlant == true)
        {
            Plant = Soil.transform.Find("Plant").gameObject;

            TargetScale = new Vector3(Plant.GetComponent<ObjectPrice>().ValueTarget[0], Plant.GetComponent<ObjectPrice>().ValueTarget[1], Plant.GetComponent<ObjectPrice>().ValueTarget[2]);
            if (Plant.GetComponent<ManagerLogic>().HaveManager == false)
            {
                Plant.transform.localScale += TouchCount * (ScaleValue * Multiplyer);
            }
        }
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
