using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : MonoBehaviour
{
    public Slider hpBar;
    public float maxHp;
    public float currentHp;
    public Animator animator;
    private bool isDelay = false;
    private float delayTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        hpBar.value = currentHp / maxHp;

    }

    public void Attacked(float attack) {
        currentHp -= attack;
    }
}
