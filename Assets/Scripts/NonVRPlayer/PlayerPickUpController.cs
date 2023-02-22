using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPickUpController : MonoBehaviour
{
    [SerializeField] private GameObject tray;
    [SerializeField] private bool isCarrying;
    [SerializeField] private ShiftEndResume shiftEndResume;
    [SerializeField] private PlayerRefillController playerRefillController;

    private List<string> _carriedMenu;
    //private List<String> testMenu = new();
    public TextMeshProUGUI testScore;
    private int _currentScore;
    private int _burgerScore = 100;
    private int _servedCustomers;
    private int _refillItems;
    private bool hasRefillAccess;
    private bool hasRefillStationAccess;
    private RefillStationController _refillStationController;
    private FoodSpawnPoint _foodSpawnPoint;

    /**
     * Hier ist ein Test Menu auskommentiert, welches zum Debuggen genutzt werden kann
     */
    private void Start()
    {
        //testMenu.Add("bun_top");
        //testMenu.Add("Cheese");
        //testMenu.Add("Patty_done");
        //testMenu.Add("bun_buttom");
        
        _carriedMenu = new List<string>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FixMenuElementsOnPlate>() && !isCarrying)
        {
            //print("Found Component on Object");
            _carriedMenu = other.GetComponent<FixMenuElementsOnPlate>().CheckMenu();
            tray.SetActive(true);
            isCarrying = true;
            Destroy(other.gameObject);
            
            foreach (var item in _carriedMenu)
            {
                print(item);
            }
        }

        if (other.GetComponent<FoodSpawnPoint>())
        {
            hasRefillAccess = true;
            _foodSpawnPoint = other.GetComponent<FoodSpawnPoint>();
            //print("RefillKitchen Access: " + hasRefillAccess);
        }

        if (other.GetComponent<RefillStationController>())
        {
            hasRefillStationAccess = true;
            _refillStationController = other.GetComponent<RefillStationController>();
            //print("Refill Access: " + hasRefillStationAccess + "|| Got RefillStationController Component: " + _refillStationController.enabled);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FoodSpawnPoint>())
        {
            hasRefillAccess = false;
            //print("RefillKitchen: " + hasRefillAccess);
        }

        if (other.GetComponent<RefillStationController>())
        {
            hasRefillStationAccess = false;
            //print("Refill: " + hasRefillStationAccess);
        }
    }

    /**
     * Bei Menuabgabe beim Gast wird das Menu geleert.
     * Der Spieler kann wieder ein neues Menu tragen.
     * Das Tablet wird deaktiviert.
     */
    public void DisableTray()
    {
        //print("Disabling Tray");
        tray.SetActive(false);
        _carriedMenu.Clear();
        isCarrying = false;
        foreach (var item in _carriedMenu)
        {
            print(item);
        }
    }

    /**
     * Punkte werden gesetzt
     * Bediente Gäste werden gezählt
     */
    public void SetScore()
    {
        _servedCustomers += 1;
        _currentScore += _burgerScore;
        testScore.text = "Score: " + _currentScore;
        shiftEndResume.HandleTextValues(_servedCustomers, 0, 0, _currentScore, 0, 0);
    }

    /**
     * Gibt das aktuelle Menu des Spielers zurück.
     */
    public List<string> GetMenuItemsFromPlayer()
    {
        //return testMenu;
        return _carriedMenu;
    }


    #region RefillStation
    
    /**
     * Player bekommt von der RefillStation die Refillanzahl.
     * Bis zu 10 Items kann der Spieler tragen.
     */
    public void PickUpRefill()
    {
        if (hasRefillStationAccess && _refillStationController.GetAvailableItems() > 0)
        {
            if(_refillItems >= 10) return;
            _refillItems += _refillStationController.RefillStockOnPlayer();
            playerRefillController.ShowAndFade(true);
            print("RefillItems PickUp: " + _refillItems);
        }
    }

    /**
     * Player füllt die Items in der Kitchen auf.
     */
    public void RefillItems()
    {
        if (hasRefillAccess && _refillItems > 0)
        {
            if(_foodSpawnPoint.GetAvailableItems() >= _foodSpawnPoint.GetMaxItemsAvailable()) return;
            playerRefillController.ShowAndFade(false);
            _foodSpawnPoint.RefillItems();
            _refillItems -= 1;
            print("RefillItems Kitchen: " + _refillItems);
        }
    }
    
    #endregion
}
