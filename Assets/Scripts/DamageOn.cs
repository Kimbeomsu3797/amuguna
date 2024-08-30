using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOn : MonoBehaviour
{
    public GameObject prefabDamege;
    public GameObject CreDamage;
    public void DamegeTxt()
    {
        GameObject inst = Instantiate(prefabDamege, transform);
        inst.transform.SetParent(transform);
        Debug.Log(16);
    }
    public void CreDamageTxt()
    {
        GameObject inst = Instantiate(CreDamage, transform);
        inst.transform.SetParent(transform);
        Debug.Log(15);
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
