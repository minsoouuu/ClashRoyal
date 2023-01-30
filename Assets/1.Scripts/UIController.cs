using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class UIController : MonoBehaviour
{
    [SerializeField] private Image energy;
    [SerializeField] private Image dumpEnergy;
    [SerializeField] private TMP_Text text;
    [HideInInspector] public float curEnergy = 0f;
    float maxEnergy = 20;
    float curDump = 0f;
    [HideInInspector] public double num;
    // Start is called before the first frame update

  
    void Start()
    {
        curDump = maxEnergy / 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        double energyState = energy.fillAmount = curEnergy / maxEnergy;
        dumpEnergy.fillAmount = curDump / maxEnergy;
        num = Math.Truncate(energyState * 10);
        text.text = num.ToString();
        Charge();
    }
    void Charge()
    {
        if (curEnergy >= maxEnergy)
            return;

        curEnergy += Time.deltaTime;

        if (curEnergy >= curDump)
        {
            curDump += maxEnergy / 10f;
        }

    }
    public void UseEnergy(float cost)
    {
        curEnergy -= cost * (maxEnergy / 10);
        curDump -= cost * (maxEnergy / 10);
    }
    void Test()
    {
        double testEnergy = curEnergy / maxEnergy;
        double b = Math.Truncate(testEnergy*10);
        text.text = (b / 10).ToString();
    }
}
