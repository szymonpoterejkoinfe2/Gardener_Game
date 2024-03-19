using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HydrationPricing : MonoBehaviour
{
   [SerializeField]
   List<string> pricesToParse = new List<string>();

    public List<BigInteger> prices = new List<BigInteger>();

    private void Awake()
    {
        foreach (string priceToParse in pricesToParse)
        {
            prices.Add(BigInteger.Parse(priceToParse));
        }
    }


}