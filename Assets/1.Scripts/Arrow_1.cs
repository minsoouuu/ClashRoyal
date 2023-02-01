using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_1 : Arrow
{
    public override void Initalize()
    {
        arrowData.damage = 50f;
        arrowData.attackDel = 5f;
    }
}
