using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class trashCan : MonoBehaviour
{
    public PlayerPickUpController playerPickUpController;
    private bool _inTrigger;
    public AudioSource trashSound;
    private bool isUsing;

    public void UseTrashCan()
    {
        if (_inTrigger)
        {
            print("Tray Deleted");
            playerPickUpController.DisableTray();
            trashSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            playerPickUpController = other.GetComponent<PlayerPickUpController>();
            print("Player Entered");
            _inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerContainer"))
        {
            print("Player Exited");
            _inTrigger = false;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        isUsing = context.action.triggered;
    }
}