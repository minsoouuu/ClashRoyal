using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    float createTime = 0f;
    [SerializeField] private Character prefab;
    [SerializeField] private Transform parent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Character character = Instantiate(prefab,parent);
            character.charData.findtag = "my";
            character.tag = "enemy";
            // Debug.Log(prefab.charData.findtag);
        }
    }
}
