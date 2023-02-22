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
        backgroundAlpha = refillIconBackgroundImage.color.a;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Particle System Triggered");
        if (!other.GetComponent<PlayerPickUpController>() || isActivated) return;
        refillIconBackgroundImage.color = new Color(
            refillIconBackgroundImage.color.r, 
            refillIconBackgroundImage.color.g, 
            refillIconBackgroundImage.color.b, 
            .3f);
        ps.Play();
        isActivated = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        print("Exit Particle System");
        if (!other.GetComponent<PlayerPickUpController>() || !isActivated) return;
        refillIconBackgroundImage.color = new Color(
            refillIconBackgroundImage.color.r, 
            refillIconBackgroundImage.color.g, 
            refillIconBackgroundImage.color.b, 
            backgroundAlpha);
        ps.Stop();
        isActivated = false;
    }
}
