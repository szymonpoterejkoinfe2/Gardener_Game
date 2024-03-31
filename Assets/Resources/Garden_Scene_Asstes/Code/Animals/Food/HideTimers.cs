using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTimers : MonoBehaviour
{
    [SerializeField]
    GameObject timersBar;
    public void HideTimersBar()
    {
        timersBar.SetActive(false);
    }
}
