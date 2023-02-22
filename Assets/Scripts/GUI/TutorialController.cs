using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialController : MonoBehaviour
{
    public Sprite[] images;
    [TextArea] public string[] imageTexts;
    public Image imageDisplay;
    public TMP_Text imageTextDisplay;
    public TMP_Text progressText;
    public Button nextButton;
    public Button previousButton;
    public Image progressBar;
    private int currentImageIndex = 0;

    // Add the ScrollingText component to the tutorial controller
    public ScrollingText scrollingText;

    void Start()
    {
        imageDisplay.sprite = images[currentImageIndex];
        imageTextDisplay.text = imageTexts[currentImageIndex];
        progressBar.fillAmount = (float)currentImageIndex / (images.Length - 1);
        UpdateProgressText();

        nextButton.onClick.AddListener(ShowNextImage);
        previousButton.onClick.AddListener(ShowPreviousImage);
    }

    void ShowNextImage()
    {
        if (progressBar.fillAmount >= 1f)
        {
            // If the progress is already at 100%, disable the next button and return
            nextButton.interactable = false;
            return;
        }

        // Activate the scrolling text for the current image
        scrollingText.itemInfo = imageTexts[currentImageIndex].Split('\n');
        scrollingText.ActivateText();

        currentImageIndex = (currentImageIndex + 1) % images.Length;
        imageDisplay.sprite = images[currentImageIndex];
        imageTextDisplay.text = imageTexts[currentImageIndex];
        progressBar.fillAmount = (float)currentImageIndex / (images.Length - 1);
        UpdateProgressText();

        // Re-enable the next button in case it was previously disabled
        nextButton.interactable = true;
    }

    void ShowPreviousImage()
    {
        // Activate the scrolling text for the current image
        scrollingText.itemInfo = imageTexts[currentImageIndex].Split('\n');
        scrollingText.ActivateText();

        currentImageIndex = (currentImageIndex - 1 + images.Length) % images.Length;
        imageDisplay.sprite = images[currentImageIndex];
        imageTextDisplay.text = imageTexts[currentImageIndex];
        progressBar.fillAmount = (float)currentImageIndex / (images.Length - 1);
        UpdateProgressText();

        // Re-enable the next button if it was disabled
        nextButton.interactable = true;
    }

    void UpdateProgressText()
    {
        int progressPercent = Mathf.RoundToInt((float)currentImageIndex / (images.Length - 1) * 100f);
        progressText.text = $"{progressPercent}%";

        if (progressPercent == 100)
        {
            PlayerPrefs.SetInt("tutCompleted", 1);
        }
    }
}
