using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScrollingText : MonoBehaviour
{

    [SerializeField] [TextArea] public string[] itemInfo;
    [SerializeField] private float scrollSpeed = 0.03f;
    [SerializeField] private TMP_Text itemInfoText;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private GameObject tutorialDialogue;
    private int currentItemIndex = 0;


    void Start()
    {
        ActivateText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentItemIndex++; // Increment to the next item in the array
            if (currentItemIndex == 2)
            {
                // enable the two buttons once the text has finished scrolling through 
                yesButton.gameObject.SetActive(true);
                noButton.gameObject.SetActive(true);
            } 
            ActivateText();
        }
    }

    public void ActivateText()
    {
        StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText()
    {
        for (int i = 0; i < itemInfo[currentItemIndex].Length; i++)
        {
            itemInfoText.text = itemInfo[currentItemIndex].Substring(0, i);
            yield return new WaitForSeconds(scrollSpeed);
        }

        if (currentItemIndex == 2)
        {
            // Add onClick event to the "yesButton" in the Inspector and assign this function to it
            yesButton.onClick.AddListener(ContinueConversation);
        }

        if (currentItemIndex == 4)
        {
            // Activate the game object once the text has finished scrolling through
            tutorialCanvas.SetActive(true);
            tutorialDialogue.SetActive(false);
        }
    }

    public void ContinueConversation()
    {
        // Increment the currentItemIndex to continue the conversation
        currentItemIndex++;
        // Disable the buttons
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        ActivateText();
    }
}
