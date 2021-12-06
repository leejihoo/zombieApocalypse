using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameClear : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource clearSound;
    private float delayTime = 2;
    //public GameObject reStart;
    void Start()
    {
        clearSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            clearSound.Play();
            GameObject.Find("gameClear").GetComponent<Text>().enabled = true;
            GameObject.Find("parentForReStart").transform.Find("reStart").gameObject.SetActive(true);

            StartCoroutine(ClearSoundPlay());
            
            Time.timeScale = 0.0f;
            
        }
    }

    IEnumerator ClearSoundPlay()
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(this.gameObject);
    }
}
