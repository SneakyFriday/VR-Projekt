using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtonController : MonoBehaviour
{

    public GameObject settingsMenu;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            onClick();
        }
    }

    public void onClick()
    {
        settingsMenu.SetActive(!settingsMenu.activeSelf);

        if (settingsMenu.activeSelf)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
