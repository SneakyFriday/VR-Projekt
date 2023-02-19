using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public SettingsScriptableObject settingsScriptableObject;
    public SettingsController settingsController;
    

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioClip _backgroundMusic;

    #region Singleton
    private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    #endregion

    void Start()
    {
        settingsController.VolumeChanged += UpdateVolume;
    }
    
    public void UpdateVolume()
    {
        _musicSource.volume = settingsScriptableObject.volume;
    }

    void OnDestroy()
    {
        settingsController.VolumeChanged -= UpdateVolume;
    }

    public void PlayMusicSound()
    {
        _musicSource.playOnAwake = true;
        _musicSource.loop = true;
        _musicSource.PlayOneShot(_backgroundMusic);
    }

    public void StopMusicSound()
    {
        _musicSource.Stop();
    }

    /**
     * Methode für Volume-Slider.
     * Parameter: Slider Value
     */
    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}
