using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpController : MonoBehaviour
{
    [SerializeField] private GameObject tray;
    [SerializeField] private bool isCarrying;
    [SerializeField] private PlayerInteraction _playerInteraction;
    private List<String> _carriedMenu;

    private void Start()
    {
        _carriedMenu = new List<string>();
        _playerInteraction.servedCustomerRight.AddListener(DisableTray);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FixMenuElementsOnPlate>() && !isCarrying)
        {
            print("Found Component on Object");
            _carriedMenu = other.GetComponent<FixMenuElementsOnPlate>().CheckMenu();
            tray.SetActive(true);
            isCarrying = true;
            Destroy(other.gameObject);
            
            foreach (var item in _carriedMenu)
            {
                print(item);
            }
        }
    }

    private void DisableTray()
    {
        tray.SetActive(false);
        _carriedMenu.Clear();
        isCarrying = false;
    }

    public List<string> GetMenuItemsFromPlayer()
    {
        return _carriedMenu;
    }
}
