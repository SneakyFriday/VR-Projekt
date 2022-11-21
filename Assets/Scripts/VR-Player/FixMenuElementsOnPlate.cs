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
        // if (coll.CompareTag("Ingredient"))
        // {
        //    _menuItems.Enqueue(coll.gameObject);
        //     print("New GameObject in Queue: " + coll.gameObject.name);
        //     foreach (var item in _menuItems)
        //     {
        //        print("Current Queue Items: " + item.name);
        //     }
        //     print("Size:" + _menuItems.Count);
        //     
        // }
        
        if (coll.CompareTag("Ingredient") || coll.CompareTag("IngredientCooked"))
        {
            _items.Add(coll.gameObject);
            _itemNames.Add(coll.name);
            print("Item added to list: " + coll.name);
            print("Size: " + _items.Count);
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Ingredient") || coll.CompareTag("IngredientCooked"))
        {
          _items.Remove(coll.gameObject);
          _itemNames.Remove(coll.name);
          print("Item removed from list: " + coll.name);
        }
        
    }

    // private void OnCollisionEnter(Collision coll)
    // {
    //     if (coll.gameObject.CompareTag("Ingredient") || coll.gameObject.CompareTag("IngredientCooked"))
    //     {
    //         _items.Add(coll.gameObject);
    //         print("Item added to list: " + coll.gameObject.name);
    //         print("Size: " + _items.Count);
    //     }
    // }
    

    // private void OnCollisionExit(Collision coll)
    // {
    //     if (coll.gameObject.CompareTag("Ingredient") || coll.gameObject.CompareTag("IngredientCooked"))
    //     {
    //         _items.Remove(coll.gameObject);
    //         print("Item removed from list: " + coll.gameObject.name);
    //         print("Size: " + _items.Count);
    //     }
    // }

    public void FixateMenuOnPlate()
    {
        print("Grab Plate");
        foreach (var item in _items)
        {
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.GetComponent<Collider>().enabled = false;
            item.transform.SetParent(transform, true);
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

    public List<GameObject> CheckMenu()
    {
        return _items;
    }
}
