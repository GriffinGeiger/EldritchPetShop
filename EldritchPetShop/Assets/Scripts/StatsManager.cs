using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{

    public GameObject StatDisplays;
    public GameObject StatValues;
    public PetController controller;
    public double Rate;
    public GUIManager GM;


    // Start is called before the first frame update
    void Start()
    {
      
        StatDisplays = GameObject.Find("StatsDisplays");
        Debug.Log("Stat" + StatDisplays.ToString());
        
    }

    void Awake()
    {
        GM = (GUIManager)FindObjectOfType(typeof(GUIManager));
        

    }

    void Update()
    {
        if (!FindObjectOfType<GameManager>().isPaused)
        {
            controller.followers += ((-(.25 * System.Math.Abs((int)controller.preferredReputation - (int)controller.currentReputation)) + 2) * Rate * Time.deltaTime);
            GM.Money += ((controller.followers) * Time.deltaTime);
        }
    }

    public void OpenStats()
    {
        GameManager.Pause();
        StatDisplays.SetActive(true);
        string text = StatDisplays.GetComponentInChildren<Text>().text;
        text = text.Replace("\\name", controller.petName);
        text = text.Replace("\\health", controller.petHealth.ToString());
        text = text.Replace("\\reputation", controller.currentReputation.ToString());
        text = text.Replace("\\followers", ((int)controller.followers).ToString());
        StatDisplays.GetComponentInChildren<Text>().text = text;
    }

    public void CloseStats()
    {
        GameManager.Resume();
        StatDisplays.GetComponentInChildren<Text>().text = "Name:	\\name\nHealth: \\health\nReputation:\\reputation\nFollowers:	\\followers";
        StatDisplays.SetActive(false);
    }
}
