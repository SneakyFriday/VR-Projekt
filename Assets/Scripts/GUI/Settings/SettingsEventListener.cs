using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsEventListener : MonoBehaviour
{

    public SettingsScriptableObject settingsScriptableObject;
    public SettingsController settingsController;
    
    void OnEnable()
    {
        settingsScriptableObject.onSettingsChanged.AddListener(OnSettingsChanged);
    }

    void OnDisable()
    {
        settingsScriptableObject.onSettingsChanged.RemoveListener(OnSettingsChanged);
    }

    void OnSettingsChanged()
    {
        // update the settings controller
        settingsController.UpdateSettings();
    }
}
