using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NextCard : MonoBehaviour
{

    [SerializeField] public Queue<CardData> cards = new Queue<CardData>();
    [SerializeField] private TMP_Text text;
    [HideInInspector] public int curCost = 0;

    void Awake()
    {
        
        for (int i = 0; i < 10; i++)
        {
            int rand = Random.Range(0, ControllerManager.Instance.dataCont.datas.Length - 1);
            cards.Enqueue(ControllerManager.Instance.dataCont.datas[rand]);
        }
        InvokeRepeating("AddNextCard", 0f, 1f);
    }

    void Start()
    {

    }

    void Update()
    {
        text.text = curCost.ToString();
    }

    public CardData SetCost(CardData cardData)
    {
        return cards.Dequeue();
    }

    void AddNextCard()
    {
        for (int i = cards.Count; cards.Count < 5; i++)
        {
            int rand = Random.Range(0,10);

            CardData so = ControllerManager.Instance.dataCont.datas[rand];
            cards.Enqueue(so);
        }
    }
    public void SetCurCost()
    {
        CardData curNum = cards.Dequeue();
        curCost = curNum.Cost;
    }
    public CardData ShowNextCard()
    {
        CardData nextNum = cards.Dequeue();
        curCost = nextNum.Cost;
        print("다음 숫자" + nextNum);
        return nextNum;
    }
}
