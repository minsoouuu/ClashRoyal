using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardController : MonoBehaviour
{
    [SerializeField] private Card[] cards;
    [SerializeField] private Transform cardPoint;
    public Transform pawnPoint;
    int count = 0;
    float time = 0f;

    public int Count
    {
        get { return count; }
        set { count = value; }
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
      
    }

    IEnumerator ShowCard()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
        }
    }
   
}
