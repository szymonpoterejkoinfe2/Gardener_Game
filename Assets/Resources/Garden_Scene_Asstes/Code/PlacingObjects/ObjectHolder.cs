using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public bool haveObject;
    public int tileId;
    public Material[] materials;
    public GameObject moveButton;
    

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = materials[0];
        moveButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    public void HideAvaliability()
    {
        gameObject.GetComponent<Renderer>().material = materials[0];
    }

    public void ShowMoveButtons()
    {
        moveButton.SetActive(true);
    }

    public void HideMoveButtons()
    {
        moveButton.SetActive(false);
    }

    public void MoveToNext(int holderId)
    {
        Debug.Log("Next");
        GameObject Soil = GameObject.FindGameObjectWithTag("MovedSoil");
    }

    public void MoveToPrevious(int holderId)
    {
        Debug.Log("Previous");
        GameObject Soil = GameObject.FindGameObjectWithTag("MovedSoil");
    }
}
