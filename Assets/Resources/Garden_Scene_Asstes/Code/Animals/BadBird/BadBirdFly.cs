using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BadBirdFly : MonoBehaviour
{
    public float speed = 1f;
    Transform targetPosition;
    float distance;
    bool canMove = false;
    public GameObject particle;
    private SaveSystem saveSystem;
    private CameraAndTileManager cameraTileManager;

    private void Start()
    {
        saveSystem = GameObject.FindObjectOfType<SaveSystem>();
        cameraTileManager = GameObject.FindObjectOfType<CameraAndTileManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Condition
        if(canMove)
        {
            transform.LookAt(targetPosition);

            distance = Vector3.Distance(transform.position, targetPosition.transform.position);

            // Destroing plant object when bad bird is not caught by player
            if (distance < 1f)
            {
                if(GameObject.FindGameObjectWithTag("MovedSoil").transform.Find("Plant") != null)
                {
                    GameObject movedSoil = GameObject.FindGameObjectWithTag("MovedSoil");
                    GameObject plantToDestroy = movedSoil.transform.Find("Plant").gameObject;

                    FindObjectOfType<PlacePlant>().RemoveFromDictionary(movedSoil.GetComponent<ObjectCharacteristics>().uniqueId);

                    movedSoil.GetComponent<SoilTileInformation>().havePlant = false;
                    cameraTileManager.plantSlider.SetActive(false);

                    Destroy(plantToDestroy);

                    saveSystem.SavePlants();

                    saveSystem.SaveManagers();

                }

                Destroy(gameObject);

            }
            else
            {
                Move();
            }
            // Destroying plant when no moved soil object is found
            if (GameObject.FindGameObjectWithTag("MovedSoil") == null)
            {
                Kill();
            }
        }
        
    }

    //Function to move object to target point
    void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //Function to start object movement
    public void StartMoving(Transform target)
    {
        targetPosition = target;
        canMove = true;
    }

    // Destroying bad bird object when caught by player
    public void Kill()
    {
        Destroy(gameObject);

        MoneyManager moneyManager = GameObject.FindGameObjectWithTag("Bank").GetComponent<MoneyManager>();

        System.Numerics.BigInteger addValue = moneyManager.myBalance.moneyBalance / 100;

        // Calculating proper reward for destruction
        if (addValue < 1)
        {
            moneyManager.myBalance.IncrementBalance(1);
        }
        else
        {
            moneyManager.myBalance.IncrementBalance(addValue);
        }

        saveSystem.SaveMoneyBalance();

        GameObject feathers = Instantiate(particle,transform.position,Quaternion.Euler(0,0,0));
        feathers.GetComponent<ParticleSystem>().Play();
        Destroy(feathers, 1f);
    }
}
