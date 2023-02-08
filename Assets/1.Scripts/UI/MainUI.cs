using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainUI : MonoBehaviour
{
    [SerializeField] private Image[] MyCardImages;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image imagePrefab;
    [SerializeField] private Transform cardTrans;

    [HideInInspector] public string[] myNums;

    void Start()
    {
        for (int i = 0; i < MyCardImages.Length; i++)
        {
            MyCardImages[i].GetComponent<UIMyCard>().index = i;
        }
        for (int i = 0; i < sprites.Length; i++)
        {
            imagePrefab = Instantiate(imagePrefab, cardTrans);
            imagePrefab.sprite = sprites[i];
        }
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
                        MyCardImages[i].sprite = sprite;
                        MyCardImages[i].color = new Color(1f, 1f, 1f, 1f);

                    }
                }
                else
                {
                    MyCardImages[i].color = new Color(1f,1f,1f,0.5f);
                }
            }
        }
    }
}
