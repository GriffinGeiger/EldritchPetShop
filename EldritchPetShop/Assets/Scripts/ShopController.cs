using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public float Price;
    public bool Owned;
    public string Name;
    public PetController PC;
    public bool hidden;
    public ShopManager SM;
    public bool Purchasing;
    public GameObject Pet;

    void Start()
    {
        Name = PC.petName;
        Price = PC.price;
        Owned = false;
        Purchasing = false;
        hidden = true;
        SM = (ShopManager)GameObject.FindObjectOfType(typeof(ShopManager));
    }

    void Update()
    {
        hidden = SM.HideShop;
        if (hidden == false & Owned == false)
        {
            Pet.SetActive(true);
        }
        if (Purchasing == true)
        {
            Owned = true;
            Pet.SetActive(false);
            //Add Monster to House
        }
        if (hidden == true)
        {
            Pet.SetActive(false);
        }
    }

    public void PetButtonPress()
    {
        Purchasing = true;
    }
}