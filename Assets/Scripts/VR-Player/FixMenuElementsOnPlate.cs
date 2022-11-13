using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FixMenuElementsOnPlate : MonoBehaviour
{
    private Queue<GameObject> _menuItems = new();
    private List<GameObject> _items = new();
    private void OnTriggerEnter(Collider other)
    {
        // if (other.CompareTag("Ingredient"))
        // {
        //    _menuItems.Enqueue(other.gameObject);
        //     print("New GameObject in Queue: " + other.gameObject.name);
        //     foreach (var item in _menuItems)
        //     {
        //        print("Current Queue Items: " + item.name);
        //     }
        //     print("Size:" + _menuItems.Count);
        //     
        // }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Ingredient") || coll.gameObject.CompareTag("IngredientCooked"))
        {
            _items.Add(coll.gameObject);
            print("Item added to list: " + coll.gameObject.name);
            print("Size: " + _items.Count);
        }
    }

    private void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.CompareTag("Ingredient") || coll.gameObject.CompareTag("IngredientCooked"))
        {
            _items.Remove(coll.gameObject);
            print("Item removed from list: " + coll.gameObject.name);
            print("Size: " + _items.Count);
        }
    }

    public void FixateMenu()
    {
        foreach (var item in _items)
        {
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.GetComponent<Collider>().enabled = false;
            item.transform.SetParent(transform, true);
            print("Setting Parent: " + transform.name + " for Ingredient: " + item.name);
        }
    }
}
