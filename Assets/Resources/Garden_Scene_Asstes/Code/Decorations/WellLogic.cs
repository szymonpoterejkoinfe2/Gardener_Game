using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellLogic : MonoBehaviour
{
    void Start()
    {
       gameObject.GetComponentInParent<HydrationLogic>().haveWell = true;
    }

}
