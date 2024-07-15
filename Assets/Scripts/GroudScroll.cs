using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudScroll : MonoBehaviour
{
    public Vector3 oriPos;
    //public float Speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        oriPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            if (transform.position.x <= -24f)
            {
                transform.position = oriPos;
            }
            transform.Translate(Vector3.left * GameManager.instance.gameSpeed * Time.deltaTime);
        }
    }
}
