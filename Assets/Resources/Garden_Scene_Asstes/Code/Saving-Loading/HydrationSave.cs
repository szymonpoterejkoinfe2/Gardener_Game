using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrationSave : MonoBehaviour
{
    // class containing list of all tiles with active hydration which will be saved to save file
    public class HydrationContainer
    {
        public List<HydrationTime> allHydrationTimes;

        public HydrationContainer()
        {
            allHydrationTimes = new List<HydrationTime>();
        }

        public HydrationContainer(List<HydrationTime> hydrationTimes)
        {
            allHydrationTimes = hydrationTimes;
        }

        public void AddToList(HydrationTime hydrationTime)
        {
            allHydrationTimes.Add(hydrationTime);
        }
    }

    // class containing inforamtion about hydration time needed to create save
    public class HydrationTime
    {
        public string tileId;
        public ulong hydrationTimeLeft;
        public bool haveWell;

        public HydrationTime() { }
        public HydrationTime(string id, ulong timeLeft, bool well)
        {
            tileId = id;
            hydrationTimeLeft = timeLeft;
            haveWell = well;
        }
    }

    public HydrationContainer myHydrationContainer;
    public List<HydrationTime> times = new List<HydrationTime>(); 
    public HydrationSave()
    {
        myHydrationContainer = new HydrationContainer(times);
    }
        
    // function to load and restore all saved data
    public void LoadData(HydrationContainer data, GameObject[] tiles)
    {

        foreach (HydrationTime time in data.allHydrationTimes)
        {
            foreach (GameObject tile in tiles)
            {
                if (time.tileId == tile.GetComponent<ObjectCharacteristics>().uniqueId)
                {
                    HydrationLogic logic = tile.GetComponent<HydrationLogic>();
                    logic.haveWell = time.haveWell;
                    logic.StartHydration(time.hydrationTimeLeft);

                    break;
                }
            }        
        }
    }
}
