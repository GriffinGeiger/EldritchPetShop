using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public float Price;
    //public int Owned;
    public string GodName;
    //public PetController PC;
    //public bool hidden;
    public ShopManager SM;
    public bool Purchasing;
    public string ButtonType;
    //public GameObject Pet;

    public GUIManager GUIMan;

    void Start()
    {
        //Name = PC.petName;
        //Price = PC.price;
        //Owned = 0;
        //Purchasing = false;
        //hidden = true;
        SM = (ShopManager)GameObject.FindObjectOfType(typeof(ShopManager));
        GUIMan = (GUIManager)GameObject.FindObjectOfType(typeof(GUIManager));
        //this.SetActive(true);
    }
    
    /*private void Press()
    {
        switch(ButtonType)
        {
            case "Buy":
                Purchase();
                break;
            case "Exit":
                ExitShop();
                break;
        }
    }*/

    public void Purchase()
    {
        switch(GodName)
        {
            case ("Sho"):
                if (GUIMan.Money >= SM.PriceSho)
                {
                    GUIMan.Money -= SM.PriceSho;
                    //summon
                }
                else
                {
                    //not enough money
                }
                break;
            case ("Mig"):
                if (GUIMan.Money >= SM.PriceMig)
                {
                    GUIMan.Money -= SM.PriceMig;
                    //summon
                }
                else
                {
                    //not enough money
                }
                break;
            case ("Cth"):
                if (GUIMan.Money >= SM.PriceCth)
                {
                    GUIMan.Money -= SM.PriceCth;
                    //summon
                }
                else
                {
                    //not enough money
                }
                break;
            case ("Has"):
                if (GUIMan.Money >= SM.PriceHas)
                {
                    GUIMan.Money -= SM.PriceHas;
                    //summon
                }
                else
                {
                    //not enough money
                }
                break;
            case ("Shu"):
                if (GUIMan.Money >= SM.PriceShu)
                {
                    GUIMan.Money -= SM.PriceShu;
                    //summon
                }
                else
                {
                    //not enough money
                }
                break;
            case ("Aza"):
                if (GUIMan.Money >= SM.PriceAza)
                {
                    GUIMan.Money -= SM.PriceAza;
                    //summon
                }
                else
                {
                    //not enough money
                }
                break;
        }
        
    }
    public void ExitShop()
    {
        SM.CloseShop();
    }
}