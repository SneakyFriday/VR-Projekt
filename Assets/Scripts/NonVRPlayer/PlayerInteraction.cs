using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject gast;
    public bool isInRange;
    public int orderNumber;
    public string[] menues = { };
    public GameObject[] menuIcons = new GameObject[3];
    public GameObject willBestellen;
    public UnityEvent servedCustomerRight;
    [SerializeField] private MenuTable _menuTable;
    private PlayerController _playerController;
    private PlayerPickUpController _playerPickUpController;
    private bool _bestellt;
    private bool _isInteracting;
    private string _order;
    private Dictionary<string, List<string>> _orderItems;


    private void Start()
    {
        menues = new[]
        {
            "burgerStandard",
            "burgerExpert",
            "steakMenu",
            "eggMenu"
        };

        //Sucht sich zu beginn ein Menue aus.
        //orderNumber = Random.Range(0, menues.Length);
        orderNumber = 0;
        _order = menues[orderNumber];
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
                _playerController.playerInteraction.AddListener(BestellungAufnehmen);
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
        isInRange = false;
        _playerController.playerInteraction.RemoveListener(BestellungAufnehmen);
    }

    // Funktion "BestellungAufnehmen", regelt das Bestellen und Bedienen. 
    public void BestellungAufnehmen()
    {
        print("Bestellung soll aufgenommen werden");
        if (_bestellt && (_orderItems != null || _playerPickUpController != null))
        {
            var contains = false;
            // foreach (var item in _playerPickUpController.GetMenuItemsFromPlayer())
            // {
            //     print("Menu on Player: " + item);
            // }

            if (_orderItems != null)
            {
                foreach (var item in _orderItems[_order])
                {
                    contains = _playerPickUpController.GetMenuItemsFromPlayer().Contains(item);
                }

                if (contains)
                {
                    print("Richtige Bestellung erhalten");
                    servedCustomerRight.Invoke();
                    Destroy(gast);
                }
            }
        }

        // Wenn der Gast noch nicht bestellt hat, wird ausgegeben welches Menü der Gast möchte.
        if (!_bestellt)
        {
            menuIcons[orderNumber].SetActive(true);
            willBestellen.SetActive(false);
            _bestellt = true;
        }
    }
}