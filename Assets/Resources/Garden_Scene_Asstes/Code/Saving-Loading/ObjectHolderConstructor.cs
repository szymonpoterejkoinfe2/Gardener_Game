using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolderConstructor : MonoBehaviour
{
    //Class with all occupied object holder tiles
    public class OccupiedObjectHolders
    {
        public List<ObjectHolderObj> occupiedHolders;

        // Constructor
        public OccupiedObjectHolders(List<ObjectHolderObj> occHolders)
        {
            occupiedHolders = occHolders;
        }

        // Adding object holder to list of all occupied object holders
        public void AddToOccupied(ObjectHolderObj objectHolder)
        {
            occupiedHolders.Add(objectHolder);
        }
    }

    // Class with information about single object holder tile
    public class ObjectHolderObj
    {
        public string uniqID;
        public int objectID;
        public Quaternion objectRotation;

        // Constructor
        public ObjectHolderObj(string id, int myObject, Quaternion myRotation)
        {
            uniqID = id;
            objectID = myObject;
            objectRotation = myRotation;
        }
    }

    public OccupiedObjectHolders myOccupiedObjectHolders;
    List<ObjectHolderObj> occupied = new List<ObjectHolderObj>();

    public ObjectHolderConstructor()
    {
        myOccupiedObjectHolders = new OccupiedObjectHolders(occupied);

    }

    // Loading back data about saved object holders to recreate them in garden
    public void LoadData(OccupiedObjectHolders occupiedToLoad)
    {
        GameObject[] occHolders = GameObject.FindGameObjectsWithTag("ObjectHolder");

        Debug.Log("Saved Holders: " + occupiedToLoad.occupiedHolders.Count);

        foreach (ObjectHolderObj objHolder in occupiedToLoad.occupiedHolders)
        {
           
            foreach (GameObject occHolder in occHolders)
            {

                ObjectHolder holder = occHolder.GetComponent<ObjectHolder>();
                PlaceObject generator = occHolder.transform.GetComponentInParent<PlaceObject>();
                if (holder.uniqueId == objHolder.uniqID)
                {
                  generator.CreateFromSave(objHolder.objectID, holder.gameObject, objHolder.objectRotation);
                  holder.haveObject = true;
                    break;
                }

            }

        }

    }

}
