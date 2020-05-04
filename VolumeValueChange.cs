using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueChange : MonoBehaviour
{
    //reference to audio source component
    private AudioSource audioSource;
    //volume variable
    private float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //access audio source component
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //set volume value
        audioSource.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
