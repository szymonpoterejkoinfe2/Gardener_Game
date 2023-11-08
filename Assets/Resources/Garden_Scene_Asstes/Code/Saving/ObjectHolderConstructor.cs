using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolderConstructor : MonoBehaviour
{

    public class OccupiedObjectHolders
    {
        public List<ObjectHolderObj> occupiedHolders;

        public OccupiedObjectHolders(List<ObjectHolderObj> occHolders)
        {
            occupiedHolders = occHolders;
        }

        public void AddToOccupied(ObjectHolderObj objectHolder)
        {
            occupiedHolders.Add(objectHolder);
        }
    }

    public class ObjectHolderObj
    {
        public string uniqID;
        public int objectID;
        public Quaternion objectRotation;

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

                }

            }

        }

    }

}
