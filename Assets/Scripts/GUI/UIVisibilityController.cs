using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVisibilityController : MonoBehaviour
{
    public GameObject[] uiElements = new GameObject[1]; // assign the UI element in the Inspector
    public Button vrPlayerButton; // assign the VR player button in the inspector
    public Button keyboardPlayerButton; // assign the Keyboard player button in the inspector

    void Start()
    {      
        // Check if the VR player has been identified
        if (PlayerPrefs.HasKey("VRPlayer"))
        {
            print("Test 1");
            // If the VR player has been identified, check if the current player is the VR player
            if (PlayerPrefs.GetInt("VRPlayer") == 1)
            {
                // If the current player is the VR player, deactivate the UI element
                SetUIElements(false);
            }
            else
            {
                SetUIElements(true);
            }
        }
        else
        {
            // If the VR player hasn't been identified, prompt the user to select which player is the VR player
            ShowPlayerSelectionMenu();
        }
    }

    void ShowPlayerSelectionMenu()
    {
        // Show the buttons
        vrPlayerButton.gameObject.SetActive(true);
        keyboardPlayerButton.gameObject.SetActive(true);
        
        // Add a listener to the onClick event of the buttons
        print("Test 2");
        if ( Input.GetKeyDown(KeyCode.V))
        {
            print("VR");
            HandleVRPlayerSelection();
        }
        else if ( Input.GetKeyDown(KeyCode.Space))
        {
            print("Non Vr");
            HandleKeyboardPlayerSelection();
        }

        vrPlayerButton.onClick.AddListener(HandleVRPlayerSelection);
        keyboardPlayerButton.onClick.AddListener(HandleKeyboardPlayerSelection);
    }

    public void HandleVRPlayerSelection()
    {
        // Set the VRPlayer value in the PlayerPrefs
        PlayerPrefs.SetInt("VRPlayer", 1);

        // Hide the buttons
        vrPlayerButton.gameObject.SetActive(false);
        keyboardPlayerButton.gameObject.SetActive(false);

        // Deactivate the UI element
        SetUIElements(false);
    }

    public void HandleKeyboardPlayerSelection()
    {
        // Set the VRPlayer value in the PlayerPrefs
        PlayerPrefs.SetInt("VRPlayer", 0);

        // Hide the buttons
        vrPlayerButton.gameObject.SetActive(false);
        keyboardPlayerButton.gameObject.SetActive(false);
        
        // Activate the UI element
        SetUIElements(true);
    }

void SetUIElements(bool value)
{
    // Iterate through the array of UI elements and set their active state
    for (int i = 0; i < uiElements.Length; i++)
    {
        if (uiElements[i] != null)
            uiElements[i].SetActive(value);
    }
}
}