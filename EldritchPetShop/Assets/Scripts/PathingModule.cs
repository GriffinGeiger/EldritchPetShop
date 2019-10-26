using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathingModule : MonoBehaviour
{
    public float speed = .5f;
    public Vector3 targetLocation;
    public bool travelling = true;
    public bool paused;
    public PetController PC;
    // Start is called before the first frame update
    void Start()
    {
        PC = GetComponent<PetController>();
    }

    // Update is called once per frame
    void Update()
    {
        targetLocation = PC.walkingDestination;
        float step = speed * Time.deltaTime;
        if (travelling)
        {
            Vector3.MoveTowards(gameObject.transform.position, targetLocation, step);
        }
        if(Vector3.Distance(transform.position,targetLocation) < .001f)
        {
            //Tell PC it is done moving to this location
            PC.ChooseNewDestination();
        }
    }
}
