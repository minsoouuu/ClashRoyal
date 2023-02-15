using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GoldShop
{
    public string title;
    public int price;
}

public class UIShop : MonoBehaviour
{
    [SerializeField] private UIShopItem[] uIShopItems;
    List<GoldShop> goldShops = new List<GoldShop>();
    // Start is called before the first frame update
    void Start()
    {
        string[] titles = { "100G", "500g", "1000g", "3000G", "5000G", "10000G" };
        int[] prices = { 100, 500, 1000, 3000, 5000, 100000000 };
        for (int i = 0; i < uIShopItems.Length; i++)
        {
            GoldShop gs = new GoldShop();
            gs.title = titles[i];
            gs.price = prices[i];
            goldShops.Add(gs);
        }
        for (int i = 0; i < uIShopItems.Length; i++)
        {
            uIShopItems[i].TitleText(goldShops[i].title);
            uIShopItems[i].PirceText(string.Format("{0:#,###}¿ø", goldShops[i].price)); 
        }
    }
}
