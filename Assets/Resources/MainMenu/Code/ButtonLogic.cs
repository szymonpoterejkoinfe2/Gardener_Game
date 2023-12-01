using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonLogic : MonoBehaviour
{
    public Button buttonLoad;
    public GameObject confirmationPanel, buttonNew, buttonQuit;
    private IDataService DataService = new JasonDataService();
    private string[] saveFiles = { "/myBalance.json", "/plantPrice.json", "/destroyedCovers.json" , "/plants.json" , "/myHolders.json", "/hydration.json" , "/managers.json" , "/decoration.json" , "/ExitTime.json" };


    // Start is called before the first frame update
    void Start()
    {
        confirmationPanel.SetActive(false);
        try
        {
            bool save = DataService.LoadData<bool>("/haveSave.json", true);
        }
        catch
        {
            buttonLoad.interactable = false;
           // Debug.Log("No Previous Save");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Deleting old save and loading new game
    public void Confirmation()
    {
        foreach (string path in saveFiles)
        {
            if (DataService.DeleteData(path))
            {
                Debug.Log($"Data {path} deleted successfully");
            }
            else {
                Debug.Log("Data not found");
            }

        }

        LoadGame();
    }

    // Rejection of new game
    public void Rejection()
    {
        confirmationPanel.SetActive(false);
        buttonLoad.gameObject.SetActive(true);
        buttonNew.SetActive(true);
        buttonQuit.SetActive(true);
    }

    // Starting new game
    public void NewGame()
    {
        buttonLoad.gameObject.SetActive(false);
        buttonNew.SetActive(false);
        buttonQuit.SetActive(false);
        confirmationPanel.SetActive(true);
    }

    // Loading garden scene from save
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    // Quit application
    public void Quit()
    {
        Application.Quit();
    }
}
