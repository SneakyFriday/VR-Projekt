using System;
using UnityEngine;

public class ServiceBellControler : MonoBehaviour
{
    private FixMenuElementsOnPlate _fixMenuElements;

    private void Start()
    {
        _fixMenuElements = FindObjectOfType<FixMenuElementsOnPlate>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand") || other.CompareTag("RightHand"))
        {
           _fixMenuElements.FixateMenu(); 
        }
        
    }
}
