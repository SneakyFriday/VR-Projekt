using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryFoodOverTime : MonoBehaviour
{
    
    [SerializeField] private int cookingTime = 3;
    [SerializeField] private GameObject cookedPatty;
    [SerializeField] private AudioClip _fryStart, _fryEnd;
    private AudioSource _audioSource;
    private bool _isCooking;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartCooking()
    {
        StartCoroutine(FryFood());
        _isCooking = true;
    }

    public void StopCooking()
    {
        StopCoroutine(FryFood());
        _audioSource.Stop();
        _isCooking = false;
    }
    
    IEnumerator FryFood()
    {
        // Sound + Particle Effekt auf Objekt Starten
        print("Cooking Item: " + this);
        _audioSource.PlayOneShot(_fryStart);
        yield return new WaitForSeconds(cookingTime);
        if (_isCooking)
        {
            Destroy(gameObject);
            _audioSource.Stop();
           Instantiate(cookedPatty, transform.position, transform.rotation);
           _audioSource.PlayOneShot(_fryEnd);  
        }
        
        print("Item cooked: " + name);
    }
}
