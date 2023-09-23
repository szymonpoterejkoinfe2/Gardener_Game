using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private IDataService DataService = new JasonDataService();
    private BadRockCoverPriceing.CoverPrices pricing;
    private CoverDestroyer.DestroyedCovers destroyed;
    private MoneyManager.MoneyBalance moneyBalance;
    private bool EncryptionEnabled;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
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
    }

    public void Load()
    {
        try
        {
            BadRockCoverPriceing.CoverPrices data = DataService.LoadData<BadRockCoverPriceing.CoverPrices>("/bcover.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("Bank").GetComponent<BadRockCoverPriceing>().LoadData(data);

            CoverDestroyer.DestroyedCovers covers = DataService.LoadData<CoverDestroyer.DestroyedCovers>("/destroyedCovers.json", EncryptionEnabled);
            GameObject.FindGameObjectWithTag("CoverDestroyer").GetComponent<CoverDestroyer>().LoadData(covers);

            MoneyManager.MoneyBalance savedBalance = DataService.LoadData<MoneyManager.MoneyBalance>("/myBalance.json",EncryptionEnabled);
            GameObject.FindGameObjectWithTag("Bank").GetComponent<MoneyManager>().LoadData(savedBalance);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Could not read file! Error: {e.Message}");
        }
    }

}
