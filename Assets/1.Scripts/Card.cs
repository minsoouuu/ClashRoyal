using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Card : MonoBehaviour
{
    [SerializeField] private CardData unit;
    [SerializeField] private TMP_Text costText;
    [HideInInspector] public int index = 0;
    CardData cardData;

    public Card SetCardData(CardData cardData)
    {
        this.cardData = cardData;
        return this;
    }
    private void Start()
    {

    }
    public void OnCreateGoblin(int index)
    {
        HideIndex(index);
        Instantiate(ControllerManager.Instance.dataCont.datas[0].Char,ControllerManager.Instance.cardCont.pawnPoint);
    }

    public void SetCost(int cost)
    {
        costText.text = cost.ToString();
    }

    public void HideIndex(int index)
    {
        ControllerManager.Instance.cardCont.cards[index].transform.GetChild(0).gameObject.SetActive(false);
        ControllerManager.Instance.cardCont.ReShow(index);
    }
}
