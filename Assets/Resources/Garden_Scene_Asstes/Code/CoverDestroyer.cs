using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverDestroyer : MonoBehaviour
{
    // Class storing list of destroyed Covers to save.
    public class DestroyedCovers
    {
        public List<string> destroyed;

        // Constructor
        public DestroyedCovers(List<string> dstr)
        {
            destroyed = dstr;
        }

        // Adding IDs of destroyed covers
        public void addToDestroyed(string id)
        {
            destroyed.Add(id);
        }
    }

    // Creating new DestroyedCovers Object which will be saved
    public DestroyedCovers myDestroyedCovers;
    List<string> destroyed = new List<string>();
    public CoverDestroyer()
    {
        myDestroyedCovers = new DestroyedCovers(destroyed);
    }

    // Loadivg Previously saved covers and destoing them
    public void LoadData(DestroyedCovers destroyedToLoad)
    {
        myDestroyedCovers = destroyedToLoad;

        GameObject[] allCovers = GameObject.FindGameObjectsWithTag("Cover");

        // Comparing all covers with list of ones to destroy
        for (int cover = 0; cover < allCovers.Length; cover++)
        {
            ObjectCharacteristics coverCharacteristics = allCovers[cover].GetComponent<ObjectCharacteristics>();

            for (int id = 0; id < destroyedToLoad.destroyed.Count; id++)
            {
                // Checking if cover is to destroy
                if (coverCharacteristics.uniqueId == destroyedToLoad.destroyed[id])
                {
                    allCovers[cover].GetComponent<DestroyMe>().DestroyMyObject();
                }
            }
        }
    }

}
