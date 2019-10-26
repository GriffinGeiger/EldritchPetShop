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

    void Start()
    {
        Followers = controller.followers;
        Reputation = controller.currentReputation;
        DeltaTime = rnd.Next(30, 61);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > DeltaTime)
        {
            //initiate Sacrific Event
            DeltaTime = rnd.Next(30, 61);
        }
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
}
