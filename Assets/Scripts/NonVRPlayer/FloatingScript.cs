using UnityEngine;

public class FloatingScript: MonoBehaviour {

  Vector3 initPos;
  public float amp,
  freq,
  spin;

  void Start() {
    initPos = transform.position;
  }
  void Update() {
      transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, transform.position.z);
      transform.Rotate(0, 0, spin * Time.deltaTime, Space.Self);

  }
}