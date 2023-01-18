using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NextCard : MonoBehaviour
{
    [SerializeField] Queue<CardData> cards = new Queue<CardData>();
    [SerializeField] private TMP_Text text;
    int cost = 0;

    void Awake()
    {
        InvokeRepeating("AddNextCard", 0f, 1f);
    }

    void Start()
    {
        text.text = cost.ToString();
    }

    void Update()
    {
        text.text = cost.ToString();
    }

    void AddNextCard()
    {
        for (int i = 0; i < 5; i++)
        {
            if (cards.Count > 5)
                return;
            int rand = Random.Range(0, ControllerManager.Instance.dataCont.datas.Length - 1);

            CardData so = ControllerManager.Instance.dataCont.datas[rand];
            cards.Enqueue(so);
        }
    }
    
    public CardData ShowNextCard()
    {
        return null;

    }
}
