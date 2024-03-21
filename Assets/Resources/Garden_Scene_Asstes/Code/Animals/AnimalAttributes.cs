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

    public bool nourished;

    void Awake()
    {
        myIncome = BigInteger.Parse(myIncomeValue);
    }

    void Start()
    { 
    
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

        switch (animalEnvironment)
        {
            case environment.Farm:
                // To do: take haveFarmFood bool
                break;
            case environment.Forest:
                //To do: take haveForestFood bool
                break;
            case environment.Jungle:
                //To do: take haveJungleFood bool
                break;
            case environment.Arctic:
                //To do: take haveArcticFood bool
                break;
            case environment.Sky:
                //To do: take haveSkyFood bool
                break;


        }
    }
}
