using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff : MonoBehaviour
{
    public string type;
    public float percentage;
    public float duration;
    public float currentTime;
    public Image icon;

    PlayerControl player;
    private void Awake()
    {
        icon = GetComponent<Image>();
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    public void Init(string type, float per, float du)
    {
        this.type = type;
        percentage = per;
        duration = du;
        currentTime = duration;
        icon.fillAmount = 1;

        Execute();
    }

    WaitForSeconds seconds = new WaitForSeconds(0.1f);

    private void Execute()
    {
        player.onBuff.Add(this);
        player.ChooseBuff(type);
        StartCoroutine(Activation());
    }
    IEnumerator Activation()
    {
        while(currentTime > 0)
        {
            currentTime -= 0.1f;
            icon.fillAmount = currentTime / duration;
            yield return seconds;
        }
        icon.fillAmount = 0;
        currentTime = 0;
        DeActivation();
    }

    private void DeActivation()
    {
        player.onBuff.Remove(this);
        player.minusBuff(type);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
