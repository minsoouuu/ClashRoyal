using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCard : MonoBehaviour
{
    [SerializeField] Queue<NextCard> cards;
    [SerializeField] private NextCard nextCard;
    [SerializeField] Transform nextCardPoint;
    int createCnt = 0;
    bool showNext = true;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        AddNextCard();
    }

    void AddNextCard()
    {
        if (createCnt < 5) return;   
        cards.Enqueue(nextCard);
        createCnt++;
    }
   
    void ShowNextCard()
    {
        if (!showNext) return;
        NextCard next = cards.Dequeue();
        Instantiate(next, nextCardPoint);
    }


}
