using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMyCard : MonoBehaviour
{
    [SerializeField] Sprite orginImage;
    [SerializeField] Image changeImage;
    
    [HideInInspector] public int index;

    MainUI cont;
    Image image;
    void Start()
    {
        image = GetComponent<Image>();
        cont = FindObjectOfType<MainUI>();
    }
    public void OnDrop()
    {
        if (changeImage.sprite == null)
            return;
        cont.myNums[index] = changeImage.sprite.name;
        cont.DataSave();
        if (!cont.IsSprite(changeImage.sprite))
            return;
        image.sprite = changeImage.sprite;
        image.color = new Color(1f, 1f, 1f, 1f);
        changeImage.sprite = null;
        Debug.Log(PlayerPrefs.GetString("mycard"));
    }

    public void OnClick()
    {
        cont.myNums[index] = "-1";
        cont.DataSave();
        image.color = new Color(1f, 1f, 1f, 120f / 255f);
        image.sprite = orginImage;
        Debug.Log(PlayerPrefs.GetString("mycard"));

        // cont.DeleteSprite(index);
    }
}
