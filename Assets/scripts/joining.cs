using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joining : MonoBehaviour
{

    public bool triggerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, 0, 0);
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            transform.parent.SetParent(other.transform);
            triggerOn = true;
        }

    }
}
