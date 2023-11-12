using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    //Sending information that soil tile has Scarecrow decoration object
    void Start()
    {
        gameObject.GetComponentInParent<MyObjectHolders>().haveScarecrow = true;
    }

}
