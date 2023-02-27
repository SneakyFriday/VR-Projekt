using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAnimation : MonoBehaviour
{
    public Animator anim;

    void OnTriggerEnter(Collider other)
    {
        print("trigger" + other.gameObject.tag);
        if (other.gameObject.tag == "Guest")
            anim.SetTrigger("OpenDoor");
    }
}
