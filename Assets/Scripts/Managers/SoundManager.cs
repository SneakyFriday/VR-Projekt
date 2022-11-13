using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

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

    public void PlayMusicSound()
    {
        _musicSource.playOnAwake = true;
        _musicSource.loop = true;
        _musicSource.PlayOneShot(_backgroundMusic);
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
