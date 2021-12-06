using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerdetect : MonoBehaviour
{
    public enum State
    {
        IDLE,
        DETECT,
        ATTACK,
        DEAD
    }

    public State state = State.IDLE;
    private NavMeshAgent nvAgent;
    private Transform playerTransform;
    bool isDay = true;
    public Animator animator;
    private bool isDelay = false;
    private float delayTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        nvAgent.updateRotation = false;
        nvAgent.updateUpAxis = false;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<HpBar>().currentHp > 0)
            nvAgent.destination = playerTransform.position;
        else if (gameObject.GetComponent<HpBar>().currentHp <= 0 && !isDelay)
        {
            isDelay = true;
            animator.SetBool("isDie", true);
            StartCoroutine(CountDieDelay());
        }

        isDay = GameObject.Find("GameManage").GetComponent<dayAndNight>().checkDay;

        if (isDay)
        {
            Destroy(this.gameObject);
        }

    }

    IEnumerator CountDieDelay()
    {
        yield return new WaitForSeconds(delayTime);
        animator.SetBool("isAttack", false);
        Destroy(this.gameObject);
        isDelay = false;

    }
}
