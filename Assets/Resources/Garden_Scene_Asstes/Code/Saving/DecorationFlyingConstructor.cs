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
        string tileID;
        int[] decorationQuantity;

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



}
