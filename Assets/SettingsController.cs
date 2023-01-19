using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour
{
    public SettingsScriptableObject settingsScriptableObject;

    public TMP_InputField spawnDelayInputField;
    public TMP_Text spawnDelayText;

    public TMP_InputField morningShiftLengthInputField;
    public TMP_Text morningShiftText;

    public TMP_InputField middayShiftLengthInputField;
    public TMP_Text middayShiftText;

    public TMP_InputField eveningShiftLengthInputField;
    public TMP_Text eveningShiftText;

    public TMP_Text offsetXtext;
    public TMP_Text offsetYtext;
    public TMP_Text offsetZtext;
    public TMP_InputField offsetXinputField;
    public TMP_InputField offsetYinputField;
    public TMP_InputField offsetZinputField;

    public Slider volumeSlider;
    public AudioSource audioSource;
    public TMP_Text volumeText;

    public Vector3 offset; 

    public float smoothSpeed;

    public TMP_Text smoothSpeedText;
    public TMP_InputField smoothSpeedInputField;


    void Start()
    {
        volumeText.text = "Volume: " + settingsScriptableObject.volume * 100 + "%";
        spawnDelayText.text = "SpawnDelay: " + settingsScriptableObject.spawnDelay ;
        morningShiftText.text = "Morning Shift: " + settingsScriptableObject.morningShiftLength + "s";
        middayShiftText.text = "Midday Shift: " + settingsScriptableObject.middayShiftLength + "s";
        eveningShiftText.text = "Evening Shift: " + settingsScriptableObject.eveningShiftLength + "s";
        offset = settingsScriptableObject.offset;
        offsetXtext.text = "Offset X: " + offset.x;
        offsetYtext.text = "Offset Y: " + offset.y;
        offsetZtext.text = "Offset Z: " + offset.z;
        smoothSpeedText.text = "Smoothing: " + settingsScriptableObject.smoothSpeed;
        DontDestroyOnLoad(settingsScriptableObject);
    }

    public void changeSpawnDelay()
    {
        float newSpawnDelay = float.Parse(spawnDelayInputField.text);
        settingsScriptableObject.spawnDelay = newSpawnDelay;
        spawnDelayText.text = "Spawndelay: " + settingsScriptableObject.spawnDelay + "s";
    }

    public void changeMorningShiftLength()
    {
        int newMorningShiftLength = int.Parse(morningShiftLengthInputField.text);
        settingsScriptableObject.morningShiftLength = newMorningShiftLength;
        morningShiftText.text = "Morning Shift: " + settingsScriptableObject.morningShiftLength + "s";
    }

    public void changeMiddayShiftLength()
    {
        int newMiddayShiftLength = int.Parse(middayShiftLengthInputField.text);
        settingsScriptableObject.middayShiftLength = newMiddayShiftLength;
        middayShiftText.text = "Midday Shift: " + settingsScriptableObject.middayShiftLength + "s"; 
    }

    public void changeEveningShiftLength()
    {
        int newEveningShiftLength = int.Parse(eveningShiftLengthInputField.text);
        settingsScriptableObject.eveningShiftLength = newEveningShiftLength;
        eveningShiftText.text = "Evening Shift: " + settingsScriptableObject.eveningShiftLength + "s";
    }

    public void changeVolume() 
    {
        float newVolume = volumeSlider.value;
        settingsScriptableObject.volume = newVolume;
        volumeText.text = "Volume: " + Mathf.RoundToInt(settingsScriptableObject.volume * 100) + "%"; 
        audioSource.volume = settingsScriptableObject.volume;
    }

     public void changeOffset()
    {
        settingsScriptableObject.offset = offset;
        settingsScriptableObject.smoothSpeed = smoothSpeed;
    } 

    public void changeOffsetX()
    {
        float newOffsetX = float.Parse(offsetXinputField.text);
        offset.x = newOffsetX;
        offsetXtext.text = "Offset X: " + offset.x;
    }

    public void changeOffsetY()
    {
        float newOffsetY = float.Parse(offsetYinputField.text);
        offset.y = newOffsetY;
        offsetYtext.text = "Offset Y: " + offset.y;
    }

    public void changeOffsetZ()
    {
        float newOffsetZ = float.Parse(offsetZinputField.text);
        offset.z = newOffsetZ;
        offsetZtext.text = "Offset Z: " + offset.z;
    }

    public void changeSmoothSpeed()
    {
        float newSmoothSpeed = float.Parse(smoothSpeedInputField.text);
        smoothSpeed = newSmoothSpeed;
        smoothSpeedText.text = "Smoothing: " + smoothSpeed;
    }

}