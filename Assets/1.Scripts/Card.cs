using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
public class Card : MonoBehaviour, IDragHandler, IDropHandler
{
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Transform parent;
    public CardData cardData;
    double costNum = 0;

    [SerializeField] Canvas canvas;
    RaycastHit hit;
    public int Cost { get; set; }
    public bool Empty { get; set; }

    void Start()
    {
        
    }

    void Update()
    {
        costText.text = Cost.ToString();
        costNum = ControllerManager.Instance.uiCont.num;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
        }

        /*
        double num = ControllerManager.Instance.uiCont.curEnergy;
        costNum = Math.Truncate(num * 10) / 10;
        */
    }

    public void OnSpawnUint()
    {
        /*
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
        */
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

    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (costNum >= Cost && !Empty)
        {
            if (hit.transform.tag.Equals("ray"))
            {
                Character unit = Instantiate(cardData.Char, parent);
                unit.cardData = cardData;
                unit.charData.findtag = "enemy";
                unit.tag = "my";
                unit.transform.position = new Vector3(hit.point.x, hit.point.y , hit.point.z);
                ControllerManager.Instance.cardCont.Invoke("AddCard", 1f);
                Enable(false);
                Empty = true;
                ControllerManager.Instance.uiCont.UseEnergy(Cost);
            }
        }
        StartCoroutine("CardPosInit");
    }

    IEnumerator CardPosInit()
    {
        transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = true; ;
    }
}
