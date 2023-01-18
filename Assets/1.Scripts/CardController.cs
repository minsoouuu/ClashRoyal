using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardController : MonoBehaviour
{
    [SerializeField] public Card[] cards;
    [SerializeField] private Transform cardPoint;
    public Transform pawnPoint;
    int hidenIndex = 0;
    public int Index
    {
        get { return hidenIndex; }
        set { hidenIndex = value; }
    }

    private void Awake()
    {
        foreach (Card item in cards)
        {
            item.transform.GetChild(0).gameObject.SetActive(false);
        }
       
    }
    void Start()
    {
        StartCoroutine(ShowCard());
    }
    void Update()
    {
        if (!cards[Index].IsOn())
        {
            ReShow();
        }
    }

    IEnumerator ShowCard()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < cards.Length; i++)
        {
            int rand = Random.Range(1, 10);
            cards[i].SetCost(rand);
            cards[i].transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
        }
    }

    public void ReShow()
    {
         cards[cards.]
         cards[Index].gameObject.SetActive(true);
    }
}
