using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButtonController : MonoBehaviour
{

    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
