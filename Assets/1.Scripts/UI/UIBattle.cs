using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBattle : MonoBehaviour
{
    [SerializeField] private Button battleStart;
    // Start is called before the first frame update
    public void OnBattleStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
