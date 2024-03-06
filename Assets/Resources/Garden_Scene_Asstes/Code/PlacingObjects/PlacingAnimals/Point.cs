using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

    public bool haveAnimal = false;
    public Transform myTransform;
    public GameObject pointObject;
    public string soilID;
    public int pointID;

    [SerializeField]
    public environment pointEnvironment;

    [SerializeField]
    public animalSize pointAnimalSize;

    void Awake()
    {
        myTransform = gameObject.transform;
        pointObject = gameObject;
        GameObject soil = GetComponentInParent<ObjectHolder>().gameObject;
        soilID = soil.GetComponent<ObjectHolder>().uniqueId;
    }

}
