using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDestroyer : MonoBehaviour
{
    public float holdDuration = 1f;
    float savedHoldDuration;
    private GameObject Plant;
    // Start is called before the first frame update
    void Start()
    {
        savedHoldDuration = holdDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            Vector3 touchPos = t.position;

            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Plant" && t.phase == TouchPhase.Stationary)
                {
                    float remainingDuration = holdDuration -= Time.deltaTime;
                    Plant = hit.transform.gameObject;
                    var Tile = Plant.transform.parent.gameObject;
                    if (holdDuration <= 0)
                    {
                       Tile.GetComponent<PlantCreator>().HavePlant = false;
                       Destroy(hit.transform.gameObject);
                       holdDuration = savedHoldDuration;
                    }
                }
            }
        }
    }
}
