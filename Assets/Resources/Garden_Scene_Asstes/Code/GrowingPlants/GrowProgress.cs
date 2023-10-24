using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowProgress : MonoBehaviour
{

    public Slider progressSlider;
    GameObject tile, plant;

    // Update is called once per frame
    void Update()
    {

        if (tile = GameObject.FindGameObjectWithTag("MovedSoil"))
        {
            try
            {
                plant = tile.transform.Find("Plant").gameObject;
                ObjectCharacteristics characteristics = plant.GetComponent<ObjectCharacteristics>();
                progressSlider.maxValue = characteristics.valueTarget.x;
                progressSlider.value = plant.transform.localScale.x;
            }
            catch
            { }

        }
        else {
            Debug.Log("No plant Found");
        }

    }
}
