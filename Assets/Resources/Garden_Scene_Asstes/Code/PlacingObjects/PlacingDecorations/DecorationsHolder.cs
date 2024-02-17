using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationsHolder : MonoBehaviour
{

    [SerializeField]
    NewDictionary newDict;

    [SerializeField]
    public Dictionary<string, GameObject> allDecorations;

    private void Awake()
    {
        allDecorations = newDict.ToDictionary();
    }
}

