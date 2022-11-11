using UnityEngine;

public class StackingColliderController : MonoBehaviour
{
    [SerializeField] private Collider[] menuStackItems;
    public string[] ingredientNames = new string[4];
    private int counter = 0;
    private void OnTriggerEnter(Collider other)
    {
        menuStackItems[counter].gameObject.SetActive(true);
        if(counter < menuStackItems.Length - 1) counter++;
    }

    public Collider[] GetStackItems()
    {
        return menuStackItems;
    }
}
