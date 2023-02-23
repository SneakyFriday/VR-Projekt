using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaySoundOnObject : MonoBehaviour
{
    /**
     * Attach on Objects to Play Sound on them
     */
    [SerializeField] private AudioClip _clip;
    private AudioSource _objectAudioSource;

    private void Start()
    {
        _objectAudioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        _objectAudioSource.PlayOneShot(_clip);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<XRDirectInteractor>())
            PlaySound();
    }
}
