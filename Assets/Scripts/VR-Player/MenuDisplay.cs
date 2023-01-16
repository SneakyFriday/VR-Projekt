using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuDisplay : MonoBehaviour
{
    [SerializeField] private DishScriptableObject dishScriptableObject;
    [SerializeField] private TextMeshPro menuName;
    [SerializeField] private TextMeshPro menuPoints;
   
    void Start()
    {
        SetDishProperties();
    }

    public void SetDishProperties()
    {
        GetComponentInChildren<Image>().sprite = dishScriptableObject.dishArt;
        menuName.text = dishScriptableObject.name;
        menuPoints.text = "Punkte: " + dishScriptableObject.points;
    }
}
