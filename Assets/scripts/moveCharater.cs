using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class moveCharater : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject charater;


    private void Update()
    {
        onMouseOver();

    }


    //���콺�� Ÿ�� ���� ��ġ�� ���� �۾��� ���̱� ������ onMouseOver�� ����߽��ϴ�.

    //�����ϸ� ������ �ϴ°͵� ������ ���׿�.

    private void onMouseOver()
    {
        try
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue, 3.5f);



            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector3.zero);
            



            if (this.tilemap = hit.transform.GetComponent<Tilemap>())
            {
                //this.tilemap.RefreshAllTiles();

                int x, y;
                
                x = this.tilemap.WorldToCell(ray.origin).x;
                y = this.tilemap.WorldToCell(ray.origin).y;
                
                Vector3Int v3Int = new Vector3Int(x, y, 0);
                Vector3Int[] vector3intarr = new Vector3Int[9];






                if (Input.GetMouseButtonDown(0))
                {
                    int n = 0;
                    Debug.Log(v3Int);
                    while (charater.transform.position != ray.origin)
                    {
                        charater.transform.position = Vector3.MoveTowards(charater.transform.position, ray.origin, 0.02f * Time.deltaTime);
                    }
                    
                    //3x3 �迭 ����
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            //Debug.Log(n);
                            vector3intarr[n] = new Vector3Int(i, j, 0);
                            n++;

                        }
                    }

                 
                }

            }




        }
        catch (System.NullReferenceException)
        {

        }
    }
    private void onMouseExit()
    {
        this.tilemap.RefreshAllTiles();

    }


}
