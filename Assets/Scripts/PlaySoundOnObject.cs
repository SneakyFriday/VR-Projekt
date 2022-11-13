using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnObject : MonoBehaviour
{
    /**
     * Attach on Objects to Play Sound on them
     */
    [SerializeField] private AudioClip _clip;

    public void PlaySoundEffect()
    {
       SoundManager.Instance.PlayEffectSound(_clip);
    }
        
    
}
