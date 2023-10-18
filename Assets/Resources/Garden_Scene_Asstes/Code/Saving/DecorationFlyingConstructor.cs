using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationFlyingConstructor : MonoBehaviour
{
    public class TileDecorationList
    {
        public List<TileDecoration> decorationList;

        public TileDecorationList(List<TileDecoration> list)
        {
            decorationList = list;
        }

        public void AddToList(TileDecoration decoartion)
        {
            decorationList.Add(decoartion);
        }

    }

    public class TileDecoration
    {
        public string tileID;
        public int[] decorationQuantity;

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
                }

            }

        }

    }
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
