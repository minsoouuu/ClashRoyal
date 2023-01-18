using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public CardData[] datas;

    // public Dictionary<string, ScriptableObject> dicDatas = new Dictionary<string, ScriptableObject>();

    string[] dataNames = {"Goblin"};
    private void Start()
    {
        int index = 0;
        foreach (var item in datas)
        {
            //dicDatas.Add(dataNames[index], datas[index]);
        }
    }
}
