using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferingController : MonoBehaviour
{
    public Offering offeringType;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        PetController pc = other.GetComponent<PetController>();
        if(pc != null)
        {
            pc.AppeaseWithGift(offeringType);
            GameObject.Destroy(this);
        }
    }
}
