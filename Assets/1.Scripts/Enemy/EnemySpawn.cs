using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private CardData[] cardDatas = new CardData[4];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            EnemySpawns(1);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            EnemySpawns(2);
        }
    }

    void EnemySpawns(int index)
    {
        Character character = Instantiate(cardDatas[index].Char, parent);
        character.cardData = cardDatas[0];
        character.charData.findtag = "my";
        character.tag = "enemy";
    }
}
