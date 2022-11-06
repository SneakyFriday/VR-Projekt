using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    /**
     * Sitzt auf der Plate
     * Speichert das Menu, welches auf ihm liegt
     */
    private StackingColliderController _stackingColliderController;
    void Start()
    {
        _stackingColliderController = GetComponent<StackingColliderController>();
    }
    
    void Update()
    {
        for (int i = 0; i < _stackingColliderController.ingredientNames.Length; i++)
        {
            print("Names: " + _stackingColliderController.ingredientNames[i]);
        }
        
    }
}
