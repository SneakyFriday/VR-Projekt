using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPickUpController : MonoBehaviour
{
    [SerializeField] private GameObject tray;
    [SerializeField] private bool isCarrying;
    [SerializeField] private ShiftEndResume shiftEndResume;

    private List<String> _carriedMenu;
    private List<String> testMenu = new();
    public TextMeshProUGUI testScore;
    private int _currentScore;
    private int _burgerScore = 100;
    private int _servedCustomers;

    private void Start()
    {
        testMenu.Add("bun_top");
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
        foreach (var item in _carriedMenu)
        {
            print(item);
        }
    }

    public void SetScore()
    {
        _servedCustomers += 1;
        _currentScore += _burgerScore;
        testScore.text = "Score: " + _currentScore;
        shiftEndResume.HandleTextValues(_servedCustomers, 0, 0, _currentScore, 0, 0);
    }

    public List<string> GetMenuItemsFromPlayer()
    {
        return testMenu;
        //return _carriedMenu;
    }
}
