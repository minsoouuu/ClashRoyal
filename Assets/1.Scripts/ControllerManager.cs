using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager Instance;
    public UIController uiCont;
    public CardController cardCont;

    private void Awake() => Instance = this;
}
