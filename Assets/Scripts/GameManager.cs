using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float gameSpeed = 3;
    public bool isPlay = true;

    public float Money = 1000;
    public Text MoneyTxt;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        MoneyTxt.text = Money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            gameSpeed = 3;
        }
        else
        {
            gameSpeed = 0;
        }
    }
    public void SetMoney(float money)
    {
        Money += money;
        StartCoroutine(Count(Money, Money - money)); // ������ ������ �߰��� ���� ���������� ���� ������ ��尡 �����ϴ¸��
    }
    IEnumerator Count(float target, float current) //0,-1000 // 1000, 0
    {
        
        float duration = 0.5f; // ī���ÿ� �ɸ��� �ð�
        float offset = (target - current) / duration;

        while (current < target)
        {
            current += offset * Time.deltaTime;

            MoneyTxt.text = string.Format("{0:n0}", (int)current);
            yield return null;
        }
        current = target;

        MoneyTxt.text = string.Format("{0:n0}", (int)current);
    }
    
}
