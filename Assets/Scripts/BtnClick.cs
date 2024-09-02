using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BtnClick : MonoBehaviour
{
    public string type;
    public float per;
    public float duration;
    public Sprite icon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        int buffCount = GameObject.Find("Player").GetComponent<PlayerControl>().onBuff.Count;

        if (buffCount >= 5)
        {
            return;
        }
        BuffMgr.instance.CreateBuff(type, per, duration, icon);
    }
}
