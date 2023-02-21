using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillShipScript : MonoBehaviour
{
    public GameObject refillFuel;

     void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("refillShip"))
        {
            InvokeRepeating("Refill", 0f, 0.2f);
        }
    }
    public void Refill()
    {
        Instantiate(refillFuel, transform.position, transform.rotation);
    }
    
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("refillShip"))
        {
            CancelInvoke("Refill");
        }
    }
}
