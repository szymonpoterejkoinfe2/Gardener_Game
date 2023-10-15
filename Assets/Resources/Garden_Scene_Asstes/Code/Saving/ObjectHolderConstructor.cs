using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolderConstructor : MonoBehaviour
{
    private IDataService DataService = new JasonDataService();
    private bool EncryptionEnabled;
    string fileName = "/";

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
        public bool haveObject;
        public int myId;
        public int myObjectId;
        //public string mySoilTileId;

        public ObjectHolderObj(bool hvObj, int id, int objId)
        {
            haveObject = hvObj;
            myId = id;
            myObjectId = objId;
            //mySoilTileId = soilId;
        }
    }

    public OccupiedObjectHolders myoccupiedObjectHolders;
    List<ObjectHolderObj> occupied = new List<ObjectHolderObj>();

    public ObjectHolderConstructor()
    {
        myoccupiedObjectHolders = new OccupiedObjectHolders(occupied);

    }


    public void SaveObjectHolder()
    {
        GameObject[] occHolders;
        ObjectHolderObj objectHolder;

        occHolders = gameObject.GetComponent<MyObjectHolders>().myObjectHolders;


        foreach (GameObject occHolder in occHolders)
        {
            ObjectHolder currentHolder = occHolder.GetComponent<ObjectHolder>();

            if (currentHolder.haveObject)
            {
                objectHolder = new ObjectHolderObj(currentHolder.haveObject, currentHolder.tileId, currentHolder.myObjectId);
                occupied.Add(objectHolder);
                //myoccupiedObjectHolders.AddToOccupied(objectHolder);

            }

        }
        
        string soilId = gameObject.GetComponent<ObjectCharacteristics>().uniqueId;
        fileName += soilId[0..8];
        fileName += ".json";
        if (DataService.SaveData(fileName, myoccupiedObjectHolders, EncryptionEnabled))
        {
            Debug.Log("Saved");
        }
        

    }

    public void LoadData()
    {
        string soilId = gameObject.GetComponent<ObjectCharacteristics>().uniqueId;
        fileName += soilId[0..8];
        fileName += ".json";

        myoccupiedObjectHolders = DataService.LoadData<ObjectHolderConstructor.OccupiedObjectHolders>(fileName, EncryptionEnabled);
        GameObject[] occHolders;
        occHolders = gameObject.GetComponent<MyObjectHolders>().myObjectHolders;


        foreach (ObjectHolderObj objHolder in myoccupiedObjectHolders.occupiedHolders)
        {
            
            foreach (GameObject occHolder in occHolders)
            {
                ObjectHolder holder = occHolder.GetComponent<ObjectHolder>();
                PlaceObject generator = occHolder.GetComponent<PlaceObject>();
                if (holder.tileId == objHolder.myId)
                {

                    generator.CreateFromSave(objHolder.myObjectId);
                    holder.haveObject = objHolder.haveObject;

                }

            }

        }

    }

}
