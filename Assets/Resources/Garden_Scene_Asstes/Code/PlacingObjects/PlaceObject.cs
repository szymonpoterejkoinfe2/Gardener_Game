using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaceObject : MonoBehaviour
{
    public GameObject[] objectsToBuy;
    GameObject[] objectHolders;
    public List<GameObject> emptyObjectHolders = new List<GameObject>();
    public int ObjectId = 0, HolderId = 0;
    GameObject bank;
    SaveSystem saveManager;

    private void Awake()
    {
        saveManager = GameObject.FindObjectOfType<SaveSystem>();
    }

    // Find empty object holders
    public void FindObjectHolders()
    {
        emptyObjectHolders.Clear();

        objectHolders = GameObject.FindGameObjectsWithTag("MovedObjectHolder");

        foreach (GameObject objHolder in objectHolders)
        {
            ObjectHolder objectHolderScript = objHolder.GetComponent<ObjectHolder>();

            objectHolderScript.ShowAvaliability();

            if (objectHolderScript != null && !objectHolderScript.haveObject)
            {
                // Add the GameObject to the list if haveObject is false
                emptyObjectHolders.Add(objHolder);
            }
        }
        
    }

    // Function to hide Avaliability of object holders
    public void HideHoldersAvaliability()
    {
        foreach (GameObject objHolder in objectHolders)
        {
            ObjectHolder objectHolderScript = objHolder.GetComponent<ObjectHolder>();

            objectHolderScript.HideAvaliability();
        }
        gameObject.GetComponent<SoilRotation>().Should_Rotate = true;
    }

    // Function to set ObjectId
    public void SetObjectId(int objectId)
    {
        ObjectId = objectId;
    }

    // Function to set ObjectId
    public void ResetObjectId()
    {
        ObjectId = 0;
    }

    // Function to set HolderId
    public void SetHolderId(int holderId)
    {
        HolderId = holderId;
    }

    // Function to set ObjectId
    public void ResetHolderId()
    {
        HolderId = 0;
    }

    // Function to increment  HolderId
    public void IncrementHolderId()
    {
        if (HolderId < emptyObjectHolders.Count - 1)
        {
            HolderId += 1;
        }
        else {
            HolderId = 0;
        }
       
    }

    // Function to decrement  HolderId
    public void DecrementHolderId()
    {
        if (HolderId > 0)
        {
            HolderId -= 1;
        }
        else
        {
            HolderId = emptyObjectHolders.Count - 1;
        } 

    }

    // Function to place objects
    public void CreateObject()
    {
        bank = GameObject.FindGameObjectWithTag("Bank");


        GameObject new_object;

        if (bank.GetComponent<MoneyManager>().myBalance.moneyBalance >=objectsToBuy[ObjectId].GetComponent<ObjectPricing>().objectPrice[ObjectId] )
        {
            FindObjectHolders();

            if (emptyObjectHolders.Count > 0)
            {
                gameObject.GetComponent<SoilRotation>().Should_Rotate = false;
                gameObject.GetComponent<SoilRotation>().ResetState();

                new_object = Instantiate(objectsToBuy[ObjectId], new UnityEngine.Vector3(0, 0, 0), UnityEngine.Quaternion.identity, emptyObjectHolders[HolderId].transform);

                new_object.name = new_object.GetComponent<ObjectCharacteristics>().myName;
                new_object.tag = "NewObject";

                new_object.transform.localPosition = new UnityEngine.Vector3(0, -10, 0);
                new_object.transform.localScale = new_object.GetComponent<ObjectCharacteristics>().valueTarget;



                emptyObjectHolders[HolderId].GetComponent<ObjectHolder>().myObjectId = new_object.GetComponent<ObjectCharacteristics>().myId;

                emptyObjectHolders[HolderId].GetComponent<ObjectHolder>().ShowMoveButtons();

                
            }
        }
       

    }

    //Generating Object From Save File
    public void CreateFromSave(int objId, GameObject tID, Quaternion rotation)
    {
        GameObject new_object;

        new_object = Instantiate(objectsToBuy[objId], new UnityEngine.Vector3(0, 0, 0), UnityEngine.Quaternion.identity, tID.transform);

        new_object.name = new_object.GetComponent<ObjectCharacteristics>().myName;
        new_object.tag = "PlayerObject";

        new_object.transform.localPosition = new UnityEngine.Vector3(0, -10, 0);
        new_object.transform.localScale = new_object.transform.localScale = new_object.GetComponent<ObjectCharacteristics>().valueTarget;

        new_object.transform.rotation = rotation;
    }

    //Rotation of created object
    public void RotateObject()
    {
        GameObject old_object;
        old_object = GameObject.FindGameObjectWithTag("NewObject");

        // Get the current rotation of the object
        Quaternion currentRotation = old_object.transform.rotation;

        // Increment the rotation by 90 degrees around the Y axis
        Quaternion newRotation = Quaternion.Euler(0, 90, 0) * currentRotation;

        // Set the new rotation for the object
        old_object.transform.rotation = newRotation;
    }



    // Destroying old object after moving to new tile
    public void DestroyPreviousObject()
    {
        GameObject old_object;
        old_object = GameObject.FindGameObjectWithTag("NewObject");
        old_object.transform.parent.gameObject.GetComponent<ObjectHolder>().HideMoveButtons();

        Destroy(old_object);

    }

    // Function to confirm creation of new object
    public void ConfirmNewObject()
    {
        bank.GetComponent<MoneyManager>().myBalance.DecrementBalance(objectsToBuy[ObjectId].GetComponent<ObjectPricing>().objectPrice[ObjectId]);

        GameObject new_object;
        new_object = GameObject.FindGameObjectWithTag("NewObject");
        new_object.tag = "PlayerObject";

        HideHoldersAvaliability();
        emptyObjectHolders[HolderId].GetComponent<ObjectHolder>().HideMoveButtons();
        emptyObjectHolders[HolderId].GetComponent<ObjectHolder>().haveObject = true;
        saveManager.SaveObjectHolderTiles();
        saveManager.SaveMoneyBalance();
        gameObject.GetComponent<SoilRotation>().Should_Rotate = true;
    }


}
