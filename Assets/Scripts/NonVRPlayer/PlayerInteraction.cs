using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject gast;
    public bool isInRange;
    public GameObject[] menuIcons = new GameObject[4];
    public GameObject willBestellen;
    public UnityEvent servedCustomerRight;

    [SerializeField] private MenuTable _menuTable;
    [SerializeField] private PointsController _pointsController;
    [SerializeField] private GuestPathfinding guestPathfinding;


    private int _orderNumber;
    private string[] _menues = { };
    private PlayerController _playerController;
    private PlayerPickUpController _playerPickUpController;

    private bool _bestellt;
    private bool _isInteracting;
    private string _order;
    private Dictionary<string, List<string>> _orderItems;
    public bool istBedient;


    private void Start()
    {
        istBedient = false;

        _menues = new[]
        {
            "burgerStandard",
            "burgerExpert",
            "steakMenu",
            "eggMenu"
        };

        //Sucht sich zu beginn ein Menue aus.
        //orderNumber = Random.Range(0, menues.Length);
        _orderNumber = 0;
        _order = _menues[_orderNumber];
        print("Order: " + _order);
        _orderItems = _menuTable.GetMenuItems(_order);
        print("Order Items: " + _orderItems.Values.Count);
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Wenn der Gast noch besteht, und der Spieler in den Interaktionsbereich kommt, wird isInRange auf true gesetzt.
        if (gast != null)
        {
            if (collider.CompareTag("PlayerContainer"))
            {
                isInRange = true;
                _playerController = collider.GetComponent<PlayerController>();
                if (guestPathfinding.isSeated() == true)
                {
                    _playerController.playerInteraction.AddListener(BestellungAufnehmen);
                    if (_bestellt == false)
                    {
                        menuIcons[3].SetActive(true);
                        willBestellen.SetActive(false);
                    }
                }
                _playerPickUpController = collider.GetComponent<PlayerPickUpController>();
            }
        }
        //Wenn der Gast nicht mehr besteht, wird der Interaktionsbereich deaktiviert.
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Verlässt der Gast den Interaktionsbereich, wird isInRange auf false gesetzt.
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("PlayerContainer"))
        {
          isInRange = false;
          _playerController.playerInteraction.RemoveListener(BestellungAufnehmen); 
          if (  _bestellt == false ){
            menuIcons[3].SetActive(false);
            willBestellen.SetActive(true);
          }
        }
    }

    // Funktion "BestellungAufnehmen", regelt das Bestellen und Bedienen. 
    private void BestellungAufnehmen()
    {
        print("Bestellung soll aufgenommen werden");
        if (_bestellt && (_orderItems != null || _playerPickUpController != null))
        {
            var containsMenuItem = false;

            if (_orderItems != null)
            {
                foreach (var item in _orderItems[_order])
                {
                    containsMenuItem = _playerPickUpController.GetMenuItemsFromPlayer().Contains(item);
                }

                if (containsMenuItem)
                {
                    print("Richtige Bestellung erhalten");
                    _playerPickUpController.DisableTray();
                    _playerPickUpController.SetScore();
                    //_pointsController.SetScore();
                    //servedCustomerRight.Invoke();
                    istBedient = true;
                }
            }
        }

        // Wenn der Gast noch nicht bestellt hat, wird ausgegeben welches Menü der Gast möchte.
        if (!_bestellt)
        {
            menuIcons[_orderNumber].SetActive(true);
            willBestellen.SetActive(false);
            menuIcons[3].SetActive(false);
            _bestellt = true;
        }
    }
    public bool BedienStatus()
    {
        return istBedient;
    }


    void Update()
    {
     if (guestPathfinding.isSeated() == true && _bestellt == false && isInRange == false)
          {
             willBestellen.SetActive(true);
          }
    }
}
