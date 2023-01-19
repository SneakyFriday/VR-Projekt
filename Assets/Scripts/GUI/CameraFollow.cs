using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

{

  public SettingsScriptableObject settingsScriptableObject;
  public Transform target;
  public float smoothSpeed = 10f;
  public Vector3 offset;

    void LateUpdate (){

        LoadOffset();
        DontDestroyOnLoad(settingsScriptableObject);


        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        print("offset: "+ offset);
        transform.LookAt(target);
    }

    public void SaveOffset()
    {
        settingsScriptableObject.offset = offset;
        settingsScriptableObject.smoothSpeed = smoothSpeed;
    } 

    public void LoadOffset()
    {
        offset = settingsScriptableObject.offset;
        smoothSpeed = settingsScriptableObject.smoothSpeed;
    }






}
