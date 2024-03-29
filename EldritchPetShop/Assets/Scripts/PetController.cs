﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Offering
{
    Human,
    Animal,
    Relic,
    Random
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
    Shoggoth
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
    public float desireLossRate; //How fast desire is lost
    public float desireFastDropDistance;
    public Temper temper;
    public float appeaseStrength; //How much desire is lost when appeased with normal offering
    public float price;
    public float bobbingAmplitude;
    public float bobbingRate;
    public float matureAge;
    public float healthFightDrainRate;
    public EventEntry MaturedMessage;
    public EventEntry DiedMessage;

    [Header("Pet's Current Statuses")]
    public string petName;
    public float age;
    public Reputation currentReputation;    //The reputation that this instance of the pet has
    public PetType petType;
    public PetLevel petLevel;
    public float petHealth;
    public double followers;
    public double followersRate;
    [Header("Pet's Current Behavior")]
    public Location currentLocation;
    public Vector3 walkingDestination;
    public Desire currentDesire;
    public float desireStrength;
    public bool currentlyLosingDesire; //Won't lose desire when paused or dragged
    bool initiatingFight = false;

    public Dictionary<Desire, int> desireWeights = new Dictionary<Desire, int>();
    [Header("Pet's Desire weights")]
    public int wanderWeight;
    public int fightWeight;
    public int goToWorldWeight;
    public int goToCultWeight;

    [Header("World References")]
    public GameManager gm;
    public TextMesh Nametag;
    public StatsManager sm;
    public DragObject drag;

    [Header("Prefab Refs")]
    public GameObject StatsPage;
    [Header("Shub Use Only")]
    public SpriteRenderer sprite;
    public Sprite calm;
    public Sprite angery;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        desireWeights.Add(Desire.Wander, wanderWeight);
        desireWeights.Add(Desire.Fight, fightWeight);
        desireWeights.Add(Desire.GoToCult, goToCultWeight);
        desireWeights.Add(Desire.GoToWorld, goToWorldWeight);
        Nametag.name = petName;
        
    }
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        sm.StatDisplays = GameObject.Instantiate(StatsPage, FindObjectOfType<Canvas>().transform);
        sm.StatDisplays.GetComponent<StatsManager>().controller = this;
        //sm.StatDisplays.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        if (drag.mouseOver && Input.GetMouseButtonDown(1))
        {
            Debug.Log("openingStats");
            sm.OpenStats();
        }

        if (petHealth <= 0)
            Die();
        if(!gm.isPaused)
            age += 1000 * Time.deltaTime;
        if(age >= matureAge)
        {
            Matured();
        }

        if(petType == PetType.ShubNiggurath)
        {
            if (currentReputation >= (Reputation)5)
            {
                sprite.sprite = angery;
            }
            else
                sprite.sprite = calm;
        }
        //////////////////////////////Desire////////////////////////////////////
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
            for(int i = 0; i <= (int) Desire.Fight; i++)
            {
                x -= desireWeights[(Desire) i];
                if (x <= 0)
                {
                    currentDesire = (Desire) i;
                    Debug.Log(petName + "'s new desire: " + (Desire)i);
                    desireStrength = Random.Range(desireLowEnd, desireHighEnd);
                    ChooseNewDestination();
                    break;
                }
            }  
        }
        //Desire runs out as a function of time or if user appeases pet
        //Desire runs out faster if the pet is further
        if (currentlyLosingDesire)
        {
            if (Vector3.Distance(transform.position, walkingDestination) > desireFastDropDistance)
                desireStrength -= desireLossRate * Time.deltaTime * 2;//Desire is dropped at twice the rate if outside fast drop distance
            else
                desireStrength -= desireLossRate * Time.deltaTime;
        }

        if(currentDesire == Desire.Fight && Vector3.Distance(transform.position,walkingDestination) <= .2f && !gm.isPaused)
        {
            petHealth -= healthFightDrainRate * Time.deltaTime;
        }
        //////////////////////////////Desire////////////////////////////////////

        transform.position += new Vector3(0f,Mathf.Sin(Time.time*bobbingRate)*bobbingAmplitude, 0f);

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
        
        if(preferredOffering == offer)
        {
            Debug.Log("Healing " + petName + "Fully");
            petHealth = 100;
        }
        else
        {
            Debug.Log("Healing " + petName + "25 points");
            petHealth += 25;
            if (petHealth > 100)
                petHealth = 100;
        }
    }
    public void CompletedDesire()
    {

    }

    public void Die()
    {
        FindObjectOfType<GUIManager>().DisplayEventbox(DiedMessage,this);
        GameObject.Destroy(this.gameObject);
    }

    public void Matured()
    {
        FindObjectOfType<GUIManager>().DisplayEventbox(MaturedMessage, this);
        GameObject.Destroy(this.gameObject);
    }
    public void ChooseNewDestination()
    {
        
        switch (currentDesire)
        {
            case Desire.Wander:
                //Pick random wander spot
                walkingDestination = gm.GenerateRandomWanderPoint();
                initiatingFight = true;
                break;
            case Desire.GoToWorld:
                //Go to world spot
                walkingDestination = gm.doorToWorld.transform.position;
                initiatingFight = true;
                break;
            case Desire.GoToCult:
                //go to cult spot
                walkingDestination = gm.circleToCult.transform.position;
                initiatingFight = true;
                break;
            case Desire.Fight:
                //Meet with another pet to fight
                if (initiatingFight)
                {
                    
                    PetController opponent = FindFightingPartner();
                    if (opponent == null)
                    {
                        desireStrength = 0;
                        break;
                    }
                    desireStrength = 15;
                    opponent.currentDesire = Desire.Fight;
                    opponent.desireStrength = 15;
                    walkingDestination = gm.GenerateRandomWanderPoint();
                    opponent.walkingDestination = walkingDestination;
                    initiatingFight = false;
                    opponent.initiatingFight = false;
                }
                break;
            default:
                break;
        }
    }
    public PetController FindFightingPartner()
    {
        PetController[] pc = FindObjectsOfType<PetController>();
        if(pc.Length <= 1)
        {
            return null;
        }
        else
        {
            PetController opponent = this;
            int breakoutcount = 0;
            while(opponent == this && breakoutcount < 100)
            {
                opponent = pc[Random.Range(0, pc.Length)];
                if (opponent.currentDesire == Desire.Fight)
                    continue;
                breakoutcount++;
            }
            if (opponent == this)
                return null;
            return opponent;
        }
    }
}
