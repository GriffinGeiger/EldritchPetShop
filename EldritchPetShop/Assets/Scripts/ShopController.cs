using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public float Price;
    public bool Owned;
    public string Name;
    public PetController Controller;

    void Start()
    {
        Name = Controller.petName;
        Price = Controller.price;
        Owned = false;
    }

    void Update()
    {
        //if shop button clicked and owned = false
            //show purchase button
        //
        //if purchased button clicked
            Owned = true;
            //hide purchase button
        //
        //if exit button clicked
            //hide purchase button
        //
    }
}
