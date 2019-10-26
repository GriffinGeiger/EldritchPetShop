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
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Create Test Event"))
        {
           epm.gui.DisplayEventbox(epm.getRandomEvent(EventType.Cultist, PetType.Cthulu), "Cthuwu");
        }
    }
}
