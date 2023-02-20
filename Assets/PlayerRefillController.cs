using TMPro;
using UnityEngine;

public class PlayerRefillController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI refillText;
    [SerializeField] private float fadeDuration = 1.0f;
    private bool isFading;

    private void Start()
    {
        refillText.color = new Color(refillText.color.r, refillText.color.g, refillText.color.b, 0.0f);
    }

    private void Update()
    {
        if (isFading)
        {
            float alpha = refillText.color.a;
            alpha -= Time.deltaTime / fadeDuration;
            refillText.color = new Color(refillText.color.r, refillText.color.g, refillText.color.b, alpha);
            if (alpha <= 0.0f)
            {
                refillText.gameObject.SetActive(false);
                isFading = false;
            }
        }
    }

    private void LateUpdate()
    {
        // Aktualisieren der Drehung des Texts zur Kamera
        refillText.transform.LookAt(refillText.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }

    public void ShowAndFade(bool atStation)
    {
        refillText.text = atStation ? "+ Item" : "- Item";
        refillText.gameObject.SetActive(true);
        refillText.color = new Color(refillText.color.r, refillText.color.g, refillText.color.b, 1.0f);
        isFading = true;
    }
}
