using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class SettingsController : MonoBehaviour
{
    public SettingsScriptableObject settingsScriptableObject;
    private SettingsScriptableObject previousSettings;

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

    // Declare a delegate type for the settings change event
    public delegate void SettingsChangeEvent();
    public delegate void SettingChangedEventHandler();

    public event SettingChangedEventHandler SpawnDelayChanged;
    public event SettingChangedEventHandler MorningShiftChanged;
    public event SettingChangedEventHandler MiddayShiftChanged;
    public event SettingChangedEventHandler EveningShiftChanged;
    public event SettingChangedEventHandler VolumeChanged;
    public event SettingChangedEventHandler OffsetChanged;
    public event SettingChangedEventHandler SmoothSpeedChanged;
    // Declare a settings change event
    public static event SettingsChangeEvent OnSettingsChanged;


    void Update()
    {
        // check if the settings have changed
        if (!settingsScriptableObject.Equals(previousSettings))
        {
            // trigger the event
            settingsScriptableObject.onSettingsChanged.Invoke();

            // update the previous settings
            previousSettings = Instantiate(settingsScriptableObject);
        }
    }

    void Start()
    {

        volumeText.text = "Volume: " + settingsScriptableObject.volume * 100 + "%";
        spawnDelayText.text = "SpawnDelay: " + settingsScriptableObject.spawnDelay ;
        morningShiftText.text = "Morning Shift: " + settingsScriptableObject.morningShiftLength + "s";
        middayShiftText.text = "Midday Shift: " + settingsScriptableObject.middayShiftLength + "s";
        eveningShiftText.text = "Evening Shift: " + settingsScriptableObject.eveningShiftLength + "s";
        offsetXtext.text = "Offset X: " + settingsScriptableObject.offset.x;
        offsetYtext.text = "Offset Y: " + settingsScriptableObject.offset.y;
        offsetZtext.text = "Offset Z: " + settingsScriptableObject.offset.z;
        offset = settingsScriptableObject.offset;
        smoothSpeedText.text = "Smoothing: " + settingsScriptableObject.smoothSpeed;
        DontDestroyOnLoad(settingsScriptableObject);
        // store the initial settings for comparison
        previousSettings = Instantiate(settingsScriptableObject);
    }

    public void changeSpawnDelay()
    {
        float newSpawnDelay = float.Parse(spawnDelayInputField.text);
        settingsScriptableObject.spawnDelay = newSpawnDelay;
        spawnDelayText.text = "Spawndelay: " + settingsScriptableObject.spawnDelay + "s";
        OnSettingsChanged?.Invoke();
        if (SpawnDelayChanged != null)
        {
            SpawnDelayChanged();
        }
        
    }


  
    public void changeMorningShiftLength()
    {
        int newMorningShiftLength = int.Parse(morningShiftLengthInputField.text);
        settingsScriptableObject.morningShiftLength = newMorningShiftLength;
        morningShiftText.text = "Morning Shift: " + settingsScriptableObject.morningShiftLength + "s";
        OnSettingsChanged?.Invoke();
        if (MorningShiftChanged != null)
        {
            MorningShiftChanged();
        }
    }

    public void changeMiddayShiftLength()
    {
        int newMiddayShiftLength = int.Parse(middayShiftLengthInputField.text);
        settingsScriptableObject.middayShiftLength = newMiddayShiftLength;
        middayShiftText.text = "Midday Shift: " + settingsScriptableObject.middayShiftLength + "s"; 
        OnSettingsChanged?.Invoke();
        if (MiddayShiftChanged != null)
        {
            MiddayShiftChanged();
        }
    }

    public void changeEveningShiftLength()
    {
        int newEveningShiftLength = int.Parse(eveningShiftLengthInputField.text);
        settingsScriptableObject.eveningShiftLength = newEveningShiftLength;
        eveningShiftText.text = "Evening Shift: " + settingsScriptableObject.eveningShiftLength + "s";
        OnSettingsChanged?.Invoke();
        if (EveningShiftChanged != null)
        {
            EveningShiftChanged();
        }
        
    }

    public void changeVolume() 
    {
        float newVolume = volumeSlider.value;
        settingsScriptableObject.volume = newVolume;
        volumeText.text = "Volume: " + Mathf.RoundToInt(settingsScriptableObject.volume * 100) + "%"; 
        audioSource.volume = settingsScriptableObject.volume;
        OnSettingsChanged?.Invoke();
        if (VolumeChanged != null)
        {
            VolumeChanged();
        }
        
    }

     public void changeOffset()
    {
        settingsScriptableObject.offset = offset;
        settingsScriptableObject.smoothSpeed = smoothSpeed;
        OnSettingsChanged?.Invoke();
        if (OffsetChanged != null)
        {
            OffsetChanged();
        }
    } 

    public void changeOffsetX()
    {
        float newOffsetX = float.Parse(offsetXinputField.text);
        settingsScriptableObject.offset.x = newOffsetX;
        offsetXtext.text = "Offset X: " + settingsScriptableObject.offset.x;
        OnSettingsChanged?.Invoke();

    }

    public void changeOffsetY()
    {
        float newOffsetY = float.Parse(offsetYinputField.text);
        settingsScriptableObject.offset.y = newOffsetY;
        offsetYtext.text = "Offset Y: " + settingsScriptableObject.offset.y;
        OnSettingsChanged?.Invoke();
    }

    public void changeOffsetZ()
    {
        float newOffsetZ = float.Parse(offsetZinputField.text);
        settingsScriptableObject.offset.z = newOffsetZ;
        offsetZtext.text = "Offset Z: " + settingsScriptableObject.offset.z;
        OnSettingsChanged?.Invoke();
    }

    public void changeSmoothSpeed()
    {
        float newSmoothSpeed = float.Parse(smoothSpeedInputField.text);
        smoothSpeed = newSmoothSpeed;
        smoothSpeedText.text = "Smoothing: " + smoothSpeed;
        OnSettingsChanged?.Invoke();
        if (SmoothSpeedChanged != null)
        {
            SmoothSpeedChanged();
        }
    }


    public void UpdateSettings()
    {
        volumeText.text = "Volume: " + settingsScriptableObject.volume * 100 + "%";
        spawnDelayText.text = "SpawnDelay: " + settingsScriptableObject.spawnDelay;
        morningShiftText.text = "Morning Shift: " + settingsScriptableObject.morningShiftLength + "s";
        middayShiftText.text = "Midday Shift: " + settingsScriptableObject.middayShiftLength + "s";
        eveningShiftText.text = "Evening Shift: " + settingsScriptableObject.eveningShiftLength + "s";
        offsetXtext.text = "Offset X: " + settingsScriptableObject.offset.x;
        offsetYtext.text = "Offset Y: " + settingsScriptableObject.offset.y;
        offsetZtext.text = "Offset Z: " + settingsScriptableObject.offset.z;
        offset = settingsScriptableObject.offset;
        smoothSpeedText.text = "Smoothing: " + settingsScriptableObject.smoothSpeed;

    }
}