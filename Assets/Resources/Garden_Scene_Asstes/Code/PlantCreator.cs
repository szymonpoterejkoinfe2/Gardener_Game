using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCreator : MonoBehaviour
{
    public GameObject[] plants;
    public bool HavePlant = false;
    public float FixedScale = 1;
    public GameObject parent;

    // Function which Generates new plant game object based on plants prefabs.
    public void Generate_Plant(int PlantId)
    {
        if (HavePlant == false)
        {
            GameObject new_plant = Instantiate(plants[PlantId], new Vector3(0, 0, 0), Quaternion.identity, transform);
            new_plant.name = "Plant";
            new_plant.tag = "Plant";
            new_plant.transform.localPosition = new Vector3(0, 1, 0);
            new_plant.transform.localScale = new Vector3(FixedScale / parent.transform.localScale.x, FixedScale / parent.transform.localScale.y, FixedScale / parent.transform.localScale.z);
            HavePlant = true;
        }
    }
 
}
