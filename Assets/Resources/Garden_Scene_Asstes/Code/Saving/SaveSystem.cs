using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private IDataService DataService = new JasonDataService();
    private BadRockCoverPriceing.CoverPrices pricing;
    private CoverDestroyer.DestroyedCovers destroyed;
    private MoneyManager.MoneyBalance moneyBalance;
    private SoilTileConstructor.OccupiedTiles occupiedTilesList;
    private bool EncryptionEnabled;
    private SoilTileConstructor soilTileConstructor;
    private ObjectHolderConstructor.OccupiedObjectHolders objectHolderConstructorList;
    private ObjectHolderConstructor objectHolderConstructor;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToLoad());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        soilTileConstructor = GameObject.FindGameObjectWithTag("SoilTileConstructor").GetComponent<SoilTileConstructor>();
        //objectHolderConstructor = GameObject.FindGameObjectWithTag("SoilTileConstructor").GetComponent<ObjectHolderConstructor>();

        pricing = GameObject.FindGameObjectWithTag("Bank").GetComponent<BadRockCoverPriceing>().myCoverPrices;

        destroyed = GameObject.FindGameObjectWithTag("CoverDestroyer").GetComponent<CoverDestroyer>().myDestroyedCovers;

        moneyBalance = GameObject.FindGameObjectWithTag("Bank").GetComponent<MoneyManager>().myBalance;

        if (DataService.SaveData("/bcover.json", pricing, EncryptionEnabled)) {
            Debug.Log("Saved");
        }
        if (DataService.SaveData("/destroyedCovers.json", destroyed, EncryptionEnabled))
        {
            Debug.Log("Saved");
        }
        if (DataService.SaveData("/myBalance.json", moneyBalance, EncryptionEnabled))
        {
            Debug.Log("Saved");
        }

        SaveTiles();

        if (DataService.SaveData("/myTiles.json", occupiedTilesList, EncryptionEnabled))
        {
            Debug.Log("Saved");
        }

        GameObject[] soilTiles;
        soilTiles = GameObject.FindGameObjectsWithTag("SoilTile"); ;
        foreach (GameObject tile in soilTiles)
        {
            tile.GetComponent<ObjectHolderConstructor>().SaveObjectHolder();
        }

    }

    void SaveTiles()
    {

        GameObject[] occTiles;
        SoilTileConstructor.Tile tile;
      
        occupiedTilesList = soilTileConstructor.myOccupiedTiles;

        if (GameObject.FindGameObjectWithTag("MovedSoil") == null)
        {
            occTiles = GameObject.FindGameObjectsWithTag("SoilTile");
        }
        else {
            List<GameObject> tempTile = new List<GameObject>();
            tempTile.AddRange( GameObject.FindGameObjectsWithTag("SoilTile"));
            tempTile.Add(GameObject.FindGameObjectWithTag("MovedSoil"));
            occTiles = tempTile.ToArray();
        }

        foreach (GameObject occtile in occTiles)
        {
            
            PlantCreator creator = occtile.GetComponent<PlantCreator>();
            if (creator.havePlant == true)
            {
               tile = new SoilTileConstructor.Tile(occtile.GetComponent<ObjectCharacteristics>().uniqueId, creator.havePlant, creator.plantId);
                soilTileConstructor.myOccupiedTiles.addToOccupied(tile); 
            }

        }
    }

    //void SaveObjectHolders()
    //{
    //    GameObject[] occHolders;
    //    ObjectHolderConstructor.ObjectHolder holder;

    //    objectHolderConstructorList = objectHolderConstructor.myoccupiedObjectHolders;

    //    occHolders = GameObject.FindGameObjectsWithTag("ObjectHolder");
    //}


    public void Load()
    {

        try
        {
            BadRockCoverPriceing.CoverPrices data = DataService.LoadData<BadRockCoverPriceing.CoverPrices>("/bcover.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("Bank").GetComponent<BadRockCoverPriceing>().LoadData(data);

            CoverDestroyer.DestroyedCovers covers = DataService.LoadData<CoverDestroyer.DestroyedCovers>("/destroyedCovers.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("CoverDestroyer").GetComponent<CoverDestroyer>().LoadData(covers);

            SoilTileConstructor.OccupiedTiles occupied = DataService.LoadData<SoilTileConstructor.OccupiedTiles>("/myTiles.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("SoilTileConstructor").GetComponent<SoilTileConstructor>().LoadData(occupied);

            MoneyManager.MoneyBalance savedBalance = DataService.LoadData<MoneyManager.MoneyBalance>("/myBalance.json",EncryptionEnabled);
            GameObject.FindGameObjectWithTag("Bank").GetComponent<MoneyManager>().LoadData(savedBalance);

            GameObject[] soilTiles;
            soilTiles = GameObject.FindGameObjectsWithTag("SoilTile"); ;
            foreach (GameObject tile in soilTiles)
            {
                tile.GetComponent<ObjectHolderConstructor>().LoadData();
            }



            Debug.Log("Data Loaded");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }
    }

    IEnumerator WaitToLoad()
    {
      
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        Load();
    }
}
