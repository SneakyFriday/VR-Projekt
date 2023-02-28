/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SettingsNavigationController : MonoBehaviour
{
    public Button[] settingsOptions;
    private int selectedOptionIndex = 0;
    private DefaultInputActions gameControls;
    

    private void OnEnable()
    {

        // Create a new instance of the input system controls
        gameControls = new GameControls();

        // Enable the input system controls
        gameControls.Enable();
    }

    private void OnDisable()
    {
        // Disable the input system controls
        gameControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the value of the "Move" action for the D-pad
        Vector2 dpadMoveInput = gameControls.Gameplay.MoveDpad.ReadValue<Vector2>();

        // Check for up/down input from the D-pad
        float verticalInput = dpadMoveInput.y;
        if (verticalInput > 0.5f)
        {
            selectedOptionIndex--;
            if (selectedOptionIndex < 0)
            {
                selectedOptionIndex = settingsOptions.Length - 1;
            }
        }
        else if (verticalInput < -0.5f)
        {
            selectedOptionIndex++;
            if (selectedOptionIndex >= settingsOptions.Length)
            {
                selectedOptionIndex = 0;
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
 */