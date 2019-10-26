using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public float Price;
    //public int Owned;
    public string Name;
    //public PetController PC;
    //public bool hidden;
    public ShopManager SM;
    public bool Purchasing;
    public string ButtonType;
    //public GameObject Pet;

    void Start()
    {
        //Name = PC.petName;
        //Price = PC.price;
        //Owned = 0;
        //Purchasing = false;
        //hidden = true;
        SM = (ShopManager)GameObject.FindObjectOfType(typeof(ShopManager));
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
        //if () ;
    }
    public void ExitShop()
    {
        SM.CloseShop();
    }
}