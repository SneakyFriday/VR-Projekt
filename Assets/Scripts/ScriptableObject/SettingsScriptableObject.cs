using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


[CreateAssetMenu(fileName = "SettingsScriptableObject", menuName = "ScriptableObjects/Globals")]
public class SettingsScriptableObject : ScriptableObject
{
    public float spawnDelay = 1f;
    public int morningShiftLength = 60;
    public int middayShiftLength = 60;
    public int eveningShiftLength = 60;
    public float volume = 1f;
    public Vector3 offset;
    public float smoothSpeed = 10f;

}