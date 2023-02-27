using UnityEngine;

public class CaterpillerPulsating : MonoBehaviour
{
    public float scaleRange = 0.5f;
    public float pulsateSpeed = 1.0f;
    public float phaseOffset = 0.2f;

    private Vector3[] startingScales;
    private float timer = 0.0f;

    void Start()
    {
        int numSegments = transform.childCount -2 ;
        startingScales = new Vector3[numSegments];
        for (int i = 0; i < numSegments; i++)
        {
            startingScales[i] = transform.GetChild(i).localScale;
        }
    }

    void Update()
    {
        timer += Time.deltaTime * pulsateSpeed;

        int numSegments = transform.childCount -2 ;
        for (int i = 0; i < numSegments; i++)
        {
            float scaleFactor = Mathf.Sin(timer + i * phaseOffset) * scaleRange + 1.0f;
            transform.GetChild(i).localScale = startingScales[i] * scaleFactor;
            
        }
    }
}
