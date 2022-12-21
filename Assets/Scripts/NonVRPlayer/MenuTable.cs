using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTable : MonoBehaviour
{
    //[SerializeField] private string menuName;
    [Header("Burger Standard")]
    [SerializeField] private GameObject[] burgerStandardMenuIngredients;
    [Header("Burger Expert")]
    [SerializeField] private GameObject[] burgerExpertMenuIngredients;
    [Header("Steak")]
    [SerializeField] private GameObject[] steakMenuIngredients;
    [Header("Egg")]
    [SerializeField] private GameObject[] eggMenuIngredients;

    private List<string> _burgerStandardMenu = new();
    private List<string> _burgerExpertMenu = new();
    private List<string> _steakMenu = new();
    private List<string> _eggMenu = new();
    void Awake()
    {
        foreach (var item in burgerStandardMenuIngredients)
        {
            _burgerStandardMenu.Add(item.tag);
        }
        
        foreach (var item in burgerExpertMenuIngredients)
        {
            _burgerExpertMenu.Add(item.tag);
        }
        
        foreach (var item in steakMenuIngredients)
        {
            _steakMenu.Add(item.tag);
        }
        
        foreach (var item in eggMenuIngredients)
        {
            _eggMenu.Add(item.tag);
        }
    }

    public Dictionary<string, List<string>> GetMenuItems(string menuName)
    {
        Dictionary<string, List<string>> returnMenu = new();
        if (menuName == "burgerStandard")
        {
            returnMenu.Add("burgerStandard", _burgerStandardMenu);
        }

        else if (menuName == "burgerExpert")
        {
            returnMenu.Add("burgerExpert", _burgerExpertMenu);
        }

        else if (menuName == "steakMenu")
        {
            returnMenu.Add("steakMenu", _steakMenu);
        }

        else if (menuName == "eggMenu")
        {
            returnMenu.Add("eggMenu", _eggMenu);
        }

        return returnMenu;
    }

    // private void Start()
    // {
    //     // Debug Test
    //     foreach (var item in GetMenuItems("burgerStandard").Values)
    //     {
    //         foreach (var name in item)
    //         {
    //             print(name);
    //         }
    //     }
    // }
}
