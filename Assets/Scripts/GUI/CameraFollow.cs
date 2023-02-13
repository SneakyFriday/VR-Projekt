using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

{

  public SettingsScriptableObject settingsScriptableObject;
  public Transform target;
  public float smoothSpeed = 10f;
  public Vector3 offset;

    void Start()
    {
         offset = settingsScriptableObject.offset;
         //print("Start(): offset: "+ offset);
    }

    void LateUpdate (){

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        //print("LateUpdate(): offset: "+ offset);
        transform.LookAt(target);
    }







}
