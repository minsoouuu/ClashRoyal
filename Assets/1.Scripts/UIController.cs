using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
public class UIController : MonoBehaviour
{
    [SerializeField] private Image energy;
    [SerializeField] private Image dumpEnergy;
    [SerializeField] private TMP_Text text;
    [HideInInspector] public float curEnergy = 0f;
    [SerializeField] private GameObject reStartImage;
    float maxEnergy = 10;
    float curDump = 0f;
    [HideInInspector] public double num;
    public bool isOn = true;
    [HideInInspector] public int castleCount = 3;
    [SerializeField] TMP_Text goldtext;
    int gold = 0;
    public int Gold
    {
        get { return gold; }

        set
        {
            gold = value;
        }
    }
    void Start()
    {
        //reStartImage.gameObject.SetActive(false);
        curDump = maxEnergy / 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOn)
            return;
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

    public void ShowImage()
    {
        reStartImage.gameObject.SetActive(true);
        isOn = false;
    }

    public void UseEnergy(float cost)
    {
        curEnergy -= cost * (maxEnergy / 10);
        curDump -= cost * (maxEnergy / 10);
    }
    public void OnEndGame(bool restart)
    {

        if (restart)
        {
            isOn = true;
            SceneManager.LoadScene("SampleScene");
            reStartImage.gameObject.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("Main");
            reStartImage.gameObject.SetActive(false);
        }
        gold = 1000;
    }
}
