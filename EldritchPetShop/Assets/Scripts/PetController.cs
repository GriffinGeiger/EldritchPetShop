using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Offering
{
    Human,
    Animal,
    Relic
}
public enum Reputation
{
    Loved,
    LovedSomewhat,
    Neutral,
    FearedSomewhat,
    Feared
}
public enum PetType
{
    Cthulu,
    MiGo,
    Hastur,
    Azathoth,
    ShubNiggurath,
    Shogoth
}
public enum PetLevel
{
    Monster,
    God,
    EldestGod
}
public enum Location
{
    World,
    House,
    Cult,
    Random
}
public enum Desire
{
    Wander,
    GoToWorld,
    GoToCult,
    Fight
}
public enum Temper
{
    Passive,
    Aggressive,
    Unstable,
    Benevolent
}
public class PetController : MonoBehaviour
{
    //Preferences (based on pet type)
    [Header("Preferences based on pet type")]
    public Offering preferredOffering;
    public Reputation preferredReputation;  
    public Location preferredLocation;
    public float desireLowEnd;  //When they desire to do something, somewhere in this range will be how strongly they desire it.
    public float desireHighEnd; // Higher desire is higher stubbornness 
    public float desireLossMultiplier; //How fast desire is lost

    public Temper temper;
    [Header("Pet's Current Statuses")]
    public string petName;
    public Reputation currentReputation;    //The reputation that this instance of the pet has
    public PetType petType;
    public PetLevel petLevel;
    public double followers;
    [Header("Pet's Current Behavior")]
    public Location currentLocation;
    public Vector3 walkingDestination;
    public Desire currentDesire;
    public float desireStrength;
    public float timeUntilNextMotive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Choose new motive when desire runs out
        //if(desireStrength)
        //Desire runs out as a function of time or if user appeases pet
        //Desire runs out faster if the pet is further
        
    }
}
