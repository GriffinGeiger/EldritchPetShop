using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferingManager : MonoBehaviour
{
    public PetController controller;
    double Followers;
    double Reputation;
    public int Sacrifices;
    public string SType;
    int time;
    int DeltaTime;
    int NewCash;

    void Start()
    {
        Followers = controller.followers;
        Reputation = controller.currentReputation;
        DeltaTime = rnd.Next(30, 61);
    }

    void Update()
    {
        //if time unpaused
        time += Time.deltaTime;
        SType = PickSac();
        Sacrifices = SacNum();
        if (time > DeltaTime)
        {
            SacrificEvent(SType, Sacrifices);
            DeltaTime = rnd.Next(30, 61);
        }
        NewCash = Followers / 1000;
        InventoryManager.Money += NewCash;
        // end if
    }

    string PickSac()
    {
        if (Reputation < .33)
        {
            return "Human";
        }
        else if (Reputation < .66)
        {
            return "Animal";
        }
        else
        {
            return "Relic";
        }
    }

    int SacNum()
    {
        int n = Followers / 10000;
        return n;
    }

    void SacrificeEvent(string Type, int Num)
    {
        //Initiate textbox here
        if (Type == "Human")
        {
            InventoryManager.Humans += Num;
        }
        else if (Type == "Animal")
        {
            InventoryManager.Animals += Num;
        }
        else
        {
            InventoryManager.Relics += Num;
        }
    }
}
