using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FertilizerProgressBar : MonoBehaviour
{
    public Slider slider;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
