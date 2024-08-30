using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public float HP = 100;
    public float MaxHP = 100;
    public float dex = 1000;
    public float def = 1;
    public float cre = 1000;
    public long att = 1000;
    public long creatt;

    public Image hp_bar;
    
    Animator animator;
    float Curtime = 0;

    GameObject Mon = null;
    //알림 메세지
    public TextMeshProUGUI Noti;
    //스텟
    public TextMeshProUGUI AttackTxt;
    public TextMeshProUGUI HpTxt;
    public TextMeshProUGUI DefTxt;
    public TextMeshProUGUI DexTxt;
    public TextMeshProUGUI CreTxt;
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
            if(Curtime + (2 - (dex*0.001f)) < Time.time)
            {
                
                animator.SetBool("attack", true);
                //Mon.GetComponent<Monster>().Damage(att);
                Curtime = Time.time;
                int creRan = Random.Range(1, 101);
                if (creRan < (cre * 0.01f))
                {
                    Critical(creRan);
                }
                else
                {
                    Mon.GetComponent<Monster>().Damage(att);
                }
            }
        }
        animator.speed = dex * 0.001f;
    }
    public void Critical(int creRan)
    {

        
            creatt = att * creRan;
            Mon.GetComponent<Monster>().CreDamage(creatt);

      
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "monster")
        {
            GameManager.instance.isPlay = false;
            Mon = col.gameObject;
        }
    }
   public void Damage(long att)
    {
        HP -= (att - (def/1000));
        hp_bar.fillAmount = HP / MaxHP;
        if (HP < 0)
        {
            Noti.text = "체력이 0이되면 공격속도가 최저로 리셋됩니다.";
            dex = 500;
            HP = 0;
        }
        else
        {
            Noti.text = "";
        }
    }
    public void AttackUP()
    {
        if(GameManager.instance.Money < 1000)
        {
            Debug.Log("금액이 적습니다.");
        }
        else
        {
            GameManager.instance.SetMoney(-1000);
            att += 1000;
            AttackTxt.text = "현재 공격력 : " + att;
        }
    }
    public void HpUp()
    {
        if(GameManager.instance.Money < 1000)
        {
            Debug.Log("금액이 적습니다");
        }
        else
        {
            GameManager.instance.SetMoney(-1000);
            HP += 100;
            if(HP>= MaxHP)
            {
                MaxHP = HP;
            }
            HpTxt.text = "현재 체력 : " + HP;
        }
    }
    public void DefUp()
    {
        if (GameManager.instance.Money < 1000)
        {
            Debug.Log("금액이 적습니다");
        }
        else
        {
            GameManager.instance.SetMoney(-1000);
            def += 100;

            DefTxt.text = "현재 민첩성 : " + def;
        }
    }
    public void DexUp()
    {
        if (GameManager.instance.Money < 1000)
        {
            Debug.Log("금액이 적습니다");
        }
        else
        {
            GameManager.instance.SetMoney(-1000);
            dex += 1;
            GameManager.instance.gameSpeed += (dex * 0.001f);

            DexTxt.text = "현재 민첩성 : " + dex*0.001f;
        }
    }
    public void CreUp()
    {
        if (GameManager.instance.Money < 1000)
        {
            Debug.Log("금액이 적습니다");
        }
        else
        {
            GameManager.instance.SetMoney(-1000);
            cre += 1;

            CreTxt.text = "현재 민첩성 : " + cre * 0.001f;
        }
    }
}
