using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAttributes : MonoBehaviour
{
    public UnityEngine.Vector3 myLocalScale;
    public UnityEngine.Vector3 myLocalPosition;
    [SerializeField]
    string myIncomeValue = "1";
    public BigInteger myIncome;

    [SerializeField]
    public animalSize animalSize;
    [SerializeField]
    public environment animalEnvironment;

    void Awake()
    {
        myIncome = BigInteger.Parse(myIncomeValue);
    }
}
