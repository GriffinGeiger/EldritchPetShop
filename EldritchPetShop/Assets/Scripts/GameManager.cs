using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{
    public GameObject maxMovementArea;
    public GameObject minMovementArea;
    public GameObject doorToWorld;
    public GameObject circleToCult;
    public float timescale = 1000; // 1000 years per second
    public EventEntry[] Events;
    public List<EventEntry> AzathothWorldEvents;
    public List<EventEntry> CthuluWorldEvents;
    public List<EventEntry> MiGoWorldEvents;
    public List<EventEntry> HasturWorldEvents;
    public List<EventEntry> ShubWorldEvents;
    public List<EventEntry> ShoggothWorldEvents;
    public List<EventEntry> AzathothCultEvents;
    public List<EventEntry> CthuluCultEvents;
    public List<EventEntry> MiGoCultEvents;
    public List<EventEntry> HasturCultEvents;
    public List<EventEntry> ShubCultEvents;
    public List<EventEntry> ShoggothCultEvents;

    void Start()
    {
        
         AzathothWorldEvents.Clear();
         CthuluWorldEvents.Clear();
         MiGoWorldEvents.Clear();
         HasturWorldEvents.Clear();
         ShubWorldEvents.Clear();
         ShoggothWorldEvents.Clear();
         AzathothCultEvents.Clear();
         CthuluCultEvents.Clear();
         MiGoCultEvents.Clear();
         HasturCultEvents.Clear();
         ShubCultEvents.Clear();
         ShoggothCultEvents.Clear();

 
        //Fill EventEntry 
        foreach(EventEntry ee in Events)
        {
            foreach (PetType et in ee.PetTypes)
            {
                if (ee.eventType == EventType.Cultist || ee.eventType == EventType.Both)
                {
                    switch (et)
                    {
                        case PetType.Cthulu:
                            CthuluCultEvents.Add(ee.Clone());
                            break;
                        case PetType.MiGo:
                            MiGoCultEvents.Add(ee.Clone());
                            break;
                        case PetType.Hastur:
                            HasturCultEvents.Add(ee.Clone());
                            break;
                        case PetType.Azathoth:
                            AzathothCultEvents.Add(ee.Clone());
                            break;
                        case PetType.ShubNiggurath:
                            ShubCultEvents.Add(ee.Clone());
                            break;
                        case PetType.Shoggoth:
                            ShoggothCultEvents.Add(ee.Clone());
                            break;
                        default:
                            break;
                    }
                }

                if (ee.eventType == EventType.World || ee.eventType == EventType.Both)
                {
                    switch (et)
                    {
                        case PetType.Cthulu:
                            CthuluWorldEvents.Add(ee.Clone());
                            break;
                        case PetType.MiGo:
                            MiGoWorldEvents.Add(ee.Clone());
                            break;
                        case PetType.Hastur:
                            HasturWorldEvents.Add(ee.Clone());
                            break;
                        case PetType.Azathoth:
                            AzathothWorldEvents.Add(ee.Clone());
                            break;
                        case PetType.ShubNiggurath:
                            ShubWorldEvents.Add(ee.Clone());
                            break;
                        case PetType.Shoggoth:
                            ShoggothWorldEvents.Add(ee.Clone());
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {

    }

    public Vector3 GenerateRandomWanderPoint()
    {
        return new Vector3(
            Random.Range(minMovementArea.transform.position.x, maxMovementArea.transform.position.x),
            Random.Range(minMovementArea.transform.position.y, maxMovementArea.transform.position.y),
            0
            );
    }

}


