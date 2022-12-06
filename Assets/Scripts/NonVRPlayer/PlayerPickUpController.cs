using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpController : MonoBehaviour
{
    [SerializeField] private GameObject tray;
    [SerializeField] private bool isCarrying;
    private List<String> _carriedMenu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FixMenuElementsOnPlate>() && !isCarrying)
        {
            print("Found Component on Object");
            _carriedMenu = other.GetComponent<FixMenuElementsOnPlate>().CheckMenu();
            tray.SetActive(true);
            isCarrying = true;
            Destroy(other.gameObject);
        }

        foreach (var item in _carriedMenu)
        {
            print(item);
        }
    }
}
