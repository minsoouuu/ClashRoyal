using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardController : MonoBehaviour
{
    [SerializeField] public Card[] cards;
    [SerializeField] private Transform cardPoint;
    [SerializeField] private NextCard nextCard;
    public Transform pawnPoint;

    private void Start()
    {
        StartCoroutine("CardSpawn");
    }

    IEnumerator CardSpawn()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].Enable(true)
                .SetParent(pawnPoint);
            CardData cardData = nextCard.CardDequeue();
            cards[i].SetCardData(cardData);
            cards[i].CardData = cardData;

            yield return new WaitForSeconds(1f);



            /*
            cards[i].Enable(true)
                .SetParent(pawnPoint)
                .SetCardData(nextCard.CardDequeue());
            
            yield return new WaitForSeconds(1f);
            */
        }
    }

    public void AddCard()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].Empty)
            {
                cards[i].Enable(true)
                    .SetParent(pawnPoint)
                    .SetCardData(nextCard.CardDequeue());
                cards[i].Empty = false;
                break;
            }
        }
    }
}
