using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    public GameObject[] objectsToBuy;
    GameObject[] objectHolders;
    public List<GameObject> emptyObjectHolders = new List<GameObject>();
    public int ObjectId = 0, HolderId = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

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


    public void CreateObject()
    {
        GameObject new_object;

        FindObjectHolders();

        if (emptyObjectHolders.Count > 0)
        {
            new_object = Instantiate(objectsToBuy[ObjectId], new UnityEngine.Vector3(0, 0, 0), UnityEngine.Quaternion.identity, emptyObjectHolders[HolderId].transform);

            new_object.name = "Object";
            new_object.tag = "NewObject";

            new_object.transform.localPosition = new UnityEngine.Vector3(0, 0.5f, 0);
            new_object.transform.localScale = new UnityEngine.Vector3(0.2f, 20, 0.2f);

           // emptyObjectHolders[HolderId].GetComponent<ObjectHolder>().haveObject = true;

            emptyObjectHolders[HolderId].GetComponent<ObjectHolder>().ShowMoveButtons();

            FindObjectHolders();
        }

    }


    public void DestroyPreviousObject()
    {
        GameObject old_object;
        
        old_object = GameObject.FindGameObjectWithTag("NewObject");
        old_object.transform.parent.gameObject.GetComponent<ObjectHolder>().HideMoveButtons();

        Destroy(old_object);

    }

}
