using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fpsCounter : MonoBehaviour
{

    public TextMeshProUGUI Text;

    private Dictionary<int, string> CachedNumberStrings = new Dictionary<int, string>();
    private int[] _frameRateSamples;
    private int _cacheNumbersAmount = 300;
    private int _averageFromAmount = 30;
    private int _averageCounter = 0;
    private int _currentAveraged;

    void Awake()
    {
        // Cache strings and create array
        {
            for (int i = 0; i < _cacheNumbersAmount; i++)
            {
                CachedNumberStrings[i] = i.ToString();
            }
            _frameRateSamples = new int[_averageFromAmount];
        }
    }
    void Update()
    {
         var currentFrame = (int)Math.Round(1f / Time.smoothDeltaTime); // If your game modifies Time.timeScale, use unscaledDeltaTime and smooth manually (or not).
         _frameRateSamples[_averageCounter] = currentFrame;

         var average = 0f;

         foreach (var frameRate in _frameRateSamples)
         {
             average += frameRate;
         }

          _currentAveraged = (int)Math.Round(average / _averageFromAmount);
          _averageCounter = (_averageCounter + 1) % _averageFromAmount;

        Text.text = _currentAveraged.ToString();
    }
    
}


