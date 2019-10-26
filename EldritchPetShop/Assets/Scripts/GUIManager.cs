using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GUIManager : MonoBehaviour
{
    public double Money;
    public int Humans;
    public int Animals;
    public int Relics;
    public GameObject MoneyDisplay;

    void Start()
    {
        Money = 150000;
        Humans = 0;
        Animals = 0;
        Relics = 0;
    }

    
    void Update()
    {
        //Update Inventory GUI
        MoneyDisplay.GetComponent<UnityEngine.UI.Text>().text = "$" + ((int)(Money)).ToString();
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
