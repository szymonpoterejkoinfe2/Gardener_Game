using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLogic : MonoBehaviour
{
    GameObject[] SoilHolder;
    GameObject SoilToCheck;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void validateSoilTile()
    {
        SoilToCheck = GameObject.FindGameObjectWithTag("MovedSoil");

        if (SoilToCheck.GetComponent<PlantCreator>().HavePlant == true)
        {

            //activate manager

        }

    }
}
