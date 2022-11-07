using UnityEngine;

public class CheckIngredients : MonoBehaviour
{
    [SerializeField] private GameObject friesRegionCollider;
    [SerializeField] private GameObject burgerRegionCollider;
    private GameObject _menuRegion;

    private void Start()
    {
        // Default Einstellung
        _menuRegion = burgerRegionCollider;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fries"))
        {
            _menuRegion.SetActive(false);
            _menuRegion = friesRegionCollider;
            _menuRegion.SetActive(true);
        }
        if (other.CompareTag("Bread") || other.CompareTag("Cheese") || other.CompareTag("Salat") || other.CompareTag("Onion"))
        {
            _menuRegion.SetActive(false);
            _menuRegion = burgerRegionCollider;
            _menuRegion.SetActive(true);
        }
        print("ENTER: " + _menuRegion.name + " " + _menuRegion.activeSelf);
    }

    private void OnTriggerExit(Collider other)
    {
        _menuRegion.SetActive(false);
        print("EXIT: " + _menuRegion.name + " " + _menuRegion.activeSelf);
    }
}
