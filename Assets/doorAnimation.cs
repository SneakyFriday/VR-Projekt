using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAnimation : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
 
 

    // Update is called once per frame  
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Guest")
            anim.SetTrigger("OpenDoor");
    }
}
