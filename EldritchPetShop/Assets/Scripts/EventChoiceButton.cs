using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventChoiceButton : MonoBehaviour
{
    public bool optionA;
    public EventEntry currentEntry;
    public PetController currentPet;
    public GameObject EventPrompt;

    public void OptionSelected()
    {
        FindObjectOfType<GUIManager>().Money += optionA ? currentEntry.money_A: currentEntry.money_B;
        currentPet.followers += ((optionA ? currentEntry.percentageOfFollowers_A : currentEntry.percentageOfFollowers_B) / 100) * currentPet.followers;
        currentPet.currentReputation += optionA ? currentEntry.reputation_A : currentEntry.reputation_B;
        currentPet.petHealth += optionA ? currentEntry.health_A : currentEntry.health_B;
        EventPrompt.SetActive(false);
        currentPet.desireStrength = 5;
        currentPet.currentDesire = Desire.Wander;
        GameManager.Resume();
    }
}
