using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAttributes : MonoBehaviour
{
    public UnityEngine.Vector3 myLocalScale;
    [SerializeField]
    string myIncomeValue;
    public BigInteger myIncome;

    void Awake()
    {
        myIncome = BigInteger.Parse(myIncomeValue);
    }
}
