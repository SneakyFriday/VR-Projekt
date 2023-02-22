using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePS : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private bool isActivated;
    
    private void OnTriggerEnter(Collider other)
    {
        print("Particle System Triggered");
        if (!other.GetComponent<PlayerPickUpController>() || isActivated) return;
        ps.Play();
        isActivated = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        print("Exit Particle System");
        if (!other.GetComponent<PlayerPickUpController>() || !isActivated) return;
        ps.Stop();
        isActivated = false;
    }
}
