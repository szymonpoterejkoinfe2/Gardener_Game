using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolderConstructor : MonoBehaviour
{
    public class AllHolders
    {
        public List<OccupiedObjectHolders> allHolders;

        public AllHolders(List<OccupiedObjectHolders> allHold)
        {
            allHolders = allHold;
        }

        public void AddToAll(OccupiedObjectHolders occHolders)
        {
            allHolders.Add(occHolders);
        }
    }


    public class OccupiedObjectHolders
    {
        public List<ObjectHolder> occupiedHolders;

        public OccupiedObjectHolders(List<ObjectHolder> occHolders)
        {
            occupiedHolders = occHolders;
        }

        public void AddToOccupied(ObjectHolder objectHolder)
        {
            occupiedHolders.Add(objectHolder);
        }
    }

    public class ObjectHolder
    {
        public bool haveObject;
        public int myId;
        public int myObjectId;
        public string mySoilTileId;

        public ObjectHolder(bool hvObj, int id, int objId, string soilId)
        {
            haveObject = hvObj;
            myId = id;
            myObjectId = objId;
            mySoilTileId = soilId;
        }
    }

    public OccupiedObjectHolders myoccupiedObjectHolders;
    List<ObjectHolder> occupied = new List<ObjectHolder>();

    public ObjectHolderConstructor()
    {
        myoccupiedObjectHolders = new OccupiedObjectHolders(occupied);

    }

}
