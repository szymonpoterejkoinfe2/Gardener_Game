using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFlyDecoration : MonoBehaviour
{


    public GameObject[] flyingCreatures;
    public int[] creaturesQuantity = {0,0};

    public void CreateFlyingCreature(int creature)
    {
        creaturesQuantity[creature] += 1;
        GameObject newCreature = Instantiate(flyingCreatures[creature], new Vector3(0, 0, 0), UnityEngine.Quaternion.identity, transform);
        newCreature.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        newCreature.transform.localPosition = new Vector3(0, 0, 0);
    }
}
