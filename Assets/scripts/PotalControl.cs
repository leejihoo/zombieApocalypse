using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotalControl : MonoBehaviour
{
    public Text keyCount;
    static bool potalIsOpen = true;
    int countKey;
    int countBread;
    int countSubCharater;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (countKey < 3)
        {
            GameObject.Find("ramdomPositionForClear" + Random.Range(1, 10)).GetComponent<randomPotal>().SpawnKey();
            countKey++;
        }

        if (countBread < 5)
        {
            GameObject.Find("ramdomPositionForClear" + Random.Range(1, 10)).GetComponent<randomPotal>().SpawnBread();
            countBread++;
        }

        if (countSubCharater < 1)
        {
            GameObject.Find("ramdomPositionForClear" + Random.Range(1, 10)).GetComponent<randomPotal>().SpawnSubCharater();
            countSubCharater++;
        }






        if (keyCount.text == "3" && potalIsOpen)
        {
            GameObject.Find("ramdomPositionForClear" + Random.Range(1, 10)).GetComponent<randomPotal>().Spawn();
            potalIsOpen = false;
        }


    }
}
