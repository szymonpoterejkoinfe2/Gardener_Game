using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolderConstructor : MonoBehaviour
{
    private IDataService DataService = new JasonDataService();
    private bool EncryptionEnabled;
    

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
       

        public ObjectHolderObj( string id, int myObject)
        {
            uniqID = id;
            objectID = myObject;
        }
    }

    public OccupiedObjectHolders myOccupiedObjectHolders;
    List<ObjectHolderObj> occupied = new List<ObjectHolderObj>();

    public ObjectHolderConstructor()
    {
        myOccupiedObjectHolders = new OccupiedObjectHolders(occupied);

    }


    //public void SaveObjectHolder()
    //{
    //    string fileName = "/";

    //    GameObject[] occHolders;
    //    ObjectHolderObj objectHolder;

    //    occHolders = gameObject.GetComponent<MyObjectHolders>().myObjectHolders;

    //    foreach (GameObject occHolder in occHolders)
    //    {
    //        ObjectHolder currentHolder = occHolder.GetComponent<ObjectHolder>();

    //        if (currentHolder.haveObject)
    //        {
    //            objectHolder = new ObjectHolderObj(currentHolder.haveObject, currentHolder.tileId, currentHolder.myObjectId);
    //            occupied.Add(objectHolder);
    //            Debug.Log("Holder saved");
    //            Debug.Log(occupied.Count);
    //            //myoccupiedObjectHolders.AddToOccupied(objectHolder);

    //        }

    //    }

    //    string soilId = gameObject.GetComponent<ObjectCharacteristics>().uniqueId;
    //    fileName += soilId.Substring(0,8);
    //    fileName += ".json";
    //    if (DataService.SaveData(fileName, myoccupiedObjectHolders, EncryptionEnabled))
    //    {
    //        Debug.Log("Saved holders");
    //       // occupied.Clear();
    //    }


    //}

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

                  generator.CreateFromSave(objHolder.objectID);
                  holder.haveObject = true;

                }

            }

        }

    }

}
