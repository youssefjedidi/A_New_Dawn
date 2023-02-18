using System.Collections;
using UnityEngine;

public class lifeR : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public float glowIntensity = 1.0f;
    public float glowSpeed = 1.0f;
    public float baseColorValue = 0.5f;

    private bool rotatingRight = true;
    private SpriteRenderer spriteRenderer;
    private float timer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = Random.Range(4.0f, 15.0f);
    }

    private void Update()
    {
        // Rotate the image
        if (rotatingRight)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        }

        // Change direction of rotation after a random interval of time
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            rotatingRight = !rotatingRight;
            timer = Random.Range(4.0f, 15.0f);
        }

        // Glow the image
        float emission = Mathf.PingPong(Time.time * glowSpeed, glowIntensity) + baseColorValue;
        spriteRenderer.color = new Color(emission, emission, emission, spriteRenderer.color.a);
    }
}
