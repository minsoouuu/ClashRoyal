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

    float maxEnergy = 10f;
    float curEnergy = 0f;
    float maxDump = 10f;
    float curDump = 0f;
    // Start is called before the first frame update
    void Start()
    {
        curDump = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float energyState = energy.fillAmount = curEnergy / maxEnergy;
        dumpEnergy.fillAmount = curDump / maxDump;
        text.text = string.Format($"{energyState * 10:F0}");
        Charge();
        if (Input.GetKeyDown(KeyCode.F3))
        {
            UseEnergy(1);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            curEnergy += 1f;
        }
    }
    void Charge()
    {
        if (curEnergy >= maxEnergy)
            return;
        curEnergy += Time.deltaTime;
        if (curEnergy > curDump)
        {
            curDump += 1f;
        }
    }
    public void UseEnergy(float cost)
    {
        if (curEnergy <= 0)
            return;
        curEnergy -= cost;
        if (curDump <= 1)
            return;
        curDump -= cost;
    }
}
