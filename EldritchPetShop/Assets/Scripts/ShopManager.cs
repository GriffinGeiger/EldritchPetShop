using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public bool HideShop;
    GameObject Shop;

    void Start()
    {
        HideShop = true;
        Shop = this.gameObject;
    }

    void Update()
    {
        Shop.SetActive(!HideShop);
    }

    public void ButtonPress()
    {
        HideShop = false;
    }

    public void ExitButtonPress()
    {
        HideShop = true;
    }
}
