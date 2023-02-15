using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Castle : MonoBehaviour
{
    [SerializeField] private float maxHP;
    [SerializeField] Image hpImage;
    [SerializeField] private Arrow_1 arrow;
    [SerializeField] private Transform parent;
    float time;

    public int CastleCount
    {
        get { return CastleCount; }
        set 
        {
            CastleCount = value;
            if (CastleCount == 0)
            {
                ControllerManager.Instance.uiCont.OnImage();
            }
        }
    }
    public float CurHP { get; set; }
    void Start()
    {
        CastleCount = 3;
        CurHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ControllerManager.Instance.uiCont.isOn)
            return;
        time += Time.deltaTime;
        hpImage.fillAmount = CurHP / maxHP;
        if (CurHP <= 0)
        {
            Destroy(gameObject);
            CastleCount -= 1;
        }




        return;
        GameObject[] targets = GameObject.FindGameObjectsWithTag("my");
        if (targets.Length == 0)
        {
            return;
        }
        float dis = 0;
        GameObject findtarget = null;
        foreach (GameObject item in targets)
        {
            findtarget = item;
        }
        dis = Vector3.Distance(transform.position, findtarget.transform.position);
        /*
        Vector3 dir = findtarget.transform.position - transform.position;
        float shotDir = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        */
        if (arrow != null)
        {
            if (findtarget != null)
            {
                if (dis < 5)
                {
                    arrow.Initalize();
                    if (arrow.arrowData.attackDel < time)
                    {
                        parent.LookAt(findtarget.transform);
                        arrow = Instantiate(arrow, parent);
                        time = 0;
                    }
                }
            }
        }
    }
}
