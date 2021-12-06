using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class createEnemyRandom : MonoBehaviour
{
    public GameObject[] prefabs;
    private BoxCollider2D area;

    public int count = 10;

    private List<GameObject> gameObject = new List<GameObject>();
    private bool createCheck = true;

    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        //area.offset = new Vector2(-5, -10);
        area.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool checkDay = GameObject.Find("GameManage").GetComponent<dayAndNight>().checkDay;
        
        if (checkDay)
            createCheck = true;

        if (!checkDay && createCheck)
        {
            for (int i = 0; i < count; ++i)//count 수 만큼 생성한다
            {
                Spawn();//생성 + 스폰위치를 포함하는 함수
            }

            createCheck = false;
            count += 5;
        }
        

        
    }

    private void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length);

        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
    }
    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position +  new Vector3(-5, -10, 0);
        Vector3 size = area.size;



        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        //float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, 0);

        return spawnPos;
    }
}
