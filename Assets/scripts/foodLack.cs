using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class foodLack : MonoBehaviour
{
    public Text food;
    public Text GameOver;
    public float currentFood = 60;
    public AudioClip gameOverSoundClip;
    private AudioSource gameOverSound;
    private bool gameOverSoundIsTrue =true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentFood -= Time.deltaTime;
        food.text = Mathf.Ceil(currentFood).ToString();

        if (float.Parse(food.text) < 0 && gameOverSoundIsTrue)
        {
            gameOverSoundIsTrue = false;
            gameObject.GetComponent<AudioSource>().clip = gameOverSoundClip;
            gameOverSound = gameObject.GetComponent<AudioSource>();
            gameOverSound.Play();
        }

        if (float.Parse(food.text) < 0)
        {
            
            GameOver.enabled = true;
            GameObject.Find("parentForReStart").transform.Find("reStart").gameObject.SetActive(true);
            Time.timeScale = 0.0f;

        }
    }
}
