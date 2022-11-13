using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookFoodOverTime : MonoBehaviour
{
    [SerializeField] private int cookingTime = 3;
    [SerializeField] private GameObject cookedPatty;
    [SerializeField] private AudioClip _fryStart, _fryEnd;
    private AudioSource _stoveAudioSource;

    private void Start()
    {
        _stoveAudioSource = GetComponent<AudioSource>();
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
        _stoveAudioSource.PlayOneShot(_fryStart);
        yield return new WaitForSeconds(cookingTime);
        // Objekt durch "gares" Objekt austauschen
        Destroy(cookingItem);
        _stoveAudioSource.Stop();
        Instantiate(cookedPatty, cookingItem.transform.position, cookingItem.transform.rotation);
        _stoveAudioSource.PlayOneShot(_fryEnd);
        print("Item cooked: " + cookingItem);
    }
}
