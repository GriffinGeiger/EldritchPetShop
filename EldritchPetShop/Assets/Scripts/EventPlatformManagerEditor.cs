using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventPlatformManager))]
public class EventPlatformManagerEditor : Editor
{
    public EventPlatformManager epm;
    private void Awake()
    {
        epm = (EventPlatformManager) target;
    }

}
