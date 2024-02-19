using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjectHolders : MonoBehaviour
{
    public Vector3 myPosition;
    public bool haveScarecrow = false;
    public Dictionary<string, GameObject> myObjectHolders;

    [SerializeField]
    NewDictionary newDictionary;

    public void Awake()
    {
        myPosition = gameObject.transform.localPosition;
        myObjectHolders = newDictionary.ToDictionary();
    }

}
