using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public bool HideShop;

    void Start()
    {
        HideShop = true;
    }

    void Update()
    {
        if(HideShop == false)
        {
            //Display Shop UI
        }
        if (HideShop == true)
        {
            //Hide Shop UI
        }
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
