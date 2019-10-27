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
    public GUIManager GM;
    void Start()
    {
      //  Followers = controller.followers;
      // Reputation = controller.currentReputation;
        DeltaTime = rnd.Next(30, 61);
        GM = (GUIManager)GameObject.FindObjectOfType(typeof(GUIManager));
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
        GM.Money += ((10000 / 1000)*Time.deltaTime);
        // end if
    }

    string PickSac()
    {
        if(Reputation == Reputation.Feared)
        {
            return "Humans";
        }
        else if (Reputation == Reputation.FearedMostly)
        {
            return "Humans";
        }
        else if (Reputation == Reputation.FearedSomewhat)
        {
            return "Animals";
        }
        else if (Reputation == Reputation.Neutral)
        {
            return "Animals";
        }
        else if (Reputation == Reputation.LovedSomewhat)
        {
            return "Animals";
        }
        else if (Reputation == Reputation.LovedMostly)
        {
            return "Relics";
        }
        else if (Reputation == Reputation.Loved)
        {
            return "Relics";
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
        string text = "You have recieved " + Num + " " + Type + ".";
        GM.DisplayTextbox(text);
        if (Type == "Human")
        {
            GM.Humans += Num;
        }
        else if (Type == "Animal")
        {
            GM.Animals += Num;
        }
        else
        {
            GM.Relics += Num;
        }
    }
}
