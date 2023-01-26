using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Card : MonoBehaviour
{
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Transform parent;

    // Å×½ºÆ®
    public CardData CardData { get; set; }

    public int Cost { get; set; }
    public bool Empty { get; set; }

    private void Start()
    {
        
    }

    private void Update()
    {
        costText.text = Cost.ToString();
    }

    public void OnSpawnUint()
    {
        if (ControllerManager.Instance.uiCont.curEnergy >= Cost && !Empty)
        {
            Character character = Instantiate(CardData.Char, parent);
            character.charData.findtag = "enemy";
            character.tag = "my";
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
        this.CardData = cardData;
        Cost = this.CardData.Cost;
        Empty = false;
        return this;
    }
}
