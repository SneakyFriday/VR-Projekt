using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RefillStationController : MonoBehaviour
{
    [SerializeField] private int maxRefillItems = 10;
    [SerializeField] private int currentRefillItemCount = 10;
    [SerializeField] private int refillAmountOnPlayer = 1;
    [SerializeField] private float refillTime = 5f;
    [SerializeField] private float shipCallRepeatRate = 5f;
    [SerializeField] private TextMeshProUGUI refillText;
    public GameObject refillShip;
    public GameObject refillShipSpawnpoint;
    private bool isFading;

    /**
     * Refills the station with the given amount of items.
     */
    public void RefillStation(int refillAmount)
    {
        print("Refill Station");
        if(currentRefillItemCount < maxRefillItems)
        {
            currentRefillItemCount += refillAmount;
            print("Refilling Station: " + currentRefillItemCount);
        }
    }

    public int GetAvailableItems()
    {
        return currentRefillItemCount;
    }

    
    public int RefillStockOnPlayer()
    {
        //print("Refilling Player with: " + currentRefillItemCount);
        currentRefillItemCount -= refillAmountOnPlayer;
        print("Left on Station: " + currentRefillItemCount);
        return refillAmountOnPlayer;
    }

     public void Start()
    {
        // Diese Zeile Code aus der Start Mehtode später rausnehmen und jedes mal aufrufen wenn die Station aufgefüllt werden soll.
        InvokeRepeating(nameof(CallRefillShip), refillTime, shipCallRepeatRate);
    }
     
     private void CallRefillShip()
     {
         Instantiate(refillShip, refillShipSpawnpoint.transform.position, refillShipSpawnpoint.transform.rotation);
     }
}
