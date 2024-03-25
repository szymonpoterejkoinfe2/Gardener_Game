using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public string soilTileID;
        
    private bool nourished;
    private FoodManager foodManager;

    void Awake()
    {
        myIncome = BigInteger.Parse(myIncomeValue);
        foodManager = FindObjectOfType<FoodManager>();
    }

    void Start()
    {
        
    }

    private void Update()
    {
        if (foodManager.GetFoodStatus(soilTileID, animalEnvironment))
        {
            myIncome = BigInteger.Parse(myIncomeValue);
        }
        else
        {
            myIncome = 0;
        }

    }
}
