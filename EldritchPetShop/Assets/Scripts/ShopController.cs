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

    void Start()
    {
        Name = PC.petName;
        Price = PC.price;
        Owned = false;
        Purchasing = false;
        hidden = true;
    }

    void Update()
    {
        hidden = SM.HideShop;
        if (hidden == false & Owned == false)
        {
            //Show Monster button
        }
        if (Purchasing == true)
        {
            Owned = true;
            //Hide Monster Button
            //Add Monster to House
        }
        if (hidden == true)
        {
            //Hide Monster Button
        }
    }

    public void PetButtonPress()
    {
        Purchasing = true;
    }
}