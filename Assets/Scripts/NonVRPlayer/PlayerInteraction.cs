using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteraction : MonoBehaviour
{
    bool bestellt = false;
public GameObject gast;

    // Update is called once per frame
    void Update()
    {

    }
    // wenn das Objekt mit dem Spieler kollidiert wird die Funktion OnCollisionEnter ausgeführt
    void OnTriggerEnter(Collider other)
    {
        // wenn das Objekt mit dem Tag "Gast" kollidiert und
        // Solange "Gast" nicht null ist, wird die Funktion ausgeführt.
        if (gast != null) {
            
        // wenn die Taste "E" gedrückt wird
        //if (Input.GetKeyDown(KeyCode.E)){

        // Wenn der Gast bestellt hat, wird der gast herausgeschmissen.
        if ( bestellt== true)
        {
            // das Objekt wird zerstört und ein Debug.Log ausgegeben.
            Destroy(gast);
            Debug.Log("Gast Rausgeschmissen!");
        }

        // Wenn der Gast noch nicht bestellt hat
        if (bestellt == false) 
        {
           
        // der Gast nimmt random das menü 1,2 oder 3 und gibt die entscheidung per Debug aus.
        int menue = Random.Range(1, 4);
        Debug.Log("Gast hat Menü " + menue + " gewählt");
        bestellt = true;
               
        //}
        }
    }
    }
}
