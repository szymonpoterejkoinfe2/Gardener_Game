using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

    public bool haveAnimal = false;
    public Transform myTransform;
    public GameObject pointObject;
    public string soilID;


    void Awake()
    {
        myTransform = gameObject.transform;
        pointObject = gameObject;
        GameObject soil = GetComponentInParent<PlantCreator>().gameObject;
        soilID = soil.GetComponent<ObjectCharacteristics>().uniqueId;
    }

}
