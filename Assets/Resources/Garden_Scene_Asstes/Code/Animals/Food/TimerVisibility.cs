using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerVisibility : MonoBehaviour
{

    bool timersActive;

    [SerializeField]
    GameObject allTimers;

    [SerializeField]
    Animator animator;

    [SerializeField]
    FoodManager foodManager;


    // Start is called before the first frame update
    void Start()
    {
        timersActive = false;
    }


    public void ShowHideTimers()
    {
        if (!timersActive)
        {
            foodManager.ShowTimers();
            allTimers.SetActive(true);
            timersActive = true;
            animator.SetBool("hide", false);
        }
        else {
            foodManager.HideTimers();
            animator.SetBool("hide", true);
            //allTimers.SetActive(false);
            timersActive = false;
        }
    }

}
