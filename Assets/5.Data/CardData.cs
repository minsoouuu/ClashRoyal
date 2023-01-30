using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardData",menuName = "MyCardData/CardData")]
public class CardData : ScriptableObject
{
    [SerializeField] Character character;
    public Character Char { get { return character; } }

    [SerializeField] Image image;
    public Image Image { get { return image; } }

    [SerializeField] int speed;
    public int Speed { get { return speed; } }

    [SerializeField] int cost;
    public int Cost { get  { return cost; } }
    [SerializeField] float damage;
    public float Damage { get { return damage; } }
    [SerializeField] float hp;
    public float HP { get { return hp; } }
    [SerializeField] float attTime;
    public float AttTime { get { return attTime; } }
    [SerializeField] float attRange;
    public float AttRange { get { return attRange; } }

}
