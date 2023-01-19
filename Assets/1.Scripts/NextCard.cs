using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NextCard : MonoBehaviour
{
    [SerializeField] public Queue<int> cards = new Queue<int>();
    [SerializeField] private TMP_Text text;
    [HideInInspector] public int curCost = 0;

    void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            int rand = Random.Range(0, 10);
            cards.Enqueue(rand);
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

    void AddNextCard()
    {
        for (int i = cards.Count; cards.Count < 5; i++)
        {
            int rand = Random.Range(0,10);

            // CardData so = ControllerManager.Instance.dataCont.datas[rand];
            cards.Enqueue(rand);
        }
    }
    public void SetCurCost()
    {
        int curNum = cards.Dequeue();
        curCost = curNum;
    }
    public int ShowNextCard()
    {
        int nextNum = cards.Dequeue();
        curCost = nextNum;
        print("다음 숫자" + nextNum);
        return nextNum;
    }
}
