using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookFoodOverTime : MonoBehaviour
{
    [SerializeField] private int cookingTime = 3;
    [SerializeField] private GameObject cookedPatty;
    private PlaySoundOnObject _playSoundOnObject;

    private void Start()
    {
        _playSoundOnObject = FindObjectOfType<PlaySoundOnObject>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Ingredient"))
        {
            StartCoroutine(FryFoodOverTime(coll.gameObject));
        }
    }

    IEnumerator FryFoodOverTime(GameObject cookingItem)
    {
        // Sound + Particle Effekt auf Objekt Starten
        print("Cooking Item: " + cookingItem);
        _playSoundOnObject.PlaySoundEffect();
        yield return new WaitForSeconds(cookingTime);
        // Objekt durch "gares" Objekt austauschen
        Destroy(cookingItem);
        Instantiate(cookedPatty, cookingItem.transform.position, cookingItem.transform.rotation);
        print("Item cooked: " + cookingItem);
    }
}
