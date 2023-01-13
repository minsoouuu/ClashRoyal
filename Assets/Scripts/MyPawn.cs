using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPawn : MonoBehaviour
{
    [SerializeField] private GameObject pawn;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject ui;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSpawnUnit(int cost)
    {
        Instantiate(pawn, spawnPoint);
        ui.GetComponent<UIController>().UseEnergy(cost);
    }
}
