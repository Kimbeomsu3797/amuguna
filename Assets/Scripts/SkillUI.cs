using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillUI : MonoBehaviour
{
    public Image chr;
    public TextMeshProUGUI skillName;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CardUISet(Skill skill)
    {
        chr.sprite = skill.skillImage;
        skillName.text = skill.skillName;
    }
}
