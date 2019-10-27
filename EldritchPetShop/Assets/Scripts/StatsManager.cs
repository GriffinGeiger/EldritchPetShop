using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public string CurrentName;
    public int CurrentHealth;
    public Reputation CurrentRep;
    public double CurrentFollowers;
    public GameObject StatDisplays;
    public GameObject StatValues;
    public PetController controller;
    public Reputation DesiredRep;
    public double Rate;
    public GUIManager GM;


    // Start is called before the first frame update
    void Start()
    {
        CloseStats();
        CurrentName = controller.petName;
        CurrentHealth = controller.petHealth;
        CurrentRep = controller.currentReputation;
        CurrentFollowers = 10000;
        DesiredRep = controller.preferredReputation;
        Rate = controller.followersRate;
    }

    void Awake()
    {
        GM = (GUIManager)FindObjectOfType(typeof(GUIManager));
    }

    void Update()
    {
        if(DesiredRep.ToString() == "Loved")
        {
            if ((int)CurrentRep >= 5)
            {
                CurrentFollowers += 2 * Rate * Time.deltaTime;
            }
            else if ((int)CurrentRep >= 2)
            {
                CurrentFollowers += Rate * Time.deltaTime;
            }
            else
            {
                CurrentFollowers += .5 * Rate * Time.deltaTime;
            }
        }

        if (DesiredRep.ToString() == "Feared")
        {
            if ((int)CurrentRep <= 1)
            {
                CurrentFollowers += 2 * Rate * Time.deltaTime;
            }
            else if ((int)CurrentRep <= 4)
            {
                CurrentFollowers += Rate * Time.deltaTime;
            }
            else
            {
                CurrentFollowers += .5 * Rate * Time.deltaTime;
            }
        }

        if (DesiredRep.ToString() == "Neutral")
        {
            if ((int)CurrentRep <= 4 | (int)CurrentRep >= 2)
            {
                CurrentFollowers += 2 * Rate * Time.deltaTime;
            }
            else
            {
                CurrentFollowers += .5 * Rate * Time.deltaTime;
            }
        }
        GM.Money += ((CurrentFollowers / 1000) * Time.deltaTime);
    }

    public void OpenStats()
    {
        StatDisplays.SetActive(true);
    }

    public void CloseStats()
    {
        StatDisplays.SetActive(false);
    }
}
