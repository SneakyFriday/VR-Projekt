using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DishScriptableObject", menuName = "ScriptableObjects/Dish")]
public class DishScriptableObject : ScriptableObject
{
    [SerializeField] private string[] ingredients;

    enum Ingredients
    {
        Salat,
        Bred,
        Cheese
    }
    
    public string[] getIngredients()
    {
        return ingredients;
    }
}
