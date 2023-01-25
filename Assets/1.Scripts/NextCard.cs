using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NextCard : MonoBehaviour
{

    [SerializeField] private TMP_Text text;
    public Queue<CardData> cards = new Queue<CardData>();

    CardData nextcard = null;
    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            int rand = Random.Range(0, ControllerManager.Instance.dataCont.datas.Length);
            CardData card = ControllerManager.Instance.dataCont.datas[rand];
            cards.Enqueue(card);
           
        }
        nextcard = cards.Dequeue();
        InvokeRepeating("CardEnqueue", 0f, 0.5f);
    }

    private void Update()
    {
        if (nextcard == null)
        {
            text.text = $"{nextcard.Cost}";
        }
    }
    void CardEnqueue()
    {
        if (cards.Count >= 5)
        {
            return;
        }
        int rand = Random.Range(0, ControllerManager.Instance.dataCont.datas.Length);
        CardData card = ControllerManager.Instance.dataCont.datas[rand];
        cards.Enqueue(card);
    }

    public CardData CardDequeue()
    {
        CardData card = nextcard;
        nextcard = cards.Dequeue();
        return card;
    }
}
