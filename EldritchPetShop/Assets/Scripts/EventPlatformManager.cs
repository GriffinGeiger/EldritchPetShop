using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EventType
{
    Cultist,
    World,
    Both
}
public class EventPlatformManager : MonoBehaviour
{
    public EventType EventPlatformType;
    public GUIManager gui;
    private GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gui = FindObjectOfType<GUIManager>();
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Door Trigger");
        PetController pc = other.GetComponent<PetController>();
        if (pc != null)
        {
            GameManager.Pause();
            gui.DisplayEventbox(getRandomEvent(EventPlatformType,pc.petType), pc);
        }

    }
    private void Update()
    {
      
    }
    public EventEntry getRandomEvent(EventType eventType, PetType petType)
    {
        //Get flavor text for random event depending on the type 
        List<EventEntry> currentEventList;
        if (eventType == EventType.Cultist)
        {
            switch (petType)
            {
                case PetType.Cthulu:
                    currentEventList = gm.CthuluCultEvents;
                    break;
                case PetType.MiGo:
                    currentEventList = gm.MiGoCultEvents;
                    break;
                case PetType.Hastur:
                    currentEventList = gm.HasturCultEvents;
                    break;
                case PetType.Azathoth:
                    currentEventList = gm.AzathothCultEvents;
                    break;
                case PetType.ShubNiggurath:
                    currentEventList = gm.ShubCultEvents;
                    break;
                case PetType.Shoggoth:
                    currentEventList = gm.ShoggothCultEvents;
                    break;
                default:
                    return null;
            }
        }
        else if (eventType == EventType.World)
        {
            switch (petType)
            {
                case PetType.Cthulu:
                    currentEventList = gm.CthuluWorldEvents;
                    break;
                case PetType.MiGo:
                    currentEventList = gm.MiGoWorldEvents;
                    break;
                case PetType.Hastur:
                    currentEventList = gm.HasturWorldEvents;
                    break;
                case PetType.Azathoth:
                    currentEventList = gm.AzathothWorldEvents;
                    break;
                case PetType.ShubNiggurath:
                    currentEventList = gm.ShubWorldEvents;
                    break;
                case PetType.Shoggoth:
                    currentEventList = gm.ShoggothWorldEvents;
                    break;
                default:
                    return null;
            }
        }
        else
        {
            Debug.LogWarning("Shouldn't have an EventType.Both here");
            return null;
        }

        int randomChoice = Random.Range(0, currentEventList.Count);
        Debug.Log("CurrentEventList Length: " + currentEventList.Count);
        return currentEventList[randomChoice];
    }

}

[System.Serializable]
public class EventEntry
{
    public PetType[] PetTypes;
    public EventType eventType;
    public string eventText;
    public string optionAText;
    public string optionBText;
    [Header("OptionA Effects")]
    public double percentageOfFollowers_A;   //Positive gains followers, negative loses
    public int reputation_A;                 //Positive means more feared, negative makes it less feared
    public double money_A;                   //Positive or negative
    public int health_A;

    [Header("OptionB Effects")]
    public double percentageOfFollowers_B;   //Positive gains followers, negative loses
    public int reputation_B;                 //Positive means more feared, negative makes it less feared
    public double money_B;                   //Positive or negative
    public int health_B;

    public EventEntry Clone()
    {
        return (EventEntry) this.MemberwiseClone();
    }
}


