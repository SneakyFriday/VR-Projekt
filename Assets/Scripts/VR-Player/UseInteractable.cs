using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.XR;
using InputDevice = UnityEngine.InputSystem.InputDevice;

public class UseInteractable : MonoBehaviour
{
    [SerializeField] private GameObject interactionObject;
    private InputDevice targetDevice;
    private bool isGrabbing;
    private GameObject hand;


    /**
     * Logik:
     * VR-Spieler greift in Objekt
     * Wenn Trigger gehalten wird -> Object wird an Hand instanziiert
     *
     * Wenn Collision mit Spielerhand und Trigger gedrückt
     * Dann instanziiere Objekt bei Hand Transform
     */
    
    public void TakeObject()
    {
        Transform handPosition = hand.transform;
        // Gibt dem Nutzer das Object aus
        Instantiate(interactionObject, handPosition.position, Quaternion.identity);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LeftHand") || other.CompareTag("RightHand")) hand = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("LeftHand") || other.CompareTag("RightHand")) hand = null;
    }
    
}
