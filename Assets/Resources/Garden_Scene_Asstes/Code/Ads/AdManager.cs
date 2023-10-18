using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    public void Start()
    {
        BannerAd.Instace.LoadBanner();
    }

    public void StartRewardedAdFertilizerOne()
    {
        RewardedAd.Instace.ShowAd();
    }
}
