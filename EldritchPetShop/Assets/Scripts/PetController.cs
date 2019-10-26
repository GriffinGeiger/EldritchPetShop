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
    LovedMostly,
    LovedSomewhat,
    Neutral,
    FearedSomewhat,
    FearedMostly,
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
    public float appeaseStrength; //How much desire is lost when appeased with normal offering
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
    [Header("Pet's Desire Percentages")]
    Dictionary<Desire, int> desireWeights = new Dictionary<Desire, int>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Choose new motive when desire runs out
        if(desireStrength <= 0)
        {
            //Choose new motive
            int totalDesireWeight = 0;
            for(int i = 0; i < desireWeights.Count; i++)
            {
                totalDesireWeight += desireWeights[(Desire) i];
            }
            int x = Random.Range(0, totalDesireWeight);
            for(int i = 0; i < (int) Desire.Fight; i++)
            {
                x -= desireWeights[(Desire) i];
                if (x <= 0)
                {
                    currentDesire = (Desire)desireWeights[(Desire)i];
                    desireStrength = Random.Range(desireLowEnd, desireHighEnd);
                    break;
                }
            }
        }
        //Desire runs out as a function of time or if user appeases pet
        //Desire runs out faster if the pet is further



    }

    /*Call this when giving this pet a gift to lower their desire. This will give them a new desire.
    *   Does not affect wander.
    * */
    public void AppeaseWithGift(Offering offer)
    {
        if (currentDesire != Desire.Wander)
        {
            if (preferredOffering == offer)
            {
                desireStrength -= 2 * appeaseStrength;
            }
            else
                desireStrength -= appeaseStrength;
        }
    }
}
