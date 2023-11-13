using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilTileConstructor : MonoBehaviour
{
    //Class with all  soilTile objects
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
    // Class with information about single soilTile object
    public class Tile
    {
        public string myId; // Unique id of SoilTile
        public bool havePlant; 
        public int plantId;

        // Constructor
        public Tile(string mID, bool plant, int pID)
        {
            myId = mID;
            havePlant = plant;
            plantId = pID;
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
    public void LoadData(OccupiedTiles occupiedToLoad, GameObject[] soilTiles)
    {
        //clearing previously stored data
        myOccupiedTiles.occupiedTiles.Clear();

        // Replanting all saved plants
        foreach (Tile occTile in occupiedToLoad.occupiedTiles)
        {
            foreach (GameObject soil in soilTiles)
            {
                if (occTile.myId == soil.GetComponent<ObjectCharacteristics>().uniqueId && occTile.havePlant)
                {
                    soil.GetComponent<PlantCreator>().Generate_Plant(occTile.plantId,true);
                    break;
                }

            }

        }

    }
}
