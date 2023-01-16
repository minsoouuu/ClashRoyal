using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public GameObject prefab;
    public Transform createPoint;
    int count = 0;
    float time = 0f;
    void Start()
    {
        
    }
    void Update()
    {
        if (count.Equals(4))
            return;
        time += Time.deltaTime;
        if (time > 3)
        {
            CreateCard();
            time = 0f;
            count++;
        }
    }
    void CreateCard()
    {
        Instantiate(prefab, createPoint);
    }
}
