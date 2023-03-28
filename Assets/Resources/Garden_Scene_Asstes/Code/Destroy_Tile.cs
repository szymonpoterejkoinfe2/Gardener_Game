using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Tile : MonoBehaviour
{

    public GameObject[] Tiles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void DestroyGameObject(int number)
    {
        Destroy(Tiles[number]);
    }
}
