using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPickUpController : MonoBehaviour
{
    [SerializeField] private GameObject tray;
    [SerializeField] private bool isCarrying;

    private List<String> _carriedMenu;
    private List<String> testMenu = new();
    public TextMeshProUGUI testScore;

    private void Start()
    {
        testMenu.Add("bun_top");
        testMenu.Add("Lettuce");
        testMenu.Add("Cheese");
        testMenu.Add("Patty_done");
        testMenu.Add("bun_buttom");
        
        _carriedMenu = new List<string>();
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

    public void DisableTray()
    {
        print("Disabling Tray");
        tray.SetActive(false);
        _carriedMenu.Clear();
        isCarrying = false;
    }

    public List<string> GetMenuItemsFromPlayer()
    {
        return testMenu;
        //return _carriedMenu;
    }
}
