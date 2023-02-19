using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FryFoodOverTime : MonoBehaviour
{
    [SerializeField] private int cookingTime = 3;
    [SerializeField] private GameObject cookedFood;
    [SerializeField] private AudioClip _fryStart;
    [SerializeField] private ParticleSystem _fryParticle;
    private AudioSource _audioSource;
    private bool _isCooking;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /**
     * Startet das Braten des Objekts
     */
    public void StartCooking()
    {
        // Richtet das Particle System immer nach oben aus
        _fryParticle.gameObject.transform.rotation = Quaternion.LookRotation(Vector3.up);
        StartCoroutine(FryFood());
        _isCooking = true;
    }

    /**
    * Stoppt das Braten des Objekts
    */
    public void StopCooking()
    {
        StopCoroutine(FryFood());
        _audioSource.Stop();
        _fryParticle.Stop();
        _isCooking = false;
    }

    /**
    * Brät das Objekt über die angegebene Zeit
    */
    IEnumerator FryFood()
    {
        // Sound + Particle Effekt auf Objekt Starten
        print("Cooking Item: " + this);
        _audioSource.PlayOneShot(_fryStart);
        _fryParticle.Play();
        yield return new WaitForSeconds(cookingTime);
        if (_isCooking)
        {
            _audioSource.Stop();
            _fryParticle.Stop();
            Destroy(gameObject);
            Instantiate(cookedFood, transform.position, transform.rotation);
        }

        print("Item cooked: " + name);
    }
}