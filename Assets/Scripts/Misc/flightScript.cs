using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flightScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 desiredPosition;
    public float smoothSpeed = 10f;

    void LateUpdate (){
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(desiredPosition);
    }
}
