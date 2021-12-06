using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.Universal;

public class dayAndNight : MonoBehaviour
{
    public Text dayAndNight_;
    public Text timeLimit;
    float setTime = 10;
    public bool checkDay = true;
    
    



    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(setTime > 0)
        {
            setTime -= Time.deltaTime;

            timeLimit.text = Mathf.Ceil(setTime).ToString();
        }
        else if(setTime <= 0)
        {            
            if (checkDay) {
                setTime = 15;
                dayAndNight_.text = "¹ã:";
                GameObject.Find("Global Light 2D").GetComponent<Light2D>().intensity = 0.2f;
                //GlobalLight.intensity = 0.3f;
                checkDay = false;
            }
            else
            {
                setTime = 10;
                dayAndNight_.text = "³·:";
                GameObject.Find("Global Light 2D").GetComponent<Light2D>().intensity = 1f;
                checkDay = true;
            }            
        }
        
    }
}
