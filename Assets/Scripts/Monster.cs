using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Monster : MonoBehaviour
{
    public long HP = 100;
    long oriHP;//max hp
    public Vector2 StartPosition;
    GameObject player;
    //동전
    //public itemfx prefabitem;
    public GameObject money;
    public Transform target;
    public Animator animator;
    float Curtime = 0f;
    public int att = 10;
    // Start is called before the first frame update
    void Start()
    {
        oriHP = HP;
        //머니가 생성되서 골드ui좌표로 이동하는 연출을 위한 목적지(좌표)
        target = GameObject.Find("Gold").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.instance.gameSpeed);
            if (transform.position.x < -14)
            {
                gameObject.SetActive(false);
                transform.position = StartPosition;
            }
        }
        else
        {
            if (Curtime >= 1)
            {
                float dis = Vector3.Distance(player.transform.position, transform.position);

                if(dis <= 3)
                {
                    animator.SetBool("Attack", true);
                    player.GetComponent<PlayerControl>().Damage(att);
                    Curtime = 0;

                }
                
            }
            Curtime += Time.deltaTime;
        }
    }
    public void Damage(long att)
    {
        HP -= att;
        if (HP <= 0)
        {
            int randCount = Random.Range(5, 10);
            for(int i = 0; i < randCount; ++i)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                //var itemFx = Instantiate(prefabItem, screenPos, Quaternion.identity);
                GameObject itemFx = Instantiate(money, screenPos, Quaternion.identity);
                itemFx.transform.SetParent(GameObject.Find("Canvas").transform);
                itemFx.GetComponent<ItemFx>().Explosion(screenPos, target.position, 150f);
            }
            GameManager.instance.SetMoney(Random.Range(50, 100));
            gameObject.SetActive(false);
            transform.position = StartPosition;
            //HP = 100;
            HP = oriHP;
            GameManager.instance.isPlay = true;
             
        }
        else
        {
            DamageOn damageTxt = GetComponent<DamageOn>();
            damageTxt.DamegeTxt();
            Debug.Log(14);
        }
    }
    public void CreDamage(long creatt)
    {
        HP -= creatt;

        DamageOn damageTxt = GetComponent<DamageOn>();
        damageTxt.CreDamageTxt();
        Debug.Log(13);
        //
    }
}
