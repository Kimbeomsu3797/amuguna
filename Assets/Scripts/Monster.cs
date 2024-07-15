using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int HP = 100;
    int oriHP;//max hp
    public Vector2 StartPosition;

    //동전
    //public itemfx prefabitem;
    public GameObject money;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        oriHP = HP;
        //머니가 생성되서 골드ui좌표로 이동하는 연출을 위한 목적지(좌표)
        target = GameObject.Find("Gold").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.instance.gameSpeed);
            if (transform.position.x < -16)
            {
                gameObject.SetActive(false);
                transform.position = StartPosition;
            }
        }
    }
    public void Damage(int att)
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
            gameObject.SetActive(false);
            transform.position = StartPosition;
            //HP = 100;
            HP = oriHP;
            GameManager.instance.isPlay = true;
        }
    }
}
