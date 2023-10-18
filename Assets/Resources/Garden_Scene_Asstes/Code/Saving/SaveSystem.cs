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
    private DecorationFlyingConstructor decorationFlyingConstructor;
    private DecorationFlyingConstructor.TileDecorationList tileDecorationList;
    GameObject soilTIleObject;

    // Start is called before the first frame update
    void Start()
    {
        soilTIleObject = GameObject.FindGameObjectWithTag("SoilTileConstructor");

        StartCoroutine(WaitToLoad());

    }

    //Function to save MoneyBalance
    public void SaveMoneyBalance()
    {
        moneyBalance = GameObject.FindGameObjectWithTag("Bank").GetComponent<MoneyManager>().myBalance;

        if (DataService.SaveData("/myBalance.json", moneyBalance, EncryptionEnabled))
        {
            Debug.Log("Saved MoneyBallance");
        }
    }

    //Function to save all destroyed BadRockCovers
    public void SaveBadRockCovers()
    {
        destroyed = GameObject.FindGameObjectWithTag("CoverDestroyer").GetComponent<CoverDestroyer>().myDestroyedCovers;

        if (DataService.SaveData("/destroyedCovers.json", destroyed, EncryptionEnabled))
        {
            Debug.Log("Saved");
        }
    }

    //Finction to save all SoilTiles
    public void SaveSoil()
    {
        SaveTiles();

        if (DataService.SaveData("/myTiles.json", occupiedTilesList, EncryptionEnabled))
        {
            Debug.Log("Saved");
        }

        soilTileConstructor.myOccupiedTiles.occupiedTiles.Clear();

    }

    //Function to save all ObjectHolders
    public void SaveObjectHolderTiles()
    {
        SaveObjectHolders();

        if (DataService.SaveData("/myHolders.json", objectHolderConstructorList, EncryptionEnabled))
        {
            Debug.Log("Holder Tiles Saved");
        }
        objectHolderConstructor.myOccupiedObjectHolders.occupiedHolders.Clear();
    }

    //Function to save all FlyingDecorations
    public void SaveFlyingDecoration()
    {
        SaveDocoration();
        if (DataService.SaveData("/decoration.json", tileDecorationList, EncryptionEnabled))
        {
            Debug.Log("Decorations Saved");
        }
        decorationFlyingConstructor.myCreatures.decorationList.Clear();
    }

    //Function to find all FlyingDecorations to save
    void SaveDocoration()
    {
        decorationFlyingConstructor = soilTIleObject.GetComponent<DecorationFlyingConstructor>();

        GameObject[] tiles;
        DecorationFlyingConstructor.TileDecoration tileDecoration;

        tileDecorationList = decorationFlyingConstructor.myCreatures;

        if (GameObject.FindGameObjectWithTag("MovedSoil") == null)
        {
            tiles = GameObject.FindGameObjectsWithTag("SoilTile");
        }
        else
        {
            List<GameObject> tempTile = new List<GameObject>();
            tempTile.AddRange(GameObject.FindGameObjectsWithTag("SoilTile"));
            tempTile.Add(GameObject.FindGameObjectWithTag("MovedSoil"));
            tiles = tempTile.ToArray();
        }

        foreach (GameObject tile in tiles)
        {
            tileDecoration = new DecorationFlyingConstructor.TileDecoration(tile.GetComponent<ObjectCharacteristics>().uniqueId, tile.GetComponent<CreateFlyDecoration>().creaturesQuantity);
            decorationFlyingConstructor.myCreatures.AddToList(tileDecoration);
        }
    }

    //Function to find all SoilTiles to save
    void SaveTiles()
    {
        soilTileConstructor = soilTIleObject.GetComponent<SoilTileConstructor>();

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
               tile = new SoilTileConstructor.Tile(occtile.GetComponent<ObjectCharacteristics>().uniqueId, creator.havePlant, creator.plantId, occtile.GetComponent<HydrationLogic>().timeLeft, occtile.GetComponentInChildren<ManagerLogic>().haveManager);
                soilTileConstructor.myOccupiedTiles.addToOccupied(tile); 
            }
         
        }
    }

    //Function to find all ObjectHolders to save
    void SaveObjectHolders()
    {
        objectHolderConstructor = soilTIleObject.GetComponent<ObjectHolderConstructor>();
        GameObject[] allHolderTiles;
        ObjectHolderConstructor.ObjectHolderObj holderTile;
        objectHolderConstructorList = objectHolderConstructor.myOccupiedObjectHolders;

        if (GameObject.FindGameObjectsWithTag("MovedObjectHolder") == null)
        {
            allHolderTiles = GameObject.FindGameObjectsWithTag("ObjectHolder");
        }
        else
        {
            List<GameObject> tempTile = new List<GameObject>();
            tempTile.AddRange(GameObject.FindGameObjectsWithTag("ObjectHolder"));
            tempTile.AddRange(GameObject.FindGameObjectsWithTag("MovedObjectHolder"));
            allHolderTiles = tempTile.ToArray();
        }


        foreach (GameObject occtile in allHolderTiles)
        {

            ObjectHolder holder = occtile.GetComponent<ObjectHolder>();
            if (holder.haveObject == true)
            {
                holderTile = new ObjectHolderConstructor.ObjectHolderObj(holder.uniqueId,holder.myObjectId);
                objectHolderConstructorList.AddToOccupied(holderTile);
            }

        }



    }

    //Function to load all saved data
    public void Load()
    {

        try
        {
            BadRockCoverPriceing.CoverPrices data = DataService.LoadData<BadRockCoverPriceing.CoverPrices>("/bcover.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("Bank").GetComponent<BadRockCoverPriceing>().LoadData(data);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }

        try {
            CoverDestroyer.DestroyedCovers covers = DataService.LoadData<CoverDestroyer.DestroyedCovers>("/destroyedCovers.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("CoverDestroyer").GetComponent<CoverDestroyer>().LoadData(covers);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }

        try {
            SoilTileConstructor.OccupiedTiles occupied = DataService.LoadData<SoilTileConstructor.OccupiedTiles>("/myTiles.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("SoilTileConstructor").GetComponent<SoilTileConstructor>().LoadData(occupied);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }

        try {
            ObjectHolderConstructor.OccupiedObjectHolders occupiedHolders = DataService.LoadData<ObjectHolderConstructor.OccupiedObjectHolders>("/myHolders.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("SoilTileConstructor").GetComponent<ObjectHolderConstructor>().LoadData(occupiedHolders);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }
        try {
            MoneyManager.MoneyBalance savedBalance = DataService.LoadData<MoneyManager.MoneyBalance>("/myBalance.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("Bank").GetComponent<MoneyManager>().LoadData(savedBalance);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }
        try {
            DecorationFlyingConstructor.TileDecorationList savedDecoration = DataService.LoadData<DecorationFlyingConstructor.TileDecorationList>("/decoration.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("SoilTileConstructor").GetComponent<DecorationFlyingConstructor>().LoadData(savedDecoration);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }
        Debug.Log("Data Loaded");
        
    }

    //Waiting to load SavedData
    IEnumerator WaitToLoad()
    {
      
        yield return new WaitForSeconds(1);

        Load();
    }

    IEnumerator WaitToSave()
    {

        yield return new WaitForSeconds(2);
        SaveMoneyBalance();
    }
}
