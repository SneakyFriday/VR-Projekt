using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeController : MonoBehaviour
{
    public SettingsScriptableObject settingsScriptableObject;
    public Slider volumeSlider;
    public AudioSource audioSource;
    public TextMeshProUGUI volumeText;

    private void Start()
    {
        //volumeSlider.value = PlayerPrefs.GetFloat("Volume", settingsScriptableObject.volume);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.value = settingsScriptableObject.volume;
    }

    public void SetVolume()
    {
        if (audioSource != null && volumeSlider != null)
        {
            audioSource.volume = volumeSlider.value;
            PlayerPrefs.SetFloat("Volume", volumeSlider.value);

            volumeText.text = $"{Mathf.RoundToInt(volumeSlider.value * 100)}%";
        }
    }
}
