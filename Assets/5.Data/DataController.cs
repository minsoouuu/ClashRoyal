using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public CardData[] datas;
    public List<CardData> picupCds;
    // public Dictionary<string, ScriptableObject> dicDatas = new Dictionary<string, ScriptableObject>();

    public void Init()
    {
        string[] strs = PlayerPrefs.GetString("mycard").Split(",");

        foreach (var str in strs)
        {
            if (str == "-1")
                continue;

            foreach (var data in datas)
            {
                if (str == data.Icon.name)
                {
                    picupCds.Add(data);
                    break;
                }
            }
        }
    }
}
