using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MainUI : MonoBehaviour
{
    [SerializeField] public Image[] myCardImages;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image imagePrefab;
    [SerializeField] private Transform cardTrans;

    [HideInInspector] public string[] myNums;
    [SerializeField] private List<CardData> cardDatas;
    [SerializeField] private TMP_Text goldtext;
   
    void Start()
    {
        
        for (int i = 0; i < myCardImages.Length; i++)
        {
            myCardImages[i].GetComponent<UIMyCard>().index = i;
        }
        CreateCard();
        /*
        for (int i = 0; i < sprites.Length; i++)
        {
            imagePrefab = Instantiate(imagePrefab, cardTrans);
            imagePrefab.sprite = sprites[i];
        }
        */
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("mycard")))
        {
            string[] arrayStr = new string[] { "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1" };
            myNums = arrayStr;
            DataSave();
        }
        else
        {
            MyCardSeting();
        }
    }

    void Update()
    {
        if (ControllerManager.Instance.uiCont.Gold.Equals(null))
        {
            return;
        }
        goldtext.text = ControllerManager.Instance.uiCont.Gold.ToString();

    }

    void CreateCard()
    {
        List<Image> myCardImages = new List<Image>();
        foreach (var item in sprites)
        {
            Image img = Instantiate(imagePrefab, cardTrans);
            img.sprite = item;
            img.color = new Color(1f,1f,1f,0.5f);
            img.raycastTarget = false;

            myCardImages.Add(img);
        }

        for (int i = 0; i < cardDatas.Count; i++)
        {
            for (int j = 0; j < myCardImages.Count; j++)
            {
                if (cardDatas[i].Icon.name == myCardImages[j].sprite.name)
                {
                    myCardImages[j].color = new Color(1f, 1f, 1f, 1f);
                    myCardImages[j].raycastTarget = true;
                    break;
                }
            }
        }
    }
    public bool IsSprite(Sprite sprite)
    {
        bool b = true;
        for (int i = 0; i < myCardImages.Length; i++)
        {
            if (myCardImages[i].sprite.name == sprite.name)
            {
                b = false;
            }
        }
        return b;
    }

    public void DataSave()
    {
        string str = string.Empty;
        for (int i = 0; i < myNums.Length; i++)
        {
            str += myNums[i];
            if (i != (myNums.Length - 1))
            {
                str += ",";
            }
        }
        PlayerPrefs.SetString("mycard", str);
    }

    public void MyCardSeting()
    {
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("mycard")))
        {
            string[] strs = PlayerPrefs.GetString("mycard").Split(",");
            myNums = strs;
            for (int i = 0; i < strs.Length; i++)
            {
                // int num = int.Parse(strs[i]);
                if (strs[i] != "-1")
                {
                    Sprite sprite = null;
                    foreach (var item in sprites)
                    {
                        if (strs[i] == item.name)
                        {
                            sprite = item;
                            break;
                        }
                    }

                    if (sprite != null)
                    {
                          myCardImages[i].sprite = sprite;
                          myCardImages[i].color = new Color(1f, 1f, 1f, 1f);
                    }
                }
                else
                {
                    myCardImages[i].color = new Color(1f,1f,1f,0.5f);
                }
            }
        }
    }
}
