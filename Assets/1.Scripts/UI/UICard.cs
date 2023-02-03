using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UICard : MonoBehaviour , IDragHandler
{
    Image targetImage = null;
    [SerializeField] private Transform parent;
    public void OnDrag(PointerEventData eventData)
    {
        if (targetImage != null)
        targetImage.transform.position = Input.mousePosition;
    }
    public void OnPointUP()
    {
        if (targetImage != null)
        {
            targetImage.color = new Color(1f, 1f, 1f, 1f/255f);
        }
        targetImage = null;
    }

    public void OnPointDown()
    {
        if(targetImage == null)
        targetImage = FindObjectOfType<UICardMove>().GetComponent<Image>();
        Sprite sprite = GetComponent<Image>().sprite;
        targetImage.color = new Color(1f, 1f, 1f, 1f);
        targetImage.sprite = sprite;
        targetImage.transform.position = Input.mousePosition;
    }
}
