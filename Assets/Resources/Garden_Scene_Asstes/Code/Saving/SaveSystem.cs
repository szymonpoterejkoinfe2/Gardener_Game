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
        GameObject soilTIleObject = GameObject.FindGameObjectWithTag("SoilTileConstructor");

        soilTileConstructor = soilTIleObject.GetComponent<SoilTileConstructor>();
        objectHolderConstructor = soilTIleObject.GetComponent<ObjectHolderConstructor>();
        decorationFlyingConstructor = soilTIleObject.GetComponent<DecorationFlyingConstructor>();

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

        SaveObjectHolders();

        if (DataService.SaveData("/myHolders.json", objectHolderConstructorList, EncryptionEnabled))
        {
            Debug.Log("Holder Tiles Saved");
        }

        if (DataService.SaveData("/decoration.json", tileDecorationList, EncryptionEnabled))
        {
            Debug.Log("Decorations Saved");
        }



    }

    void SaveTiles()
    {

        GameObject[] occTiles;
        SoilTileConstructor.Tile tile;
        DecorationFlyingConstructor.TileDecoration tileDecoration;

        occupiedTilesList = soilTileConstructor.myOccupiedTiles;
        tileDecorationList = decorationFlyingConstructor.myCreatures;


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
            tileDecoration = new DecorationFlyingConstructor.TileDecoration(occtile.GetComponent<ObjectCharacteristics>().uniqueId, occtile.GetComponent<CreateFlyDecoration>().creaturesQuantity);
            decorationFlyingConstructor.myCreatures.AddToList(tileDecoration);
        }
    }

    void SaveObjectHolders()
    {
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

            ObjectHolderConstructor.OccupiedObjectHolders occupiedHolders = DataService.LoadData<ObjectHolderConstructor.OccupiedObjectHolders>("/myHolders.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("SoilTileConstructor").GetComponent<ObjectHolderConstructor>().LoadData(occupiedHolders);

            MoneyManager.MoneyBalance savedBalance = DataService.LoadData<MoneyManager.MoneyBalance>("/myBalance.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("Bank").GetComponent<MoneyManager>().LoadData(savedBalance);

            DecorationFlyingConstructor.TileDecorationList savedDecoration = DataService.LoadData<DecorationFlyingConstructor.TileDecorationList>("/decoration.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("SoilTileConstructor").GetComponent<DecorationFlyingConstructor>().LoadData(savedDecoration);

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
