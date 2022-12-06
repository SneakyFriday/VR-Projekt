using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    bool bestellt = false;
    public GameObject gast;
    public bool isInRange;
    public UnityEvent InteractAction;
    GameObject order;
    public int orderNumber;
    public GameObject[] menues = new GameObject[3];
    public GameObject[] menuIcons = new GameObject[3];
    public GameObject willBestellen;


    private void Start()
    {
        //Sucht sich zu beginn ein Menue aus.
        orderNumber = Random.Range(0, 3);
        order = menues[orderNumber];
        
    }
    void Update()
    {
        //Wenn der Spieler im Interaktionsbereich ist und die erste Taste auf dem Controller gedrückt wird, wird die Interaktion ausgeführt.
        if (isInRange == true && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            // Triggert die Interaktion, die in der Unity-Event-Liste hinterlegt ist. In diesem falle ist es der aufruf der Funktion "BestellungAufnehmen".
            InteractAction.Invoke();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Wenn der Gast noch besteht, und der Spieler in den Interaktionsbereich kommt, wird isInRange auf true gesetzt.
        if (gast != null)
        {
            if (collider.tag == "PlayerContainer")
            {
                isInRange = true;
            }
        }

        //Wenn der Gast nicht mehr besteht, wird der Interaktionsbereich deaktiviert.
        else
        {
            gameObject.SetActive(false);
        }

        //Wenn das richtige Essen ankommt, bezahlt der Gast und verschwindet.
        if (collider.gameObject.name == order.name)
        {
            // Wenn der Gast bedient wurde, wird der Gast gelöscht.
            Debug.Log("Gast hat richtiges Essen bekommen.");
            Destroy(gast);
        }
    }

    // Verlässt der Gast den Interaktionsbereich, wird isInRange auf false gesetzt.
    private void OnTriggerExit(Collider collider)
    {
        isInRange = false;
    }

    // Funktion "BestellungAufnehmen", regelt das Bestellen und Bedienen. 
    public void BestellungAufnehmen()
    {
        // Wenn der Gast bestellt hat, wird nochmals ausgegeben was der Gast bestellt hat.
        if (bestellt == true)
        {
            Debug.Log("Gast wartet auf sein Essen! Menü : " + order.name);
        }

        // Wenn der Gast noch nicht bestellt hat, wird ausgegeben welches Menü der Gast möchte.
        if (bestellt == false)
        {
            // der Gast nimmt random das menü 1,2 oder 3 und gibt die entscheidung per Debug aus.
            Debug.Log("Gast hat Menü " + order.name + " gewählt");

            // Sobald der Spieler mit dem Gast interagiert wird die Bestellung angezeigt.
            menuIcons[orderNumber].SetActive(true);
            // Das ! wird dann nur ausgeblendet.
            willBestellen.SetActive(false);
            bestellt = true;
        }
    }
}