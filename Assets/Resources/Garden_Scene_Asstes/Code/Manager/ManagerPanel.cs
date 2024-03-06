using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerPanel : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    GameObject soil;
    // Update is called once per frame
    void Update()
    {
        if (soil = GameObject.FindGameObjectWithTag("MovedSoil"))
        {
           levelText.text = soil.GetComponentInChildren<ManagerLogic>().managerLevel.ToString();
        }
    }
}
