using System;
using System.Collections.Generic;
using UnityEngine;

public class FixMenuElementsOnPlate : MonoBehaviour
{
    private Queue<GameObject> _menuItems = new();
    private List<GameObject> _items = new();
    private List<String> _itemNames = new();
    [SerializeField] private GameObject menuItemParent;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Ingredient") || coll.GetComponent<MenuItem>())
        {
            _items.Add(coll.gameObject);
            _itemNames.Add(coll.tag);
            print("Item added to list: " + coll.tag);
            print("Size: " + _items.Count);
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Ingredient") || coll.GetComponent<MenuItem>())
        {
          _items.Remove(coll.gameObject);
          _itemNames.Remove(coll.tag);
          print("Item removed from list: " + coll.tag);
        }
        
    }

    public void FixateMenuOnPlate()
    {
        print("Grab Plate");
        foreach (var item in _items)
        {
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.GetComponent<Collider>().enabled = false;
            item.transform.SetParent(transform, true);
            print(item.name);
        }
    }

    public void ReleaseMenuFromPlate()
    {
        print("Release Plate");
        transform.DetachChildren();
        foreach (var item in _items)
        {
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Collider>().enabled = true;
        }
    }

    public List<String> CheckMenu()
    {
        return _itemNames;
    }
}
