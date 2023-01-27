using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Castle : MonoBehaviour
{
    [SerializeField] private float maxHP;
    [SerializeField] Image hpImage;
    public float CurHP { get; set; }
    void Start()
    {
        CurHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        hpImage.fillAmount = CurHP / maxHP;
        if (CurHP <= 0) Destroy(gameObject);
    }
}
