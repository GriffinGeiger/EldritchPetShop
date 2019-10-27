using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public string CurrentName;
    public float CurrentHealth;
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
        CurrentFollowers = controller.followers;
        DesiredRep = controller.preferredReputation;
        Rate = controller.followersRate;
    }

    void Awake()
    {
        GM = (GUIManager)FindObjectOfType(typeof(GUIManager));
    }

    void Update()
    {
        CurrentFollowers += ((-(.25*System.Math.Abs((int)DesiredRep - (int)CurrentRep))+2) * Rate * Time.deltaTime);
        GM.Money += ((CurrentFollowers) * Time.deltaTime);
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
