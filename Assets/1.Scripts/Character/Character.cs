using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public struct CharacterData
{
    public string findtag;
}

public abstract class Character : MonoBehaviour
{
    public CharacterData charData = new CharacterData();
    public NavMeshAgent agent;
    public Animator anit;
    CardData cardData;
    float time = 0f;
    float maxHP;

    private void Start()
    {
        
    }
    void Update()
    {
        time += Time.deltaTime;
        GameObject[] characters = GameObject.FindGameObjectsWithTag(charData.findtag);
        if (characters.Length.Equals(0)) return;

        float distance = 100f;
        GameObject findTarget = null;
        foreach (var character in characters)
        {
            float dis = Vector3.Distance(agent.transform.position, character.transform.position);
            if (distance > dis)
            {
                findTarget = character;
                distance = dis;
            }
        }
        if (findTarget == null) return;

        if (cardData.AttRange < distance)
        {
            anit.SetTrigger("run");
            agent.SetDestination(findTarget.transform.position);

        }
        else
        {
            anit.SetTrigger("idle");
            agent.SetDestination(transform.position);
            anit.SetTrigger("attack");
            if (cardData.AttTime < time)
            {
                // Attack(findTarget);
                time = 0f;
            }
        }

        if (cardData.HP <= 0)
        {
            // Die
        }

    }
    public virtual void Attack(GameObject target)
    {
        // 건물
        if (target.name == "Main" || target.name == "Right" || target.name == "Left")
        {
            target.GetComponent<Castle>().CurHP -= cardData.HP;
        }
        // 캐릭터
        else
        {
        }
    }
   
}
