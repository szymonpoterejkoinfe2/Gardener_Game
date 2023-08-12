using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class BadRockCoverPriceing : MonoBehaviour
{
    public BigInteger[] objectPrice  = {50,500,1000,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

    public BigInteger ReturnMyPrice(int objectId)
    {
        return objectPrice[objectId];
    }
}
