using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCan : MonoBehaviour
{
    public PlayerPickUpController playerPickUpController;
    private bool _inTrigger;
    public AudioSource trashSound;
    private void Update()
    {
        if (Input.GetButtonDown("B Button") && _inTrigger == true)
        {
            print("Tray Deleted");
            playerPickUpController.DisableTray();
            trashSound.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerContainer"))
        {
            //print("Player Entered");
            _inTrigger = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerContainer"))
        {
            //print("Player Exited");
            _inTrigger = false;
        }
    }
}
