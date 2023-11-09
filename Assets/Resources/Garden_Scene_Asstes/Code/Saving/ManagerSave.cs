using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSave : MonoBehaviour
{
    // class containing list of all active managers which will be saved to save file
    public class ManagerContainer
    {
     
      public List<Manager> allManagers;
      public ManagerContainer() { }
      public ManagerContainer(List<Manager> myManagers) { allManagers = myManagers; }
      public void AddToList(Manager manager)
       {
            allManagers.Add(manager);
       }
    
    }
    // class containing inforamtion about manager needed to create save
    public class Manager
    {
     public string parentId;
     public float growTime;
     public Manager() { }
     public Manager(string id, float time)
        {
            parentId = id;
            growTime = time;
        }

    }

    public ManagerContainer managerContainer;
    public List<Manager> managerList = new List<Manager>();

    ManagerSave()
    {
        managerContainer = new ManagerContainer(managerList);
    }


    public void LoadData(ManagerContainer data)
    {
        GameObject[] soilTiles = GameObject.FindGameObjectsWithTag("SoilTile");

        foreach (Manager manager in data.allManagers)
        {

            foreach (GameObject tile in soilTiles)
            {
                if (manager.parentId == tile.GetComponent<ObjectCharacteristics>().uniqueId)
                {
                    tile.GetComponent<ManagerLogic>().growTime = manager.growTime;
                    tile.GetComponent<ManagerLogic>().haveManager = true;
                    //break;
                }
            
            }

        }



    }

}
