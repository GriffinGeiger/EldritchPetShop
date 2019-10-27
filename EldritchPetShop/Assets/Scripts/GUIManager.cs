using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public double Money;
    public int Humans;
    public int Animals;
    public int Relics;
    public GameObject MoneyDisplay;
    public GameObject RelicDisplay;
    public GameObject AnimalDisplay;
    public GameObject HumanDisplay;
    public GameObject EventPopupGUI;

    void Start()
    {

    }

    
    void Update()
    {
        //Update Inventory GUI
        MoneyDisplay.GetComponent<UnityEngine.UI.Text>().text = "$" + ((int)(Money)).ToString();
        RelicDisplay.GetComponent<UnityEngine.UI.Text>().text = (Relics).ToString();
        AnimalDisplay.GetComponent<UnityEngine.UI.Text>().text = (Animals).ToString();
        HumanDisplay.GetComponent<UnityEngine.UI.Text>().text = (Humans).ToString();
    }

    public void DisplayTextbox(string text)
    {
        //Display textbox with text
    }

    public void DisplayEventbox(EventEntry entry, PetController pet)
    {
        //Display textbox with text and two options as 2 buttons
        EventPopupGUI.SetActive(true);
        //replace name text with monster name \name
        string eventText = entry.eventText.Replace("\\name", pet.petName.ToString());
        string optionAText = entry.optionAText.Replace("\\name", pet.petName.ToString());
        string optionBText = entry.optionBText.Replace("\\name", pet.petName.ToString());

        Text[] texts = EventPopupGUI.GetComponentsInChildren<Text>();
        foreach(Text t in texts)
        {
            if (t.gameObject.CompareTag("ButtonA"))
                t.text = optionAText;
            else if (t.gameObject.CompareTag("ButtonB"))
                t.text = optionBText;
            else if(t.gameObject.CompareTag("EventText"))
                t.text = eventText;
        }

        EventChoiceButton[] buttons = FindObjectsOfType<EventChoiceButton>();
        foreach(EventChoiceButton b in buttons)
        {
            b.currentEntry = entry;
            b.currentPet = pet;
        }
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
