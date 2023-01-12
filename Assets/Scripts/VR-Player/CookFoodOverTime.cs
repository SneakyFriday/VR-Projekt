using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookFoodOverTime : MonoBehaviour
{
    
    private bool _isCooking;

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<FryFoodOverTime>())
        {
            coll.gameObject.GetComponent<FryFoodOverTime>().StartCooking();
        }
    }

    private void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.GetComponent<FryFoodOverTime>())
        {
            coll.gameObject.GetComponent<FryFoodOverTime>().StopCooking();
        }
    }
}
