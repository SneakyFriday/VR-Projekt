using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "DishScriptableObject", menuName = "ScriptableObjects/Dish")]
public class DishScriptableObject : ScriptableObject
{
    public new string name;
    public int points;
    public Sprite dishArt;
    public List<avalaibleIngredients> ingredients;
    
    public enum avalaibleIngredients
    {
        bred,
        salat,
        ham,
        cheese
    }
}