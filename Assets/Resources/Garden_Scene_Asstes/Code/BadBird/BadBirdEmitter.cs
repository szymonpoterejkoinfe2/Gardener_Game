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

    // Coroutine which tryes to emitt bad bird if moved soil is found 
    IEnumerator Emitt()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);

            if (GameObject.FindGameObjectWithTag("MovedSoil") != null)
            {

                GameObject badBird;

                int beginSide = Random.Range(1, 3);

                int shouldEmitt = Random.Range(1, 6);

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
