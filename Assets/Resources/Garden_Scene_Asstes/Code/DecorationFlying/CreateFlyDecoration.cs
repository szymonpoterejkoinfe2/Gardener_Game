using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFlyDecoration : MonoBehaviour
{


    public GameObject[] flyingCreatures;


    public void CreateFlyingCreature(int creature)
    {
        GameObject newCreature = Instantiate(flyingCreatures[creature], new Vector3(0, 0, 0), UnityEngine.Quaternion.identity, transform);
        newCreature.transform.localScale = new Vector3(5, 5, 5);
        newCreature.transform.localPosition = new Vector3(0, 0, 0);
    }
}
