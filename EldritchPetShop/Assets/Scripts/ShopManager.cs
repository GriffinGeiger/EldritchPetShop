﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject Shop;
    public ShopButton[] ShopButtons;
    public GameObject OpenShopButton;
    public GameObject ShopBook;

    //PRICES
    public int PriceSho;
    public int PriceMig;
    public int PriceCth;
    public int PriceHas;
    public int PriceShu;
    public int PriceAza;

    [Header("Prefabs")]
    public GameObject CthuluPrefab;
    public GameObject MiGoPrefab;
    public GameObject HasturPrefab;
    public GameObject AzathothPrefab;
    public GameObject ShubPrefab;
    public GameObject ShoggothPrefab;

    public GUIManager GUIMan;
    public Transform SpawnLocation;

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
        ShopBook.SetActive(true);
    }
    public void CloseShop()
    {
        foreach (ShopButton sb in ShopButtons)
        {
            GameObject go = sb.gameObject;
            go.SetActive(false);
        }
        OpenShopButton.SetActive(true);
        ShopBook.SetActive(false);
    }
    public void Purchase(PetType pet)
    {
        switch (pet)
        {
            case (PetType.Shoggoth):
                if (GUIMan.Money >= PriceSho)
                {
                    GUIMan.Money -= PriceSho;
                    //summon
                    GameObject.Instantiate(ShoggothPrefab, SpawnLocation);
                }
                else
                {
                    //not enough money
                }
                break;
            case (PetType.MiGo):
                if (GUIMan.Money >= PriceMig)
                {
                    GUIMan.Money -= PriceMig;
                    //summon
                    GameObject.Instantiate(ShoggothPrefab, SpawnLocation);
                }
                else
                {
                    //not enough money
                }
                break;
            case (PetType.Cthulu):
                if (GUIMan.Money >= PriceCth)
                {
                    GUIMan.Money -= PriceCth;
                    //summon
                    GameObject.Instantiate(ShoggothPrefab, SpawnLocation);
                }
                else
                {
                    //not enough money
                }
                break;
            case (PetType.Hastur):
                if (GUIMan.Money >= PriceHas)
                {
                    GUIMan.Money -= PriceHas;
                    GameObject.Instantiate(ShoggothPrefab, SpawnLocation);
                    //summon
                }
                else
                {
                    //not enough money
                }
                break;
            case (PetType.ShubNiggurath):
                if (GUIMan.Money >= PriceShu)
                {
                    GUIMan.Money -= PriceShu;
                    GameObject.Instantiate(ShoggothPrefab, SpawnLocation);
                    //summon
                }
                else
                {
                    //not enough money
                }
                break;
            case (PetType.Azathoth):
                if (GUIMan.Money >= PriceAza)
                {
                    GUIMan.Money -= PriceAza;
                    GameObject.Instantiate(ShoggothPrefab, SpawnLocation);
                    //summon
                }
                else
                {
                    //not enough money
                }
                break;
        }

    }
}
