using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class attackOfEnemy : MonoBehaviour
{
    private bool isDelay = false;
    private float delayTime = 1;
    public float AttackAmount;

    [SerializeField]
    private Animator animator;
    public AudioSource attackSound;

    // Start is called before the first frame update
    void Start()
    {
        attackSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CountAttackDelay()
    {
        yield return new WaitForSeconds(delayTime);
        animator.SetBool("isAttack", false);
        isDelay = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isDelay)
            {
                isDelay = true;
                attackSound.Play();
                animator.SetBool("isAttack", true);
                collision.GetComponentInChildren<HpBar>().Attacked(AttackAmount);
                StartCoroutine(CountAttackDelay());
            }



        }
    }
}
