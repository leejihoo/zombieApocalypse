using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class reStart : MonoBehaviour
{
    public AudioSource clickSound;


    public void Start()
    {
        clickSound = gameObject.GetComponent<AudioSource>();
    }
    public void SceneChange()
    {
        clickSound.Play();
        SceneManager.LoadScene("zombieApocalypse");       
    }


}
