using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Attack : MonoBehaviour
{
    private bool isDelay = false;
    private float delayTime = 1;
    public float AttackAmount;
    public AudioSource attackSound;
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if(collision.tag == "enemy" && gameObject.GetComponent<Attack>().enabled)
        {
            if (!isDelay)
            {
                attackSound = gameObject.GetComponent<AudioSource>();
                isDelay = true;
                attackSound.Play();
                animator.SetBool("isAttack", true);
                collision.GetComponent<HpBar>().Attacked(AttackAmount);
                StartCoroutine(CountAttackDelay());
            }
               
            
            
        }
    }
}
