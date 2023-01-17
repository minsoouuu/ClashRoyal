using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Card : MonoBehaviour
{
    [SerializeField] private GameObject unit;
    [SerializeField] private TMP_Text costText;

    private void Start()
    {
    }
    public void OnCreateGoblin()
    {
        Instantiate(unit,ControllerManager.Instance.cardCont.pawnPoint);
        ControllerManager.Instance.cardCont.Count -= 1;
        // ControllerManager.Instance.uiCont.UseEnergy(goblin.charData.cost);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
