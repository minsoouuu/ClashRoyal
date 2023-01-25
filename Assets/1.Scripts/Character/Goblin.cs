using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Character
{
    void Start()
    {
        charData.findtag = "enemy";
        charData.attRange = 1.5f;
        charData.damage = 1f;
        charData.attTime = 1f;
        charData.hp = 10f;
    }
}
