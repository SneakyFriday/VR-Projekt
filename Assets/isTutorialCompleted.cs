using UnityEngine;
using UnityEngine.SceneManagement;

public class isTutorialCompleted : MonoBehaviour
{
    void Start()
    {

        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("tutCompleted", 0) == 1)
        {
            SceneManager.LoadScene("Start"); 
            Debug.Log("Tutorial Completed");
        }
        else if (PlayerPrefs.GetInt("tutCompleted", 0) == 0)
        {
            Debug.Log("Tutorial Not Completed");
        }
    }



}
