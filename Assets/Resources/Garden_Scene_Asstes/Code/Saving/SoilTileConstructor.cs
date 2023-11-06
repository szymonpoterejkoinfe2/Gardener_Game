using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilTileConstructor : MonoBehaviour
{

    public class OccupiedTiles
    {
        public List<Tile> occupiedTiles; // List of non-empty tiles

        // Constructor
        public OccupiedTiles(List<Tile> occupied)
        {
            occupiedTiles = occupied;
        }

        // Adding occupied Tiles to list
        public void addToOccupied(Tile tile)
        {
            occupiedTiles.Add(tile);
        }
    }

    public class Tile
    {
        public string myId; // Unique id of SoilTile
        public bool havePlant; 
        public int plantId;
        public ulong hydrationTime;
        public bool haveManager;
        public float growTime;

        // Constructor
        public Tile(string mID, bool plant, int pID, ulong hydTim, bool manager, float time)
        {
            myId = mID;
            havePlant = plant;
            plantId = pID;
            hydrationTime = hydTim;
            haveManager = manager;
            growTime = time;
        }

    }

    // Creating new OccupiedTiles Object which will be saved
    public OccupiedTiles myOccupiedTiles;
    List<Tile> occupied = new List<Tile>();


    public SoilTileConstructor()
    {
        myOccupiedTiles = new OccupiedTiles(occupied);
    }

    // Function to load saved data. Planting previously possesed plants
    public void LoadData(OccupiedTiles occupiedToLoad)
    {
        //clearing previously stored data
        myOccupiedTiles.occupiedTiles.Clear();

        // Finding all SoilTile Objects
        GameObject[] soilTiles = GameObject.FindGameObjectsWithTag("SoilTile");

        // Replanting all saved plants
        foreach (Tile occTile in occupiedToLoad.occupiedTiles)
        {
            foreach (GameObject soil in soilTiles)
            {
                if (occTile.myId == soil.GetComponent<ObjectCharacteristics>().uniqueId && occTile.havePlant)
                {
                    soil.GetComponent<PlantCreator>().Generate_Plant(occTile.plantId,true);
                    soil.GetComponent<HydrationLogic>().StartHydration(occTile.hydrationTime);

                    if (occTile.haveManager)
                    {
                        soil.GetComponentInChildren<ManagerLogic>().StartGrowing(occTile.growTime);
                    }
                    
                }

            }

        }

    }
}
