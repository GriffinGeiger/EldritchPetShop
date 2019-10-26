using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int Money;
    public int Humans;
    public int Animals;
    public int Relics;
    
    void Start()
    {
        Money = 1000;
        Humans = 0;
        Animals = 0;
        Relics = 0;
    }

    void Update()
    {
        //Update Inventory UI if necessary
    }
}
