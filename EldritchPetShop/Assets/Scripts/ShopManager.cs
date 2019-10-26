using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject Shop;
    public ShopButton[] ShopButtons;
    public GameObject OpenShopButton;

    //PRICES
    public int PriceSho;
    public int PriceMig;
    public int PriceCth;
    public int PriceHas;
    public int PriceShu;
    public int PriceAza;

    void Start()
    {
        Shop = this.gameObject;
        ShopButtons = (ShopButton[])GameObject.FindObjectsOfType(typeof(ShopButton));
        CloseShop();
    }

    public void OpenShop()
    {
        foreach (ShopButton sb in ShopButtons)
        {
            GameObject go = sb.gameObject;
            go.SetActive(true);
        }
        OpenShopButton.SetActive(false);
    }
    public void CloseShop()
    {
        foreach (ShopButton sb in ShopButtons)
        {
            GameObject go = sb.gameObject;
            go.SetActive(false);
        }
        OpenShopButton.SetActive(true);
    }
}
