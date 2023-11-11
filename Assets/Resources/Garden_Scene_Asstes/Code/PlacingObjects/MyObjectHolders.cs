using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjectHolders : MonoBehaviour
{
    public GameObject[] myObjectHolders;
    public Vector3 myPosition;
    public bool haveScarecrow = false;
    public void Awake()
    {
        myPosition = gameObject.transform.localPosition;
    }

    public void ChangeTagToMoved()
    {
        foreach (GameObject holder in myObjectHolders)
        {
            holder.tag = "MovedObjectHolder";
        }

    }

    public void UnchangeTag()
    {
        foreach (GameObject holder in myObjectHolders)
        {
            holder.tag = "ObjectHolder";
        }
    }
}
