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

    public bool nourished;

    void Awake()
    {
        myIncome = BigInteger.Parse(myIncomeValue);
    }

    private void Update()
    {
        if (nourished)
        {
            myIncome = BigInteger.Parse(myIncomeValue);
        }
        else {
            myIncome = 0;
        }
    }
}
