using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Card : MonoBehaviour
{
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Transform parent;
    public CardData cardData;
    double costNum;

    public int Cost { get; set; }
    public bool Empty { get; set; }

    void Start()
    {
        
    }

    void Update()
    {
        costText.text = Cost.ToString();
        double num = ControllerManager.Instance.uiCont.curEnergy;
        costNum = Math.Truncate(num * 10);
    }

    public void OnSpawnUint()
    {
        
        if (costNum >= Cost && !Empty)
        {
            Character unit = Instantiate(cardData.Char, parent);
            unit.cardData = cardData;
            unit.charData.findtag = "enemy";
            unit.tag = "my";
            ControllerManager.Instance.cardCont.Invoke("AddCard", 1f);
            Enable(false);
            Empty = true;
            ControllerManager.Instance.uiCont.UseEnergy(Cost);
        }
    }

    public Card Enable(bool isOn)
    {
        transform.GetChild(0).gameObject.SetActive(isOn);
        return this;
    }

    public Card SetParent(Transform transform)
    {
        this.parent = transform;
        return this;
    }

    public Card SetCardData(CardData cardData)
    {
        this.cardData = cardData;
        Cost = this.cardData.Cost;
        Empty = false;
        return this;
    }
}
