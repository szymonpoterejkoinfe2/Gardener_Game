using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerBuyMenu : MonoBehaviour
{
    public GameObject Panel;
    public Button[] FlowerButtons;
    public TapOnTileDetector tapTileDetector;

    public void SetFlowerInt(int FlowerNumber)
    {
        tapTileDetector.FlowerNumber = FlowerNumber;

    }
    
}
