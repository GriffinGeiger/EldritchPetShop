using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferingController : MonoBehaviour
{
    public Offering offeringType;
    public GameObject offeringDisplay;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        PetController pc = other.gameObject.GetComponentInChildren<PetController>();
        if(pc != null)
        {
            pc.AppeaseWithGift(offeringType);
            offeringDisplay.SetActive(true);
            enabled = false;
            GameObject.Destroy(this.gameObject);
            
        }
    }
}
