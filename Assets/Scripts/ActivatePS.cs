using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatePS : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private bool isActivated;
    [SerializeField] private Image refillIconBackgroundImage;

    private float backgroundAlpha;

    private void Start()
    {
        if(refillIconBackgroundImage == null) return;
        backgroundAlpha = refillIconBackgroundImage.color.a;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Particle System Triggered");
        if (!other.GetComponent<PlayerPickUpController>() || isActivated) return;
        ps.Play();
        isActivated = true;
        
        if(refillIconBackgroundImage == null) return;
        refillIconBackgroundImage.color = new Color(
            refillIconBackgroundImage.color.r, 
            refillIconBackgroundImage.color.g, 
            refillIconBackgroundImage.color.b, 
            .3f);
    }
    
    private void OnTriggerExit(Collider other)
    {
        print("Exit Particle System");
        if (!other.GetComponent<PlayerPickUpController>() || !isActivated) return;
        ps.Stop();
        isActivated = false;
        
        if(refillIconBackgroundImage == null) return;
        refillIconBackgroundImage.color = new Color(
            refillIconBackgroundImage.color.r, 
            refillIconBackgroundImage.color.g, 
            refillIconBackgroundImage.color.b, 
            backgroundAlpha);
    }
}
