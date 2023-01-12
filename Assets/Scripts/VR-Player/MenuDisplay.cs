using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuDisplay : MonoBehaviour
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
