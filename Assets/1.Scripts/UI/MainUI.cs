using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image imagePrefab;
    [SerializeField] private Transform cardTrans;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            imagePrefab = Instantiate(imagePrefab, cardTrans);
            imagePrefab.sprite = sprites[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
