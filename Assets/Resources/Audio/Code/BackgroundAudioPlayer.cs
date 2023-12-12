using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioPlayer : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    void Awake()
    {
       DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        }
    }

    private AudioClip GetRandomClip()
    {
        return audioClips[Random.Range(0, audioClips.Length)];
    }

    /*
     Surreal Forest by Meydän | https://linktr.ee/meydan
     Music promoted by https://www.chosic.com/free-music/all/
     Creative Commons CC BY 4.0
     https://creativecommons.org/licenses/by/4.0/
 
     Contemplate the stars by Meydän | https://linktr.ee/meydan
     Music promoted by https://www.chosic.com/free-music/all/
     Creative Commons CC BY 4.0
     https://creativecommons.org/licenses/by/4.0/
     */
}
