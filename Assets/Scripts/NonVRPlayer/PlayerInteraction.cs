using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject gast;
    public bool isInRange;
    public GameObject[] menuIcons = new GameObject[5];
    public GameObject willBestellen;
    public UnityEvent servedCustomerRight;

    [SerializeField] private MenuTable _menuTable;
    [SerializeField] private PointsController _pointsController;
    [SerializeField] private GuestPathfinding guestPathfinding;
    [SerializeField] public Timer timer;
    public GameObject timerObjekt;




    private int _orderNumber;
    private string[] _menues = { };
    private PlayerController _playerController;
    private PlayerPickUpController _playerPickUpController;

    private bool _bestellt;
    private bool _isInteracting;
    private string _order;
    private Dictionary<string, List<string>> _orderItems;
    public bool istBedient;
    public AudioSource rightOrder;
    public AudioSource wrongOrder;
    public bool timeOver = false;


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
        _orderNumber = Random.Range(0, _menues.Length);
        //_orderNumber = 0;
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
                        menuIcons[4].SetActive(true);
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
          if (!_bestellt){
            menuIcons[4].SetActive(false);
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

    public bool timeIsOver()
    {
        return timeOver;
    }

// Wenn der Gast sitzt, nicht bestellt hat soll er "Will bestellen" anzeigen.
// Wenn der Gast sitzt, bestellt hat soll der Timer angezeigt werden außer der Spieler ist nahe dem Gast dann wird das Menü angezeigt.
    void Update()
    {
     if (guestPathfinding.isSeated() && _bestellt == false && isInRange == false)
          {
             willBestellen.SetActive(true);
          }
      if (guestPathfinding.isSeated() && _bestellt && isInRange == false)
          {
            menuIcons[_orderNumber].SetActive(false);
            willBestellen.SetActive(false);
            menuIcons[4].SetActive(true);
            timerObjekt.transform.localScale = new Vector3((float)0.0262,(float) 0.0262,(float) 0.0262);

          } else if (guestPathfinding.isSeated() && _bestellt && isInRange)
          {
            menuIcons[_orderNumber].SetActive(true);
            willBestellen.SetActive(false);
            timerObjekt.transform.localScale = new Vector3(0, 0, 0);
            //menuIcons[4].SetActive(false);
          }
           if (timeOver == true){
            wrongOrder.Play();
          }
          if (istBedient == true){
            rightOrder.Play();
          }
    }
}
