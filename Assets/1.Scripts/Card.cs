using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject unit;
    public Transform unitPoint;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnCreateGoblin()
    {
        Instantiate(unit,unitPoint);
    }
}
