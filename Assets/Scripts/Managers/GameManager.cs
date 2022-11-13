using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlayMusicSound();
    }

    public void RestartGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SoundManager.Instance.StopMusicSound();
        SceneManager.LoadScene(currentScene);
    }
}
