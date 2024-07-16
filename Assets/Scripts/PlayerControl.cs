using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float HP = 100;
    public float MaxHP = 100;
    public Image hp_bar;
    
    public long att = 10;
    Animator animator;
    float Curtime = 0;

    GameObject Mon = null;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Curtime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            animator.SetBool("attack", false);
        }
        else
        {
            if(Curtime + 0.5f < Time.time)
            {
                Curtime = Time.time;
                animator.SetBool("attack", true);
                Mon.GetComponent<Monster>().Damage(att);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "monster")
        {
            GameManager.instance.isPlay = false;
            Mon = col.gameObject;
        }
    }
   public void Damage(int att)
    {
        HP -= att;
        hp_bar.fillAmount = HP / MaxHP;
        if (HP < 0)
        {

        }
    }
}
