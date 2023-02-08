using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBattle : MonoBehaviour
{
    [SerializeField] private Button battleStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBattleStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
