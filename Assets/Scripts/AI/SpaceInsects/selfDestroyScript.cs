using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroyScript : MonoBehaviour
{
    public float selfDestruct;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, selfDestruct);
    }
}
