using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class eatFood : MonoBehaviour
{
    public AudioSource eatFoodSound;
    
    private float delayTime = 1;
    private bool eat = true;
    //public Text moveEnergyText;
    // Start is called before the first frame update
    void Start()
    {
        eatFoodSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && eat)
        {
            eat = false;
            eatFoodSound.Play();
            float f = GameObject.Find("GameManage").GetComponent<foodLack>().currentFood + (float)30;
            GameObject.Find("GameManage").GetComponent<foodLack>().currentFood =  Mathf.Ceil(f);        
            StartCoroutine(eatingTime());
            
        }
    }

    IEnumerator eatingTime()
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(this.gameObject);
    }
}
