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
    NextCard nc = new NextCard();
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

    }

    IEnumerator ShowCard()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].Cost(i+1);
            cards[i].transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
        }
    }

    public void ReShow(int index)
    {
        cards[index].GetComponent<TMP_Text>().text = index.ToString();
        cards[index].transform.GetChild(0).gameObject.SetActive(true);
    }
}
