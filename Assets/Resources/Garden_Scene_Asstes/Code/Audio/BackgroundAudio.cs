using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    public AudioClip natureSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Garden").GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.volume = 0.03f;

        gameObject.GetComponent<AudioSource>().clip = natureSound;
        gameObject.GetComponent<AudioSource>().volume = 0.04f;
        gameObject.GetComponent<AudioSource>().Play();
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
        return audioClips[Random.Range(0,audioClips.Length)];
    }

}
