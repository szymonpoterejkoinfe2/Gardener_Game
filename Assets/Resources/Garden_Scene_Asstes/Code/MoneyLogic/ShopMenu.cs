using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    private GameObject SoilTile, Plant;
    public GameObject PlantCategory, MenagerCategory;
    private GameObject[] AllPlants;
    public TextMeshProUGUI[] BuyPriceTxt;
    public TextMeshProUGUI[] UpgradePriceTxt;

    private void Awake()
    {
        PlantCategory.SetActive(true);
        MenagerCategory.SetActive(false);
    }

    //Activating Menager Shop Menu
    public void MenagerCategoryActivate()
    {
        PlantCategory.SetActive(false);
        MenagerCategory.SetActive(true);
    }

    //Activating Plant Shop Menu
    public void PlantCategoryActivate()
    {
        PlantCategory.SetActive(true);
        MenagerCategory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SoilTile = GameObject.FindGameObjectWithTag("MovedSoil");
        AllPlants = SoilTile.GetComponent<PlantCreator>().plants;
        
        // Taking Price from Planted Object
        if (SoilTile.GetComponent<PlantCreator>().HavePlant)
        {
           Plant = SoilTile.transform.Find("Plant").gameObject;
           UpgradePriceTxt[Plant.GetComponent<ObjectPrice>().MyId].text = Plant.GetComponent<ObjectPrice>().UpgradeCost.ToString();
           
        }
        else
        {
            // Taking Price From Prefab Objects
            for (int PlantId = 0; PlantId < AllPlants.Length; PlantId++)
            {
                BuyPriceTxt[PlantId].text = AllPlants[PlantId].GetComponent<ObjectPrice>().MyPrice.ToString();
                UpgradePriceTxt[PlantId].text = AllPlants[PlantId].GetComponent<ObjectPrice>().UpgradeCost.ToString();
            }
        }

    }

    //Buying Manager for Tile
    public void GrowWithPlantManager()
    {
        GameObject SoilToCheck;
        GameObject Plant;

        SoilToCheck = GameObject.FindGameObjectWithTag("MovedSoil");

        if (SoilToCheck.GetComponent<PlantCreator>().HavePlant == true)
        {

            Plant = SoilTile.transform.Find("Plant").gameObject;
            Plant.GetComponent<ManagerLogic>().StartGrowing();

        }

    }


}
