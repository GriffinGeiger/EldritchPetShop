using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("References")] 
    public GameObject ExitButton;
    public InputField NameInput;
    public GameObject LastPurchasedPet;
    public GUIManager GUIMan;
    public Transform SpawnLocation;

    void Start()
    {
        Shop = this.gameObject;
        ShopButtons = (ShopButton[])GameObject.FindObjectsOfType(typeof(ShopButton));
        NameInput.onEndEdit.AddListener(NameYourGod);
        CloseShop();
    }

    private void NameYourGod(string name)
    {
        PetController pc = LastPurchasedPet.GetComponent<PetController>();
        pc.petName = name;
        pc.Nametag.text = name;
        
        foreach (ShopButton sb in ShopButtons)
        {
            GameObject go = sb.gameObject;
            go.SetActive(true);
        }
        NameInput.gameObject.SetActive(false);
        ExitButton.SetActive(true);
        ShopBook.SetActive(true);
    }

    public void OpenShop()
    {
        Debug.Log("OpeningShop");
        foreach (ShopButton sb in ShopButtons)
        {
            GameObject go = sb.gameObject;
            go.SetActive(true);
        }
        OpenShopButton.SetActive(false);
        ShopBook.SetActive(true);
        ExitButton.SetActive(true);
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
        ExitButton.SetActive(false);
    }
    public void Purchase(PetType pet)
    {
        GameObject newPet = null;
        switch (pet)
        {
            case (PetType.Shoggoth):
                if (GUIMan.Money >= PriceSho)
                {
                    GUIMan.Money -= PriceSho;
                    //summon
                    newPet = GameObject.Instantiate(ShoggothPrefab, SpawnLocation);
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
                    newPet = GameObject.Instantiate(MiGoPrefab, SpawnLocation);
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
                    newPet = GameObject.Instantiate(CthuluPrefab, SpawnLocation);
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
                    newPet = GameObject.Instantiate(HasturPrefab, SpawnLocation);
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
                    newPet = GameObject.Instantiate(ShubPrefab, SpawnLocation);
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
                    newPet = GameObject.Instantiate(AzathothPrefab, SpawnLocation);
                    //summon
                }
                else
                {
                    //not enough money
                }
                break;
        }

        //Name the Pet
        LastPurchasedPet = newPet;
        foreach (ShopButton sb in ShopButtons)
        {
            GameObject go = sb.gameObject;
            go.SetActive(false);
        }
        ExitButton.SetActive(false);
        NameInput.gameObject.SetActive(true);
        NameInput.text = LastPurchasedPet.GetComponent<PetController>().petName;
        ShopBook.SetActive(false);
    }


}
