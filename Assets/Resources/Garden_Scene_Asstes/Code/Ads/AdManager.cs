using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    public void Start()
    {
       
    }

    public void StartRewardedAdFertilizerOne()
    {
        RewardedAd.Instace.ShowAd();
    }
}
