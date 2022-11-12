using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookFoodOverTime : MonoBehaviour
{
    [SerializeField] private int cookingTime = 3;
    private void OnCollisionEnter(Collision collision)
    {
        throw new NotImplementedException();
    }

    IEnumerator FryFoodOverTime()
    {
        // Sound + Particle Effekt auf Objekt Starten
        yield return new WaitForSeconds(cookingTime);
        // Objekt durch "gares" Objekt austauschen
    }
}
