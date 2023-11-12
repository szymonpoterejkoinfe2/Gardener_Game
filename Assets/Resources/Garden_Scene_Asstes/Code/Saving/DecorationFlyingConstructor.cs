using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationFlyingConstructor : MonoBehaviour
{
    // Class with all active flying decorations
    public class TileDecorationList
    {
        public List<TileDecoration> decorationList;

        // Constructor
        public TileDecorationList(List<TileDecoration> list)
        {
            decorationList = list;
        }
        // Adding flying decoration object  to list of all  flying decoration objects
        public void AddToList(TileDecoration decoartion)
        {
            decorationList.Add(decoartion);
        }

    }
    // Class with information about single flying decoration object
    public class TileDecoration
    {
        public string tileID;
        public int[] decorationQuantity;
        // Constructor
        public TileDecoration(string tID, int[] decQuan)
        {
            tileID = tID;
            decorationQuantity = decQuan;
        }
    }

    public TileDecorationList myCreatures;
    List<TileDecoration> created = new List<TileDecoration>();

    public DecorationFlyingConstructor()
    {
        myCreatures = new TileDecorationList(created);
    }


    // Loading back data about saved object holders to recreate them in garden
    public void LoadData(TileDecorationList data)
    {
        GameObject[] soilTiles = GameObject.FindGameObjectsWithTag("SoilTile");

        foreach (TileDecoration tile in data.decorationList)
        {

            foreach (GameObject soilTile in soilTiles)
            {
                if (tile.tileID == soilTile.GetComponent<ObjectCharacteristics>().uniqueId)
                {
                    InstantiateDecoration(tile, soilTile);
                    break;
                }

            }

        }

    }

    // Instantiating Flying Decorations 
    void InstantiateDecoration(TileDecoration tile, GameObject soilTile)
    {
        int[] amount = tile.decorationQuantity;

        for(int creatureID = 0; creatureID < amount.Length; creatureID++)
        {
            for (int cycles = 0; cycles < amount[creatureID]; cycles++)
            {
                soilTile.GetComponent<CreateFlyDecoration>().CreateFlyingCreature(creatureID);
            }

        }


    }

}
