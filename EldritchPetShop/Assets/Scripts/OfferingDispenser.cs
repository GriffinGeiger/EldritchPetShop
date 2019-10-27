using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OfferingDispenser : MonoBehaviour, IPointerDownHandler
{
    public GameObject offeringPrefab;
    public Transform spawnLocation;
    public Camera mainCam;
    public GameObject offeringDisplay;

    void Start()
    {
        mainCam = Camera.main;
    }


    void Update()
    {
        
    }

    public void Dispense()
    {
        Debug.Log("Dispensing");
        GameObject.Instantiate(offeringPrefab,spawnLocation,false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Dispensing");
        GameObject go = GameObject.Instantiate(offeringPrefab, mainCam.ScreenToWorldPoint(eventData.position), Quaternion.identity);
        go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, 0);
        go.GetComponentInChildren<DragObject>().offeringDisplay = offeringDisplay;
        offeringDisplay.SetActive(false);
    }
}
