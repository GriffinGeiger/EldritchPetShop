﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        PathingModule pm = GetComponent<PathingModule>();
        if (pm != null)
        {
            pm.travelling = false;
        }
        PetController pc = GetComponent<PetController>();
        if(pc != null)
        {
            pc.currentlyLosingDesire = false;
        }
    }
    void OnMouseUp()
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

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
}