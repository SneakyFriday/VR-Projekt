using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DishController : MonoBehaviour
{
    [SerializeField] private DishScriptableObject dishScriptableObject;
   
    void Start()
    {
        SetDishProperties();
    }

    public void SetDishProperties()
    {
        GetComponentInChildren<Image>().sprite = dishScriptableObject.dishArt;
        GetComponentInChildren<TextMeshPro>().text = dishScriptableObject.name;
    }
}
