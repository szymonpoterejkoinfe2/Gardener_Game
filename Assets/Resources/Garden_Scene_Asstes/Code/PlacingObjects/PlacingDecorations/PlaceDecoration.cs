using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDecoration : MonoBehaviour
{
    [SerializeField]
    DecorationsHolder decorationsHolder;
    Dictionary<string, GameObject> allDecorations, holderTiles, allSoilTiles;
    GameObject soilTile, newDecoration, oldDecoration;
    string soilTileID, decorationID;
    List<GameObject> availableTiles = new List<GameObject>();
    int holderIndex = 0;
    SoilRotation soilRotation;
    

    [SerializeField]
    SoilTileDecorations newDict;
    [SerializeField]
    SaveSystem saveSystem;

    [SerializeField]
    public Dictionary<string, List<Decoration>> placedDecorations;
    public GameObject moveButtons, shopMenu, returnButton;

    [SerializeField]
    SoilTiles soilTiles;

    void Awake()
    {
        placedDecorations = newDict.ToDictionary();
    }

    void Start()
    {
        moveButtons.SetActive(false);
        allDecorations = decorationsHolder.allDecorations;
        allSoilTiles = soilTiles.allSoilTiles;
    }

    //Geting decoration id from button
    public void SetDecorationId(string decorationID)
    {
        this.decorationID = decorationID;
    }

    //Function to find all available object holders of soil tile
    public void FindAvailableTiles()
    {
        availableTiles.Clear();

        moveButtons.SetActive(true);
        shopMenu.SetActive(false);

        soilTile = GameObject.FindGameObjectWithTag("MovedSoil");
        soilRotation = soilTile.GetComponent<SoilRotation>(); 
        soilRotation.Should_Rotate = false;
        soilRotation.ResetState();

        soilTileID = soilTile.GetComponent<ObjectCharacteristics>().uniqueId;
        holderTiles = soilTile.GetComponent<MyObjectHolders>().myObjectHolders;

        foreach (GameObject holderTile in holderTiles.Values)
        {
            ObjectHolder objectHolder = holderTile.GetComponent<ObjectHolder>();

            objectHolder.ShowAvailability();

            if (objectHolder.haveObject == false)
            {
                availableTiles.Add(holderTile);
            }
        }

        if (availableTiles.Count > 0)
        {
            PlaceDecorationObject(decorationID, holderIndex);
        }

    }

    //Function to Hide availbility of holder tiles
    private void HideAvailability()
    {
        moveButtons.SetActive(false);
        returnButton.SetActive(true);
        soilRotation.Should_Rotate = true;

        foreach (GameObject holderTile in holderTiles.Values)
        {
            ObjectHolder objectHolder = holderTile.GetComponent<ObjectHolder>();
            objectHolder.HideAvailability();
        }
    }

    //Function to Instantiate decoration object
    private void PlaceDecorationObject(string decorationID, int holderIndex)
    {
        newDecoration = Instantiate(allDecorations[decorationID], availableTiles[holderIndex].transform.position, Quaternion.identity, availableTiles[holderIndex].transform);
        newDecoration.transform.localScale = newDecoration.GetComponent<ObjectCharacteristics>().valueTarget;
        newDecoration.transform.localPosition = newDecoration.GetComponent<ObjectCharacteristics>().positionTarget;
        oldDecoration = newDecoration.gameObject;
    }

    //Function to Load decoration object from save
    private void PlaceDecorationObject(string decorationID, GameObject holderTile, Quaternion rotation)
    {
        newDecoration = Instantiate(allDecorations[decorationID], holderTile.transform.position, Quaternion.identity, holderTile.transform);
        newDecoration.transform.localScale = newDecoration.GetComponent<ObjectCharacteristics>().valueTarget;
        newDecoration.transform.localPosition = newDecoration.GetComponent<ObjectCharacteristics>().positionTarget;
        newDecoration.transform.rotation = rotation;
        holderTile.GetComponent<ObjectHolder>().haveObject = true;
    }


    //Instantiating new decoration prefab object in in next available point, destroying old decoration object
    public void PlaceInNextPoint()
    {
        if ((holderIndex + 1) > (availableTiles.Count - 1))
        {
            holderIndex = 0;
        }
        else
        {
            holderIndex++;
        }

        Destroy(oldDecoration);

        PlaceDecorationObject(decorationID, holderIndex);
    }

    //Instantiating new decoration prefab object in in previous available point, destroying old decoration object
    public void PlaceInPreviousPoint()
    {
        if ((holderIndex - 1) < 0)
        {
            holderIndex = (availableTiles.Count - 1);
        }
        else
        {
            holderIndex--;
        }

        Destroy(oldDecoration);

        PlaceDecorationObject(decorationID, holderIndex);
    }
    //Rotation of created object
    public void RotateDecoration()
    {
        Quaternion currentRotation = oldDecoration.transform.rotation;
        Quaternion newRotation = Quaternion.Euler(0, 90, 0) * currentRotation;
        oldDecoration.transform.rotation = newRotation;
    }

    //Confirming animal object
    public void ConfirmNewDecoration()
    {
        ObjectHolder objectHolder = availableTiles[holderIndex].GetComponent<ObjectHolder>();
        string objectHolderID = objectHolder.uniqueId;
        objectHolder.haveObject = true;
        placedDecorations[soilTileID].Add(new Decoration(decorationID, objectHolderID, oldDecoration.transform.rotation));
        oldDecoration = null;
        holderIndex = 0;
        HideAvailability();

        saveSystem.SaveGardenDecorations();
    }

    //Rejecting animal object
    public void RejectNewDecoration()
    {
        Destroy(oldDecoration.gameObject);
        oldDecoration = null;
        holderIndex = 0;
        HideAvailability();
    }

    // Function to load saved decorations from save file
    public void LoadDecorations(Dictionary<string, List<Decoration>> allSavedDecorations)
    {
        GameObject soilTile;
        Dictionary<string, GameObject> holderTiles;

        placedDecorations = allSavedDecorations;
        
        foreach (var savedDecoration in allSavedDecorations)
        {
            if (savedDecoration.Value.Count > 0)
            {

                soilTile = allSoilTiles[savedDecoration.Key];
                holderTiles = soilTile.GetComponent<MyObjectHolders>().myObjectHolders;

                foreach (Decoration decoration in savedDecoration.Value)
                {
                    PlaceDecorationObject(decoration.decorationID, holderTiles[decoration.holderTileID],decoration.rotation);
                }

            }
           
        }
    }

}

[Serializable]
public class SoilTileDecorations
{
    [SerializeField]
    SoilTileDecorationElement[] dictionaryItems;

    public Dictionary<string, List<Decoration>> ToDictionary()
    {
        Dictionary<string, List<Decoration>> newDict = new Dictionary<string, List<Decoration>>();

        foreach (var item in dictionaryItems)
        {
            newDict.Add(item.soilTileID, item.decorations);
        }

        return newDict;
    }
}

[Serializable]
public class SoilTileDecorationElement
{
    [SerializeField]
    public string soilTileID;

    [SerializeField]
    public List<Decoration> decorations = new List<Decoration>();

}

[Serializable]
public class Decoration
{
    public string decorationID;
    public string holderTileID;
    public Quaternion rotation;

    public Decoration(string decorationID, string holderTileID, Quaternion rotation)
    {
        this.decorationID = decorationID;
        this.holderTileID = holderTileID;
        this.rotation = rotation;
    }
}