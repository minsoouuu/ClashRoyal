using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Card : MonoBehaviour
{
    [SerializeField] private GameObject unit;
    [SerializeField] private TMP_Text costText;
    NextCard nextCard = new NextCard();

    private void Start()
    {

    }
    public void OnCreateGoblin(int index)
    {
        // ControllerManager.Instance.uiCont.UseEnergy(goblin.charData.cost);

        ControllerManager.Instance.cardCont.cards[index].transform.GetChild(0).gameObject.SetActive(false);
        Instantiate(unit,ControllerManager.Instance.cardCont.pawnPoint);
        ControllerManager.Instance.cardCont.Index = index;
        nextCard.nextCost++;
        print(nextCard.nextCost);
    }

    public void Cost(int cost)
    {
        costText.text = cost.ToString();
    }
}
