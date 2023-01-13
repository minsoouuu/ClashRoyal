using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image energy;
    [SerializeField] private Image dumpEnergy;
    [SerializeField] private TMP_Text text;

    float maxEnergy = 21;
    float curEnergy = 0f;
    float curDump = 0f;
    // Start is called before the first frame update
    void Start()
    {
        curDump = maxEnergy / 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        float energyState = energy.fillAmount = curEnergy / maxEnergy;
        dumpEnergy.fillAmount = curDump / maxEnergy;
        // text.text = string.Format($"{energyState * 10:F0}");
        Charge();
        if (Input.GetKeyDown(KeyCode.F3))
        {
            UseEnergy(5);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            curEnergy += maxEnergy / 10f;
        }
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
        
    }
}
