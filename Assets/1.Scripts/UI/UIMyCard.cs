using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMyCard : MonoBehaviour
{
    [SerializeField] Sprite orginImage;
    [SerializeField] Image changeImage;
    Image image;
    void Start()
    {
        image = GetComponent<Image>();

    }
    public void OnDrop()
    {
        image.sprite = changeImage.sprite;
        image.color = new Color(1f, 1f, 1f, 1f);
        Debug.Log(gameObject);
    }

    public void OnClick()
    {
        image.color = new Color(1f, 1f, 1f, 120f / 255f);
        image.sprite = orginImage;
    }
}
