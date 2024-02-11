using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBirdEmitter : MonoBehaviour
{
    public GameObject badBirdPrefab;
    public Transform[] pointsA, pointsB;
    public AudioSource birdSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Emitt());
    }

    // Coroutine which tries to emitt bad bird if moved soil is found 
    IEnumerator Emitt()
    {
        while (true)
        {
            yield return new WaitForSeconds(25);

            if (GameObject.FindGameObjectWithTag("MovedSoil") != null && !GameObject.FindGameObjectWithTag("MovedSoil").GetComponent<MyObjectHolders>().haveScarecrow)
            {

                GameObject badBird;

                int beginSide = Random.Range(1, 3); //Selection of random number - determining emission side 

                int shouldEmitt = Random.Range(1, 6); //Selection of random number - determinig if should emitt (probability of emitting: 20%)

                // Logic for instantiotion of bad bird object
                switch (beginSide)
                {
                    case 1:

                        if (shouldEmitt == 2)
                        {
                            badBird = Instantiate(badBirdPrefab, pointsA[Random.Range(0, 3)]);
                            badBird.GetComponent<BadBirdFly>().StartMoving(pointsB[Random.Range(0, 3)]);
                            birdSound.Play();
                        }
                        break;
                    case 2:

                        if (shouldEmitt == 2)
                        {
                            badBird = Instantiate(badBirdPrefab, pointsB[Random.Range(0, 3)]);
                            badBird.GetComponent<BadBirdFly>().StartMoving(pointsA[Random.Range(0, 3)]);
                            birdSound.Play();
                        }
                        break;
                }

            }

        }

    }

}
