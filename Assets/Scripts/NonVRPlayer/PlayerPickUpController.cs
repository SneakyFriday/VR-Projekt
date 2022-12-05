using UnityEngine;

public class PlayerPickUpController : MonoBehaviour
{
    [SerializeField] private GameObject tray;
    [SerializeField] private bool isCarrying;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FixMenuElementsOnPlate>() && !isCarrying)
        {
            print("Found Component on Object");
            tray.SetActive(true);
            isCarrying = true;
            Destroy(other.gameObject);
        }
    }
}
