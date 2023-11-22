using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject infoPage, frontPage;

    private void Awake()
    {
        ShowFrontPage();
    }

    // Activating inforamtion page
    public void ShowInfoPage()
    {
        infoPage.SetActive(true);
        frontPage.SetActive(false);
    }

    //Activating front page
    public void ShowFrontPage()
    {
        infoPage.SetActive(false);
        frontPage.SetActive(true);
    }
}
