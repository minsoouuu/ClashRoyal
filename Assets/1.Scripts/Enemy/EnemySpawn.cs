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
            Character character = Instantiate(cardDatas[0].Char, parent); 
            character.cardData = cardDatas[0];
            character.charData.findtag = "my";
            character.tag = "enemy";
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Character character = Instantiate(cardDatas[1].Char, parent);
            character.cardData = cardDatas[1];
            character.charData.findtag = "my";
            character.tag = "enemy";
            Debug.Log(character.charData.findtag);
            Debug.Log(character.tag);
        }
    }
}
