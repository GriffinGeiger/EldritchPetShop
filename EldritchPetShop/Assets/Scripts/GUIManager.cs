using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public int Money;
    public int Humans;
    public int Animals;
    public int Relics;

    void Start()
    {
        Money = 1000;
        Humans = 0;
        Animals = 0;
        Relics = 0;
    }

    
    void Update()
    {
        //Update Inventory GUI
    }

    public void DisplayTextbox(string text)
    {
        //Display textbox with text
    }

    public void DisplayEventbox(string text, string optionA, string optionB)
    {
        //Display textbox with text and two options as 2 buttons
    }

    public void SpendItem(string item)
    {
        if (item == "Human" & Humans > 0)
        {
            Humans--;
        }
        else if (item == "Animal" & Animals > 0)
        {
            Animals--;
        }
        else if (item == "Relic" & Relics >0 )
        {
            Relics--;
        }
        else
        {
            DisplayTextbox("Not enough items!");
        }
    }
}
