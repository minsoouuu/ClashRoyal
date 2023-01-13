using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Castle : MonoBehaviour
{
    [SerializeField] private float maxHP;
    [SerializeField] Image hpImage;
    float curHP = 0f;
    void Start()
    {
        curHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        hpImage.fillAmount = curHP / maxHP;
        if (Input.GetKeyDown(KeyCode.F1))
        {
            curHP -= 100f;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            curHP += 100f;
        }
    }
}
