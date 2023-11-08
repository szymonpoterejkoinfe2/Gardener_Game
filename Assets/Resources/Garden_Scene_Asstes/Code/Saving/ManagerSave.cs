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
    public List<Manager> managerList;

    ManagerSave()
    {
        managerContainer = new ManagerContainer(managerList);
    }
}
