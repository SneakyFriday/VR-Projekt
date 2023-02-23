using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int number;
    // Start is called before the first frame update
    void Start()
    {
        print("Hello Lea");
    }

    // Update is called once per frame
    void Update()
    {
        number = number + 1;
        print("Ich habe dich Lieb " + number+ " mal");
    }
}
