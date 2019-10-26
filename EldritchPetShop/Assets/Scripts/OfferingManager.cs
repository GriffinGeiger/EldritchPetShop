using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferingManager : MonoBehaviour
{
    public PetController controller;
    double Followers;
    Reputation Reputation;
    public int Sacrifices;
    public string SType;
    float time;
    int DeltaTime;
    System.Random rnd = new System.Random();
    InventoryManager IM;
    void Start()
    {
        Followers = controller.followers;
        Reputation = controller.currentReputation;
        DeltaTime = rnd.Next(30, 61);
        IM = (InventoryManager)GameObject.FindObjectOfType(typeof(InventoryManager));
    }

    void Update()
    {
        //if time unpaused
        time += Time.deltaTime;
        SType = PickSac();
        Sacrifices = SacNum();
        if (time > DeltaTime)
        {
            SacrificeEvent(SType, Sacrifices);
            DeltaTime = rnd.Next(30, 61);
        }
        IM.Money += (int)(Followers / 1000);
        // end if
    }

    string PickSac()
    {
        if(Reputation == Reputation.Feared)
        {
            return "Human";
        }
        else if (Reputation == Reputation.FearedMostly)
        {
            return "Human";
        }
        else if (Reputation == Reputation.FearedSomewhat)
        {
            return "Animal";
        }
        else if (Reputation == Reputation.Neutral)
        {
            return "Animal";
        }
        else if (Reputation == Reputation.LovedSomewhat)
        {
            return "Animal";
        }
        else if (Reputation == Reputation.LovedMostly)
        {
            return "Relic";
        }
        else if (Reputation == Reputation.Loved)
        {
            return "Relic";
        }
        return "error";
    }

    int SacNum()
    {
        int n = (int)(Followers / 10000);
        return n;
    }

    void SacrificeEvent(string Type, int Num)
    {
        //Initiate textbox here
        if (Type == "Human")
        {
            IM.Humans += Num;
        }
        else if (Type == "Animal")
        {
            IM.Animals += Num;
        }
        else
        {
            IM.Relics += Num;
        }
    }
}
