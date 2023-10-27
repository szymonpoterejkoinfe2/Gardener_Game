using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardControler : MonoBehaviour
{

    public GameObject leaderBoard;

    //Hiding board on awake
    void Awake()
    {
        HideLeaderBoard();
    }
    //Function to show leader board
    public void ShowLeaderBoard()
    {
        leaderBoard.SetActive(true);
    }
    //Function to hide leader board
    public void HideLeaderBoard()
    {
        leaderBoard.SetActive(false);
    }
}
