using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnContact : MonoBehaviour
{
  private void OnCollisionEnter(Collision other)
  {
      Destroy(gameObject);
  }
}
