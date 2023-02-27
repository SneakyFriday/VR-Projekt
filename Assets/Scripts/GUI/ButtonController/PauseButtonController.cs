using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonController : MonoBehaviour
{
    
    public void PauseGame()
    {
        SoundManager.Instance.StopMusicSound();
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        SoundManager.Instance.PlayMusicSound();
        Time.timeScale = 1;
    }


}
