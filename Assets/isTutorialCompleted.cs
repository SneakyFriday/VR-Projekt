using UnityEngine;
using UnityEngine.SceneManagement;

public class isTutorialCompleted : MonoBehaviour
{


    void Start()
    {
        if (PlayerPrefs.GetInt("isTutorialCompleted", 0) == 1)
        {
            SceneManager.LoadScene("Start");
        } else

        {
            SceneManager.LoadScene("Tutorial");
        }
    }
}
