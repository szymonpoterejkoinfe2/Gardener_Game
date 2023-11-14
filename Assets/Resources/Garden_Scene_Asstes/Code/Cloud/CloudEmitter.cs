using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEmitter : MonoBehaviour
{
    public GameObject[] cloudPrefabs;
    public Transform[] pointsA, pointsB;


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
            yield return new WaitForSeconds(10);

                GameObject cloud;

                int beginSide = Random.Range(1, 3); //Selection of random number - determining emission side 

                int shouldEmitt = Random.Range(1, 3); //Selection of random number - determinig if should emitt (probability of emitting: 33%)

                // Logic for instantiotion of bad bird object
                switch (beginSide)
                {
                    case 1:

                        if (shouldEmitt == 2)
                        {
                        cloud = Instantiate(cloudPrefabs[Random.Range(0,cloudPrefabs.Length)], pointsA[Random.Range(0, pointsA.Length)]);
                        cloud.GetComponent<CloudFly>().StartMoving(pointsB[Random.Range(0, pointsB.Length)]);

                        }
                        break;
                    case 2:

                        if (shouldEmitt == 2)
                        {
                        cloud = Instantiate(cloudPrefabs[Random.Range(0, cloudPrefabs.Length)], pointsB[Random.Range(0, pointsB.Length)]);
                        cloud.GetComponent<CloudFly>().StartMoving(pointsA[Random.Range(0, pointsA.Length)]);

                        }
                        break;
                }

        }

    }
}
