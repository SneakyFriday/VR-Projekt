using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsNavigationController : MonoBehaviour
{
    public Button[] settingsOptions;
    private int selectedOptionIndex = 0;

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || verticalInput > 0)
        {
            selectedOptionIndex--;
            if (selectedOptionIndex < 0)
            {
                selectedOptionIndex = settingsOptions.Length - 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || verticalInput < 0)
        {
            selectedOptionIndex++;
            if (selectedOptionIndex >= settingsOptions.Length)
            {
                selectedOptionIndex = 0;
            }
        }
        else if (Input.GetAxis("joystick button 6") < 0)
        {
            selectedOptionIndex++;
            if (selectedOptionIndex >= settingsOptions.Length)
            {
                selectedOptionIndex = 0;
            }
        }
        else if (Input.GetAxis("joystick button 5") > 0)
        {
            selectedOptionIndex--;
            if (selectedOptionIndex < 0)
            {
                selectedOptionIndex = settingsOptions.Length - 1;
            }
        }

        // Highlight the selected option
        for (int i = 0; i < settingsOptions.Length; i++)
        {
            if (i == selectedOptionIndex)
            {
                settingsOptions[i].GetComponent<Button>().Select();
            }
            else
            {
                settingsOptions[i].GetComponent<Button>().OnDeselect(null);
            }
        }
    }
}
