using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseInteractable : MonoBehaviour
{
    [SerializeField] private GameObject interactionObject;

    /**
     * Logik:
     * VR-Spieler greift in Objekt
     * Wenn Trigger gehalten wird -> Object wird an Hand instanziiert
     *
     * Wenn Collision mit Spielerhand und Trigger gedrückt
     * Dann instanziiere Objekt bei Hand Transform
     */
    
    public GameObject TakeObject()
    {
        // Gibt dem Nutzer das Object aus
        return interactionObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        // InputFeatureUsage<bool> primaryButton;
        if (other.CompareTag("RightHand") || other.CompareTag("LeftHand"))
        {
            Instantiate(interactionObject, other.transform.position, Quaternion.identity);
        }
    }
}
