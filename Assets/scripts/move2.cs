using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.Audio;

public class move2 : MonoBehaviour
{
    float speed = 4f;
    Vector3 mousePos, transPos, targetPos;
    [SerializeField]
    private Animator animator;
    float currentHp;
    public Text GameOver;
    private bool isDelay = false;
    public GameObject reStart;
    public bool gameOverSoundIsTure = true;

    public enum State
    {
        IDLE,
        RUN,
        DIE
    }
    public State state = State.IDLE;
    public Text food;

    public AudioClip gameOverSoundClip;
    private AudioSource gameOverSound;

    private void Awake()
    {
        

    }


    // Start is called before the first frame update
    void Start()
    {
        
        targetPos = new Vector3(transform.position.x, transform.position.y, 0);
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentHp = GameObject.Find("enemyDetect").GetComponent<HpBar>().currentHp;
        
        if (float.Parse(food.text) < 0 || currentHp <= 0 && gameOverSoundIsTure)
        {
            
            gameObject.GetComponent<AudioSource>().clip = gameOverSoundClip;
            gameOverSound = gameObject.GetComponent<AudioSource>();
            gameOverSound.Play();
            gameOverSoundIsTure = false;
        }
        if (float.Parse(food.text) < 0 || currentHp <= 0)
        {
            gameOverSoundIsTure = false;
            
            animator.SetBool("currentHpIsZero", true);
            state = State.DIE;
            GameOver.enabled = true;
            reStart.SetActive(true);
            StartCoroutine(Dietime());        
            if (isDelay)
            Time.timeScale = 0.0f;
        }

        animator.SetFloat("food", float.Parse(food.text));

        if (Input.GetMouseButtonDown(0) && state != State.DIE)
            CallTargetPos();

        if(state != State.DIE)
        MoveToTarget();
        
        if(targetPos == transform.position && state != State.DIE)
        {
            animator.SetBool("clickMove", false);
            state = State.IDLE;
        }
    }

    void CallTargetPos()
    {
        mousePos = Input.mousePosition;
        transPos = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos = new Vector3(transPos.x, transPos.y, 0);
        animator.SetBool("clickMove", true);
        state = State.RUN;
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        
    }

    IEnumerator Dietime()
    {
        yield return new WaitForSeconds(1.0f);
        isDelay = true;
    }
}
