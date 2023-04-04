using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlant : MonoBehaviour
{
    GameObject Plant,Soil;
    Vector3 ScaleValue,TargetScale;
    float Multiplyer = 1;
    public bool CanGrow = true;
    public  float[]  ValueTarget;

    // Start is called before the first frame update
    void Start()
    {
        TargetScale = new Vector3(ValueTarget[0], ValueTarget[1], ValueTarget[2]);
        ScaleValue = new Vector3(0.002f, 0.01f, 0.002f);
        

    }
    
    // Function Scale Plant GameObject to imitate Growth;
    public void Grow(int TouchCount)
    {
        Soil = GameObject.FindGameObjectWithTag("MovedSoil");
        if (Soil.GetComponent<PlantCreator>().HavePlant == true && CanGrow)
        {
            Plant = GameObject.FindGameObjectWithTag("Plant");
            Plant.transform.localScale += TouchCount * (ScaleValue * Multiplyer);
            Debug.Log("Growing");

            if (Plant.transform.localScale.magnitude >= TargetScale.magnitude)
            {
                CanGrow = false;
                Debug.Log("Grown");
            }
        }

       
    }
}
