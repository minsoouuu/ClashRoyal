using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UICard : MonoBehaviour , IDragHandler
{
    public Image targetImage = null;
    [SerializeField] private Transform parent;  
    RaycastHit hitData;
    GameObject hitObj;
    public void OnDrag(PointerEventData eventData)
    {
        if (targetImage != null)
        targetImage.transform.position = Input.mousePosition;
    }
    public void OnPointUP()
    {
        if (targetImage.sprite != null)
        {
            targetImage.color = new Color(1f, 1f, 1f, 1f/255f);
        }
    }
    public void OnPointDown()
    {
        if (targetImage.sprite == null)
        {
            Sprite sprite = GetComponent<Image>().sprite;
            targetImage.color = new Color(1f, 1f, 1f, 1f);
            targetImage.sprite = sprite;
            targetImage.transform.position = Input.mousePosition;
        }
    }
}
