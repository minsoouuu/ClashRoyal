using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIShopItem : MonoBehaviour
{
    TMP_Text titleText;
    TMP_Text priceText;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void TitleText(string str)
    {
        if(titleText == null)
            titleText = transform.GetChild(0).GetComponent<TMP_Text>();
        titleText.text = str;
    }

    public void PirceText(string str)
    {
        if (priceText == null)
            priceText = transform.GetChild(2).GetComponent<TMP_Text>();
        priceText.text = str;
    }
}
