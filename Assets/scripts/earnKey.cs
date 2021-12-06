using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class earnKey : MonoBehaviour
{

    
    private string keyTextToString2;
    public Text keyTextToString;
    private AudioSource keyPickUp;
    private float delayTime = 1;
    private bool keyEarn =true;
    // Start is called before the first frame update
    void Start()
    {
        keyPickUp = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //keyTextToString2 = GameObject.Find("keyText").GetComponent<Text>().text;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && keyEarn)
        {
            keyEarn = false;
            keyPickUp.Play();
            //Debug.Log(keyTextToString2);
            GameObject.Find("keyText").GetComponent<Text>().text = (int.Parse(GameObject.Find("keyText").GetComponent<Text>().text) + (int)1).ToString();
            //Debug.Log(keyTextToString2);
            //keyTextToString.text = (int.Parse(keyTextToString.text) + (int)1).ToString();
            StartCoroutine(keyPicking());
        }
    }

    IEnumerator keyPicking()
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(this.gameObject);
    }
}
