using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public GameObject NameTag;
    public bool isOffering;
    public GameObject offeringDisplay;
    public bool mouseOver = false;

    void Start()
    {
        if(NameTag != null)
            NameTag.GetComponent<Renderer>().sortingLayerName = "Pets";
    }
    void OnMouseDown()
    {
        if (enabled)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            //Store offset = gameobject world pos - mouse world pos
            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
            PathingModule pm = GetComponent<PathingModule>();
            if (pm != null)
            {
                pm.travelling = false;
            }
            PetController pc = GetComponent<PetController>();
            if (pc != null)
            {
                pc.currentlyLosingDesire = false;
            }
        }
    }

    
    void OnMouseUp()
    {
        if (enabled)
        {
            PathingModule pm = GetComponent<PathingModule>();
            if (pm != null)
            {
                pm.travelling = true;
            }
            PetController pc = GetComponent<PetController>();
            if (pc != null)
            {
                pc.currentlyLosingDesire = true;
            }
            if (isOffering)
            {
                offeringDisplay.SetActive(true);
                
            }
        }
    }
    public void OnMouseEnter()
    {
        if (enabled)
        {
            if (NameTag != null)
            {
                NameTag.SetActive(true);
            }
            mouseOver = true;
        }
    }
    private void OnMouseExit()
    {
        if (enabled)
        {
            if (NameTag != null)
            {
                NameTag.SetActive(false);
            }
            mouseOver = false;
        }

    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void OnMouseDrag()
    {

        if (enabled)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
       
    }

}