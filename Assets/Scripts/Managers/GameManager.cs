using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // TODO: Make this a singleton, so that it can be accessed from anywhere
    private void Start()
    {
        SoundManager.Instance.PlayMusicSound();
    }
    
    public void StartMenu() {   
        SoundManager.Instance.StopMusicSound();
        SceneManager.LoadScene("Start");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SoundManager.Instance.StopMusicSound();
        SceneManager.LoadScene(currentScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
