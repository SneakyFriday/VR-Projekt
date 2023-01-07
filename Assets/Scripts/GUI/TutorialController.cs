using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TutorialController : MonoBehaviour
{
    public Sprite[] images; // Das Image Array für die Bilder die angezeigt werden sollen
    public string[] imageTexts; // Array für die Texte die zu den Bildern gehören
    public Image imageDisplay; // Das Image Objekt das die Bilder anzeigt
    public TMP_Text imageTextDisplay; // Text Objekt das den Text zu den Bildern anzeigt
    public Button nextButton; // Button um zum nächsten Bild zu wechseln
    public Button previousButton; // Button um zum vorherigen Bild zu wechseln
    private int currentImageIndex = 0; // Der Index des aktuellen Bildes
    public Slider progressBar; // Slider zum anzeigen des Fortschritts der Tutorial Galerie 
    public TMP_Text progressText; // TextMeshPro text zum anzeigen des Fortschritts der Tutorial Galerie




    void Start()
    {
        // Setze das erste Bild als Anzeige Bild und füge die Listener für die Buttons hinzu 
        imageDisplay.sprite = images[currentImageIndex];
        imageTextDisplay.text = imageTexts[currentImageIndex];

        // Setze den Wert des Sliders auf den aktuellen Bild Index geteilt durch die Anzahl der Bilder
        progressBar.value = (float)currentImageIndex / (images.Length - 1);
        progressText.text = (progressBar.value * 100f).ToString("F0") + "%";

        nextButton.onClick.AddListener(ShowNextImage);
        previousButton.onClick.AddListener(ShowPreviousImage);
    }

    // Funktion um das nächste Bild in der Galerie anzuzeigen
    void ShowNextImage()
    {
        // Inkrementiere den aktuellen Bild Index und loope zurück zum Anfang wenn nötig
        currentImageIndex = (currentImageIndex + 1) % images.Length;
        // Aktualisiere das Bild das angezeigt wird mit dem neuen Bild
        imageDisplay.sprite = images[currentImageIndex];
        imageTextDisplay.text = imageTexts[currentImageIndex];

        // Update die Position des Sliders mit dem aktuellen Bild Index geteilt durch die Anzahl der Bilder
        progressBar.value = (float)currentImageIndex / (images.Length - 1);
        progressText.text = (progressBar.value * 100f).ToString("F0") + "%";
    }

    // Funktion um das vorherige Bild in der Galerie anzuzeigen
    void ShowPreviousImage()
    {
        // Dekrementiere den aktuellen Bild Index und loope zum Ende wenn nötig 
        currentImageIndex = (currentImageIndex - 1 + images.Length) % images.Length;
        // Aktualisiere das Bild das angezeigt wird mit dem neuen Bild
        imageDisplay.sprite = images[currentImageIndex];
        imageTextDisplay.text = imageTexts[currentImageIndex];

        // Update die Position des Sliders mit dem aktuellen Bild Index geteilt durch die Anzahl der Bilder
        progressBar.value = (float)currentImageIndex / (images.Length - 1);
        progressText.text = (progressBar.value * 100f).ToString("F0") + "%";
    }


}

