using UnityEngine;

public class CameraFollow : MonoBehaviour

{

  public SettingsScriptableObject settingsScriptableObject;
  public SettingsController settingsController;
  public Transform target;
  public float smoothSpeed = 10f;
  public Vector3 offset;
  
  
    void Start()
    {
         offset = settingsScriptableObject.offset;
         settingsController.OffsetChanged += UpdateOffset;
    }

    void Update()
    {
        // Check if the offset value has changed
        if (offset != settingsScriptableObject.offset)
        {
            // Update the offset value and store the new value
            offset = settingsScriptableObject.offset;
        }
    }
    
    void UpdateOffset()
    {
        offset = settingsScriptableObject.offset;
    }

    void OnDestroy()
    {
        settingsController.OffsetChanged -= UpdateOffset;
    }
    
    void LateUpdate ()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}
