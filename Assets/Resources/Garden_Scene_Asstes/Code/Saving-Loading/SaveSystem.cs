using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private IDataService DataService = new JasonDataService();

    //New Save System
    [SerializeField]
    PlaceDecoration decorationSpawner;
    [SerializeField]
    PlacePlant plantSpawner;
    [SerializeField]
    PlantsHydration plantsHydration;
    [SerializeField]
    SpawnSkyAnimals spawnSkyAnimals;
    [SerializeField]
    ManagerHolder managerHolder;
    [SerializeField]
    SpawnAnimals spawnAnimals;

    private CoverDestroyer.DestroyedCovers destroyed;
    private bool haveSave = true;
    private bool EncryptionEnabled;

    private MoneyManager.MoneyBalance moneyBalance;
    private PricingSystemPlants.PlantPrices plantPrices;


    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(WaitToLoad());
        
        if (DataService.SaveData("/haveSave.json", haveSave, true))
        {
            Debug.Log("Saved");
        }

        StartCoroutine(SaveHydrationTimer());
    }


    //New Save System
    /// //////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    //Function to save all destroyed BadRockCovers
    public void SaveBadRockCovers()
    {
        destroyed = GameObject.FindGameObjectWithTag("CoverDestroyer").GetComponent<CoverDestroyer>().myDestroyedCovers;

        if (DataService.SaveData("/DestroyedCovers.json", destroyed, EncryptionEnabled))
        {
            Debug.Log("Saved");
        }
    }


    //Function to save all Garden decoration tiles
    public void SaveGardenDecorations()
    {
        Dictionary<string, List<Decoration>> decorationsDictionary = decorationSpawner.placedDecorations;

        if (DataService.SaveData("/Decorations.json", decorationsDictionary, EncryptionEnabled))
        {
            Debug.Log("Decorations Saved");
        }
        //objectHolderConstructor.myOccupiedObjectHolders.occupiedHolders.Clear();
    }

    //Function to save all plants
    public void SavePlants()
    {
        Dictionary<string, string> plantsDictionary = plantSpawner.placedPlants;

        if (DataService.SaveData("/Plants.json", plantsDictionary, EncryptionEnabled))
        {
            Debug.Log("Plants Saved");
        }

    }

    public void SaveHydration()
    {
        Dictionary<string, HydrationInfo> hydrationDictionary = plantsHydration.plantsHydration;

        if (DataService.SaveData("/Hydration.json", hydrationDictionary, EncryptionEnabled))
        {
            Debug.Log("Hydration Saved");
        }
    }

    public void SaveSkyAnimals()
    {
        Dictionary<string, Dictionary<string, int>> skyAnimalsDictionary = spawnSkyAnimals.instantiatedSkyAnimals;

        if (DataService.SaveData("/SkyAnimals.json", skyAnimalsDictionary, EncryptionEnabled))
        {
            Debug.Log("Sky Animals Saved");
        }

    }

    public void SaveManagers()
    {
        Dictionary<string, ManagerInfo> managers = managerHolder.allManagers;

        if (DataService.SaveData("/Managers.json", managers, EncryptionEnabled))
        {
            Debug.Log("Managers Saved");
        }
    }

    public void SaveGroundAnimals()
    {
        List<AnimalInfo> groundAnimals = spawnAnimals.placedAnimals;

        if (DataService.SaveData("/GroundAnimals.json", groundAnimals, EncryptionEnabled))
        {
            Debug.Log("Ground Animals Saved");
        }
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


    /// //////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\



    //Function to save plant/upgrade/manager prices
    public void SavePlantPricing()
    {
        plantPrices = GameObject.FindGameObjectWithTag("Bank").GetComponent<PricingSystemPlants>().plantPrices;

        if (DataService.SaveData("/plantPrice.json", plantPrices, EncryptionEnabled))
        {
            Debug.Log("Saved");
        }
    }


    //Function to load all saved data
    public void Load()
    {
        Rotation rot = FindObjectOfType<Rotation>();
        rot.speed = 0;
        rot.ResetState();

        //New Load System
        /// //////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        /// 
        try
        {
            MoneyManager.MoneyBalance savedBalance = DataService.LoadData<MoneyManager.MoneyBalance>("/myBalance.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("Bank").GetComponent<MoneyManager>().LoadData(savedBalance);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }

        try
        {
            CoverDestroyer.DestroyedCovers covers = DataService.LoadData<CoverDestroyer.DestroyedCovers>("/DestroyedCovers.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("CoverDestroyer").GetComponent<CoverDestroyer>().LoadData(covers);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }

        try
        {
            Dictionary<string, List<Decoration>> loadedDecorations = DataService.LoadData<Dictionary<string, List<Decoration>>>("/Decorations.json", EncryptionEnabled);
            decorationSpawner.LoadDecorations(loadedDecorations);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }

        try
        {
            Dictionary<string, string> savedPlants = DataService.LoadData<Dictionary<string, string>>("/Plants.json", EncryptionEnabled);
            plantSpawner.LoadPlants(savedPlants);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }

        try {
            Dictionary<string, HydrationInfo> savedHydration = DataService.LoadData<Dictionary<string, HydrationInfo>>("/Hydration.json",EncryptionEnabled);
            plantsHydration.LoadHydration(savedHydration);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }

        try {
            Dictionary<string, Dictionary<string, int>> savedSkyAnimals = DataService.LoadData<Dictionary<string, Dictionary<string, int>>>("/SkyAnimals.json", EncryptionEnabled);
            spawnSkyAnimals.LoadSkyAnimals(savedSkyAnimals);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }

        try
        {
            Dictionary<string, ManagerInfo> savedManagers = DataService.LoadData<Dictionary<string, ManagerInfo>>("/Managers.json", EncryptionEnabled);
            managerHolder.LoadManagers(savedManagers);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }

        try
        {
            List<AnimalInfo> savedAnimals = DataService.LoadData<List<AnimalInfo>>("/GroundAnimals.json", EncryptionEnabled);
            spawnAnimals.LoadAnimals(savedAnimals);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }

        try
        {
            TimeSave.ExitTime exitTime = DataService.LoadData<TimeSave.ExitTime>("/ExitTime.json", true);
            gameObject.GetComponent<TimeSave>().LoadTime(exitTime);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }

        /// //////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        GameObject[] soilTiles = GameObject.FindGameObjectsWithTag("SoilTile");

        try
        {
            MoneyManager.MoneyBalance savedBalance = DataService.LoadData<MoneyManager.MoneyBalance>("/myBalance.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("Bank").GetComponent<MoneyManager>().LoadData(savedBalance);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }

        try
        {
            PricingSystemPlants.PlantPrices savedPrices = DataService.LoadData<PricingSystemPlants.PlantPrices>("/plantPrice.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("Bank").GetComponent<PricingSystemPlants>().LoadData(savedPrices);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }


 
        Debug.Log("Data Loaded");

        rot.speed = 2;
    }

    //Waiting to load SavedData
    IEnumerator WaitToLoad()
    {
      
        yield return new WaitForSeconds(1);

        Load();
    }

    // saving hydration level every 10 seconds
    IEnumerator SaveHydrationTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            SaveHydration();

        }

    }
}
