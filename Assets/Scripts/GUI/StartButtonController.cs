using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    public void StartGame() 
    {   
        SceneManager.LoadScene("ModelScene");
    }

    public void tutorialCompleted() 
    {
        PlayerPrefs.SetInt("tutCompleted", 1);
    }
}
