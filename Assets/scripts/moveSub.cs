using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static move2;

public class moveSub : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    bool triggerOn= false;
    bool makeFriend = true;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var child = transform.Find("TriggerObj");
        triggerOn = child.GetComponent<joining>().triggerOn;
        
        if (triggerOn)
        {

           
            if (makeFriend)
            {
                gameObject.GetComponent<Attack>().enabled = true;
                transform.localPosition = new Vector3(-5, 0, 0);
                gameObject.GetComponent<FixedJoint2D>().connectedBody = gameObject.transform.parent.GetComponent<Rigidbody2D>();
                gameObject.GetComponent<FixedJoint2D>().enabled = true;
                makeFriend = false;
            }
            

            var parentState = gameObject.transform.parent.GetComponent<move2>().state;
            
            if (parentState == State.RUN)
            {
                animator.SetBool("Move", true);
            }
            else if (parentState == State.IDLE)
            {
                animator.SetBool("Move", false);
            }
            else if(parentState == State.DIE)
            {
                animator.SetBool("die", true);
            }
        }

    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(other.tag == "Player") 
    //    {
    //        Debug.Log("트리거온");
    //        transform.SetParent(other.transform);
    //        triggerOn = true;
    //    }

    //}
}
