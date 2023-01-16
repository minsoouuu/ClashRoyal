using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public struct CharacterData
{
    public string findtag;
    public float attRange;
}

public abstract class Character : MonoBehaviour
{
    public CharacterData charData = new CharacterData();
    public NavMeshAgent agent;
    public Animator anit;
  
    // Update is called once per frame
    void Update()
    {
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
        }

    }
}
