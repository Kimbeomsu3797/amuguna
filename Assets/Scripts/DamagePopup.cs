using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DamagePopup : MonoBehaviour
{
    public GameObject canvas;
    GameObject player;
    //일반데미지와, 크리데미지 구분을 위해
    public Color color = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        Text tmp_text = GetComponentInChildren<Text>();
        if(color == Color.red)
        {
            tmp_text.text = player.GetComponent<PlayerControl>().att.ToAttackString();
            Debug.Log(18);
        }
        else
        {
            tmp_text.text = "Cretical" + player.GetComponent<PlayerControl>().att.ToAttackString();
            Debug.Log(17);
        }

        //tmp_text.color = color;
        tmp_text.DOFade(0f, 1.0f);
        tmp_text.DOColor(color, 1.0f);

        transform.DOPunchScale(Vector3.one, 1);
        transform.DOMove(transform.position + Vector3.up * 2, 1).OnComplete(() =>
        {
            Destroy(canvas);
        });
    }

    // Update is called
    // once per frame
    void Update()
    {
        
    }
}
