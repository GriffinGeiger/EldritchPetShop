using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public float Price;
    //public int Owned;
    public PetType petType;
    //public PetController PC;
    //public bool hidden;
    public ShopManager SM;
    public bool Purchasing;
    public string ButtonType;
    //public GameObject Pet;

    [HideInInspector]
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
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Purchase);
    }
    
    void Purchase()
    {
        SM.Purchase(petType);
        
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

   
    public void ExitShop()
    {
        SM.CloseShop();
    }
}