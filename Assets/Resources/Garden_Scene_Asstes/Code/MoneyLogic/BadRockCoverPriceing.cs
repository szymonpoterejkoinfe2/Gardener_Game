using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class BadRockCoverPriceing : MonoBehaviour
{
    // Class stroring all information to save to file
    public class CoverPrices
    {
        public BigInteger[] objectPrice;

        //Constructor
        public CoverPrices(BigInteger[] objPrc)
        {
            objectPrice = objPrc;
        }
        
        // Getter
        public BigInteger ReturnMyPrice(int objectId)
        {
            return objectPrice[objectId];
        }
       
    }

    // Creating new CoverPrices Object
    BigInteger[] priceArr = { 50, 100, 1000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 1450, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public CoverPrices myCoverPrices;
    // Constructor
    public BadRockCoverPriceing()
    {
        myCoverPrices = new CoverPrices(priceArr);
    }
    
    // Loading previously saved data
    public void LoadData(CoverPrices pricesToLoad)
    {
        myCoverPrices = pricesToLoad;
    }
}
