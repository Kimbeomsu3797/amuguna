using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffMgr : MonoBehaviour
{
    public static BuffMgr instance;
    public GameObject buffPrefab;
    private void Awake()
    {
        instance = this;  
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateBuff(string type, float per, float du, Sprite icon)
    {
        
        GameObject go = Instantiate(buffPrefab,transform);
        
        go.GetComponent<Buff>().Init(type, per, du);
        go.GetComponent<Image>().sprite = icon;
    }
}
