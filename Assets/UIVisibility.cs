using UnityEngine;
using UnityEngine.UI;

public class UIVisibility : MonoBehaviour
{
    public GameObject uiElement;
    public string nonVRLayer = "NON-VR Layer";
    public Camera NONVRCamera;

    void Start()
    {
        NONVRCamera.cullingMask= ~(1 << LayerMask.NameToLayer(nonVRLayer));
    }
}
