using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOn : MonoBehaviour
{
    public GameObject prefabDamege;
    public void DamegeTxt()
    {
        GameObject inst = Instantiate(prefabDamege, transform);
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
