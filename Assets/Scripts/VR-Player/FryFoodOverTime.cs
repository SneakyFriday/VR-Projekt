using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryFoodOverTime : MonoBehaviour
{
    
    [SerializeField] private int cookingTime = 3;
    [SerializeField] private GameObject cookedPatty;
    [SerializeField] private AudioClip _fryStart, _fryEnd;
    private AudioSource _audioSource;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartCooking()
    {
        StartCoroutine(FryFood(gameObject));
    }

    public void StopCooking()
    {
        StopCoroutine(FryFood(gameObject));
    }
    
    IEnumerator FryFood(GameObject cookingItem)
    {
        // Sound + Particle Effekt auf Objekt Starten
        print("Cooking Item: " + cookingItem);
        _audioSource.PlayOneShot(_fryStart);
        yield return new WaitForSeconds(cookingTime);
        // Objekt durch "gares" Objekt austauschen
        Destroy(cookingItem);
        _audioSource.Stop();

 
        Instantiate(cookedPatty, cookingItem.transform.position, cookingItem.transform.rotation);
        _audioSource.PlayOneShot(_fryEnd); 
     
        
        print("Item cooked: " + cookingItem);
    }
}
