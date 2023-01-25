using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public struct CharacterData
{
    public float attTime;
    public float damage;
    public string findtag;
    public float attRange;
    public float hp;
}

public abstract class Character : MonoBehaviour
{
    public CharacterData charData = new CharacterData();
    public NavMeshAgent agent;
    public Animator anit;
    CardData cardData;
    float time = 0f;
    public float HP
    {
        set { charData.hp -= value; }
    }    // Update is called once per frame
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

        if (charData.attRange < distance)
        {
            anit.SetTrigger("run");
            agent.SetDestination(findTarget.transform.position);

        }
        else
        {
            anit.SetTrigger("idle");
            agent.SetDestination(transform.position);
            anit.SetTrigger("attack");
            if (charData.attTime < time)
            {
                Attack(findTarget);
                time = 0f;
            }
        }

        if (charData.hp <= 0)
        {
            Die();
        }

    }
    public virtual void Attack(GameObject target)
    {
        if (target.tag == "castle")
        {
            target.gameObject.GetComponent<Castle>().CurHP -= charData.damage;
        }
        else if (target.tag == "enemy")
        {
            target.gameObject.GetComponent<Character>().HP = charData.damage;
        }
    } 

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
