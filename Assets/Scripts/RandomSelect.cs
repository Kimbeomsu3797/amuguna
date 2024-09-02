using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelect : MonoBehaviour
{
    public List<Skill> deck = new List<Skill>();
    public int total = 0;
    public Transform parent;
    public GameObject skillPrefab;
    Coroutine sc;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < deck.Count; i++)
        {
            total += deck[i].weight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandomStart()
    {
        if(sc== null)
        {
            for(int i = 0; i<skillob.Count; i++)
            {
                Destroy(skillob[i]);
                result.Clear();
            }
            
            sc = StartCoroutine("ResultSelect");
        }
    }
    public List<Skill> result = new List<Skill>();
    public List<GameObject> skillob = new List<GameObject>();
    IEnumerator ResultSelect()
    {
        for(int i = 0; i<20; i++)
        {
            result.Add(RandomCard());
            GameObject skillUI = Instantiate(skillPrefab, parent);
            skillUI.GetComponent<SkillUI>().CardUISet(result[i]);
            skillob.Add(skillUI);
            yield return new WaitForSeconds(0.2f);
        }
        sc = null;
    }
    public Skill RandomCard()
    {
        int weight = 0;
        int selectNum = 0;
        selectNum = Mathf.RoundToInt(total * Random.Range(0f, 1f));

        for(int i = 0; i < deck.Count; i++)
        {
            weight += deck[i].weight;
            if(selectNum <= weight)
            {
                Skill temp = new Skill(deck[i]);
                return temp;
            }
        }
        return null;
    }
}
