using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    public void StartGame() 
    {   
        Time.timeScale = 1;
        SceneManager.LoadScene("ModelScene");
    }

}
