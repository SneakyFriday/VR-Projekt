using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(DishScriptableObject))]
public class DropdownMenu : Editor
{
    public enum Ingredients
    {
        Salat,
        Bred,
        Cheese
    }

    public Ingredients ingredientsDropdown;
    public override void OnInspectorGUI()
    {
        ingredientsDropdown = (Ingredients)EditorGUILayout.EnumPopup("Ingredients", ingredientsDropdown);

        EditorGUILayout.Space(); 
        serializedObject.ApplyModifiedProperties();

    }
}
