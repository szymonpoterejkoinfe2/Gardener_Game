using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public bool haveObject;
    public int tileId;
    public int myObjectId;
    public Material[] materials;
    public GameObject moveButton;
    public string uniqueId;
    public SpawnPointHolder[] spawnPointHolders;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = materials[0];
        moveButton.SetActive(false);
        
    }

    private void Update()
    {
        spawnPointHolders = GetComponentsInChildren<SpawnPointHolder>();
    }


    // Function to show avaliability of chosen tile
    public void ShowAvaliability()
    {
        if (haveObject)
        {
            gameObject.GetComponent<Renderer>().material = materials[1];
        }
        else {
            gameObject.GetComponent<Renderer>().material = materials[2];
        }
    }

    // Function to hide avaliability of chosen tile
    public void HideAvaliability()
    {
        gameObject.GetComponent<Renderer>().material = materials[0];
    }

    // Activating move buttons
    public void ShowMoveButtons()
    {
        moveButton.SetActive(true);
    }

    // Hiding move buttons
    public void HideMoveButtons()
    {
        moveButton.SetActive(false);
    }

    // Moving decoration object to next tile
    public void MoveToNext(int holderId)
    {
        //Debug.Log("Next");

        GameObject Soil = GameObject.FindGameObjectWithTag("MovedSoil");
    }

    // Moving decoration object to previous tile
    public void MoveToPrevious(int holderId)
    {
        //Debug.Log("Previous");
        GameObject Soil = GameObject.FindGameObjectWithTag("MovedSoil");
    }

    //Function to generate uniqueId
    [ContextMenu("Generate Id")]
    private void GenerateId()
    {
        uniqueId = System.Guid.NewGuid().ToString();
    }

}
