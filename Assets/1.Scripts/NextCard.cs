using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NextCard : MonoBehaviour
{
    [SerializeField] Queue<int> cards;
    [SerializeField] private NextCard nextCard;
    [SerializeField] Transform nextCardPoint;
    [SerializeField] private TMP_Text text;
    [HideInInspector] public int nextCost = 5;
    public int createCnt = 0;
    
    public int CreateCnt
    {
        get { return createCnt; }
        set { createCnt = value; }
    }

    void Start()
    {
        InvokeRepeating("AddNextCard", 1f, 1f);
        text.text = nextCost.ToString();
    }

    void Update()
    {
        text.text = nextCost.ToString();
    }

    void AddNextCard()
    {
        if (createCnt < 5) return;   
        cards.Enqueue(nextCost);
        createCnt++;
        nextCost++;
    }
    
    void ShowNextCard()
    {
        ControllerManager.Instance.cardCont.ReShow(nextCost);
        nextCost++;
        createCnt--;
        text.text = nextCost.ToString();
    }
}
