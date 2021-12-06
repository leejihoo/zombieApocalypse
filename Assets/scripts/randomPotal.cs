using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomPotal : MonoBehaviour
{
    private BoxCollider2D area;
    //private string keyCount;
    public Text keyCount;
    public GameObject potal;
    public GameObject key;
    public GameObject bread;
    public GameObject subCharater;
    private List<GameObject> gameObject = new List<GameObject>();
    //bool count = true;
    //static bool potalIsOpen = true;
    
    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        area.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //keyCount = GameObject.Find("keyText").GetComponent<Text>().text;
        //if(keyCount.text == "1"  && potalIsOpen)
        //{
        //    Spawn();
        //    potalIsOpen = false;
        //}
    }

    public void Spawn()
    {
        

        

        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        GameObject instance = Instantiate(potal, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
    }

    public void SpawnKey()
    {




        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        GameObject instance = Instantiate(key, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
    }

    public void SpawnBread()
    {




        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        GameObject instance = Instantiate(bread, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
    }

    public void SpawnSubCharater()
    {




        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        GameObject instance = Instantiate(subCharater, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;



        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        

        Vector3 spawnPos = new Vector3(posX, posY, 0);

        return spawnPos;
    }
}
