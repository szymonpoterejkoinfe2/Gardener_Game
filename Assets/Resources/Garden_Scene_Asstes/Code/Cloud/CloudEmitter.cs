using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEmitter : MonoBehaviour
{
    public GameObject[] cloudPrefabs;
    public Transform[] pointsA, pointsB;
    private int currentCloudQuantity = 0;
    private const int maxCloudQuantity = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EmittCloud());
    }

    // Coroutine which tries to emitt bad bird if moved soil is found 
    IEnumerator EmittCloud()
    {
        while (true)
        {
            Debug.Log("currentCloudQuantity:" + currentCloudQuantity.ToString());

            yield return new WaitForSeconds(10);
            if (Camera.main.name == "MainCamera" && currentCloudQuantity <= maxCloudQuantity)
            {
                GameObject cloud;

                int beginSide = Random.Range(1, 3); //Selection of random number - determining emission side 

                int shouldEmitt = Random.Range(1, 3); //Selection of random number - determinig if should emitt (probability of emitting: 33%)

                switch (beginSide)
                {
                    case 1:

                        if (shouldEmitt == 2)
                        {
                            cloud = Instantiate(cloudPrefabs[Random.Range(0, cloudPrefabs.Length)], pointsA[Random.Range(0, pointsA.Length)]);
                            cloud.GetComponent<CloudFly>().StartMoving(pointsB[Random.Range(0, pointsB.Length)]);
                            currentCloudQuantity++;
                        }
                        break;
                    case 2:

                        if (shouldEmitt == 2)
                        {
                            cloud = Instantiate(cloudPrefabs[Random.Range(0, cloudPrefabs.Length)], pointsB[Random.Range(0, pointsB.Length)]);
                            cloud.GetComponent<CloudFly>().StartMoving(pointsA[Random.Range(0, pointsA.Length)]);
                            currentCloudQuantity++;
                        }
                        break;
                   
                }

            }

        }

    }

    public void CloudDestroyed()
    {
        if (currentCloudQuantity > 0)
        {
            currentCloudQuantity--;
        }
        
    }
}
