using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public struct CharacterData
{
    public string findtag;
}

public abstract class Character : MonoBehaviour
{
    public CharacterData charData = new CharacterData();
    public NavMeshAgent agent;
    public Animator anit;
    public CardData cardData;
    float curHp = 0;
    float time = 0f;
    [SerializeField] Image hpImage;

    public float Damage
    {
        set { curHp -= value; }
    }
    private void Start()
    {
        
    }
    void Update()
    {
        if (!ControllerManager.Instance.uiCont.isOn)
        {
            anit.speed = 0;
            return;
        }
        hpImage.fillAmount = curHp / cardData.HP;
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
        if (findTarget == null)
        {
            anit.SetTrigger("idle");
            return;
        }

        if (cardData.AttRange < distance)
        {
            anit.SetTrigger("run");
            agent.SetDestination(findTarget.transform.position);

        }
        else
        {
            anit.SetTrigger("idle");
            transform.LookAt(findTarget.transform);
            agent.SetDestination(transform.position);
            anit.SetTrigger("attack");

            if (cardData.AttTime < time)
            {
                Attack(findTarget);
                time = 0f;
            }
        }

        if (curHp <= 0)
        {
            Die();
        }

    }
    void Attack(GameObject target)
    {
        // 건물
        if (target.name == "Main" || target.name == "Right" || target.name == "Left")
        {
            target.GetComponent<Castle>().CurHP -= cardData.Damage;
        }

        // 캐릭터
        else
        {
            target.GetComponent<Character>().Damage = cardData.Damage;
        }
    }
    public virtual void SetHp()
    {
        curHp = cardData.HP;
    }

    void Die()
    {
        Destroy(gameObject);
    }
   
}
