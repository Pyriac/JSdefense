using UnityEngine;

public class VerticalOscillation : MonoBehaviour
{
    public float amplitude = 1f;
    public float frequency = 1f;
    public float speed = 0.5f;
    
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + amplitude * Mathf.Sin(speed * Mathf.PI * frequency * Time.time);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}