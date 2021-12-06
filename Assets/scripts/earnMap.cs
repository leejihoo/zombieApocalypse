using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class earnMap : MonoBehaviour
{
    public Text key;
    public Image map;
    public AudioClip earnMapSoundClip;
    private AudioSource earnMapSound;
    private bool mapEarn = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(key.text == "3" && mapEarn)
        {
            mapEarn = false;
            gameObject.GetComponent<AudioSource>().clip = earnMapSoundClip;
            earnMapSound = gameObject.GetComponent<AudioSource>();
            earnMapSound.Play();
            map.enabled = true;
        }
    }
}
