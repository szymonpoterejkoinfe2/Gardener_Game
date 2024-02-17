using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public bool haveObject;
    public Material[] materials;
    public string uniqueId;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = materials[0];   
    }

    // Function to show avaliability of chosen tile
    public void ShowAvailability()
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
    public void HideAvailability()
    {
        gameObject.GetComponent<Renderer>().material = materials[0];
    }

    //Function to generate uniqueId
    [ContextMenu("Generate Id")]
    private void GenerateId()
    {
        uniqueId = System.Guid.NewGuid().ToString();
    }

}
